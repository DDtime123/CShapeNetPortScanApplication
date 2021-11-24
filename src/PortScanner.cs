using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CShapeNetPortScanApplication
{
    class PortScanner
    {
        private Form1 form1;
        private string host;
        private PortList portList;
        private int workThread = 0;
        private int count = 0;
        public int tcpTimeout;
        private List<Thread> threads;
        int curcount = -1;
        ManualResetEvent _pauseEvent;
        bool _stopEvent;

        private class isTcpPortOpen
        {
            public TcpClient MainClient { get; set; }
            public bool tcpOpen { get; set; }
        }


        public PortScanner(string host, int portStart, int portStop, int timeout,Form1 form)
        {
            this.host = host;
            portList = new PortList(portStart, portStop);
            tcpTimeout = timeout;
            this.form1 = form;
            this.threads = new List<Thread>(50);
            this._pauseEvent = new ManualResetEvent(true);
            this._stopEvent = false;
        }

        public void start(int threadCounter)
        {
            for (int i = 0; i < threadCounter; i++)
            {

                Thread thread1 = new Thread(new ThreadStart(RunScanTcp));
                thread1.IsBackground = true;// 设置为后台线程
                threads.Add(thread1);
                thread1.Start();
                workThread++;
            }

        }

        public void ScanPause()
        {
            _pauseEvent.Reset();
        }

        public void ScanResume()
        {
            _pauseEvent.Set();
        }

        public void ScanStop()
        {
            // 关闭所有线程
            _stopEvent = true;
        }

        public void RunScanTcp()
        {

            int port;
            int openport;
            //当有更多的端口要扫描
            while ((port = portList.NextPort()) != -1)
            {
                //检查ManualResetEvent
                _pauseEvent.WaitOne(Timeout.Infinite);
                //检查退出线程事件
                if (_stopEvent)
                {
                    return;
                }

                count = port;

                Thread.Sleep(1); //让我们成为 CPU 的好公民

                //更新进度条
                form1.Invoke((MethodInvoker)delegate {
                    // Running on the UI thread
                    int currentProgress = portList.getCurrentProgress();
                    form1.progressUpdate(currentProgress > 100 ? 100: currentProgress);
                });

                if (curcount < count)
                {
                    curcount = count;
                    form1.Invoke((MethodInvoker)delegate
                    {
                        // Running on the UI thread
                        form1.Textbox1appendText("Current Port Count : " + count.ToString());
                    });
                }

                try
                {

                    Connect(host, port, tcpTimeout);

                }
                catch
                {
                    continue;
                }

                //Console.ForegroundColor = ConsoleColor.Green;
                //Console.WriteLine();
                //Console.WriteLine("TCP Port {0} is open ", port);
                form1.Invoke((MethodInvoker)delegate {
                    // Running on the UI thread
                    form1.Textbox1appendText(string.Format("TCP Port {0} is open ", port));
                });

                try
                {
                    //抓取横幅/标题信息等。
                    //Console.WriteLine(BannerGrab(host, port, tcpTimeout));
                    form1.Invoke((MethodInvoker)delegate {
                        // Running on the UI thread
                        //form1.Textbox1appendText(BannerGrab(host, port, tcpTimeout));
                        MessageBox.Show("Port " + port.ToString() + "\n"+BannerGrab(host, port, tcpTimeout));
                    });

                }
                catch (Exception ex)
                {
                    form1.Invoke((MethodInvoker)delegate {
                        // Running on the UI thread
                        form1.Textbox1appendText("无法检索横幅 , 原始错误 = " + ex.Message);
                    });
                }
                string webpageTitle = GetPageTitle("http://" + host + ":" + port.ToString(),form1);

                if (!string.IsNullOrWhiteSpace(webpageTitle))
                {
                    //这将获取网页的 html 标题
                    form1.Invoke((MethodInvoker)delegate {
                        // Running on the UI thread
                        //form1.Textbox1appendText("网页标题 = " + webpageTitle + "Found @ :: " + "http://" + host + ":" + port.ToString());
                        MessageBox.Show("Port "+ port.ToString() + "\n网页标题 = " + webpageTitle + "Found @ :: " + "http://" + host + ":" + port.ToString());
                    });
                }
                else
                {
                    form1.Invoke((MethodInvoker)delegate {
                        // Running on the UI thread
                        //form1.Textbox1appendText("也许发现登录弹出窗口或服务登录@:: " + host + ":" + port.ToString());
                        MessageBox.Show("Port " + port.ToString() + "\n也许发现登录弹出窗口或服务登录@:: " + host + ":" + port.ToString());
                    });
                }


                
            }


            if (Interlocked.Decrement(ref workThread) == 0)
            {
                form1.Invoke((MethodInvoker)delegate {
                    // Running on the UI thread
                    form1.Textbox1appendText("Scan Complete !!!");
                });
                //Console.ReadKey();

            }

        }
        //返回tcp客户端连接或未连接的方法
        public TcpClient Connect(string hostName, int port, int timeout)
        {
            var newClient = new TcpClient();

            var state = new isTcpPortOpen
            {
                MainClient = newClient,
                tcpOpen = true
            };

            IAsyncResult ar = newClient.BeginConnect(hostName, port, AsyncCallback, state);
            state.tcpOpen = ar.AsyncWaitHandle.WaitOne(timeout, false);

            if (state.tcpOpen == false || newClient.Connected == false)
            {
                throw new Exception();

            }
            return newClient;
        }

        //抓取网页横幅/标题信息的方法
        public string BannerGrab(string hostName, int port, int timeout)
        {
            var newClient = new TcpClient(hostName, port);


            newClient.SendTimeout = timeout;
            newClient.ReceiveTimeout = timeout;
            NetworkStream ns = newClient.GetStream();
            StreamWriter sw = new StreamWriter(ns);

            //sw.Write("GET / HTTP/1.1\r\n\r\n");

            sw.Write("HEAD / HTTP/1.1\r\n\r\n"
                + "Connection: Closernrn");

            sw.Flush();

            byte[] bytes = new byte[2048];
            int bytesRead = ns.Read(bytes, 0, bytes.Length);
            string response = Encoding.ASCII.GetString(bytes, 0, bytesRead);

            return response;
        }


        //tcp 客户端的异步回调
        void AsyncCallback(IAsyncResult asyncResult)
        {
            var state = (isTcpPortOpen)asyncResult.AsyncState;
            TcpClient client = state.MainClient;

            try
            {
                client.EndConnect(asyncResult);
            }
            catch
            {
                return;
            }

            if (client.Connected && state.tcpOpen)
            {
                return;
            }

            client.Close();
        }

        static string GetPageTitle(string link,Form1 from)
        {
            try
            {

                WebClient x = new WebClient();
                string sourcedata = x.DownloadString(link);
                string getValueTitle = Regex.Match(sourcedata, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;

                return getValueTitle;

            }
            catch (Exception ex)
            {
                from.Invoke((MethodInvoker)delegate {
                    // Running on the UI thread
                    from.Textbox1appendText("无法连接 Error:" + ex.Message);
                });
                return "";
            }


        }

    }
}