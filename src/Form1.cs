using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CShapeNetPortScanApplication
{
    public partial class Form1 : Form
    {
        PortScanner ps;
        bool is_scanning = false;

        public Form1()
        {
            InitializeComponent();
        }

        public void Textbox1appendText(string TextToAppend)
        {
            this.textBox1.Text += TextToAppend;
            this.textBox1.Text += "\r\n";
        }

        void startScan()
        {
            string host;
            int portStart;
            int portStop;
            int Threads;
            int timeout;

        youGotItWrong: //goto: Start Again

            string ip;
            //这是供用户选择主机 ip
            ip = IpAddressText.Text;
            host = ip;

            //这是供用户选择起始端口
            string startPort;
            startPort = startportText.Text;
            //MessageBox.Show("startPort : " + startPort) ;

            //此检查以查看是否可以解析起始端口
            int number;
            bool resultStart = int.TryParse(startPort, out number);

            if (resultStart)
            {
                portStart = int.Parse(startPort);
            }

            else
            {
                MessageBox.Show("请重试，该起始端口违规!!");
                goto youGotItWrong;
                // return;
            }


            //这是用于结束端口
            string endPort;
            endPort = endportText.Text;
            //MessageBox.Show("endPort : " + endPort);


            //这将检查是否可以解析结束端口
            int number2;
            bool resultEnd = int.TryParse(endPort, out number2);

            if (resultEnd)
            {
                portStop = int.Parse(endPort);
            }

            else
            {
                //Console.WriteLine("请重试，该终止端口违规!!");
                MessageBox.Show("请重试，该终止端口违规!!");
                goto youGotItWrong;
                // return;
            }

            //这是将启动的线程数
            string threadsToRun;
            threadsToRun = threadnumText.Text;
            //MessageBox.Show("threadsToRun : " + threadsToRun);


            //这将检查是否可以解析结束端口
            int number3;
            bool resultThreads = int.TryParse(threadsToRun, out number3);

            if (resultThreads)
            {
                Threads = int.Parse(threadsToRun);
            }

            else
            {
                //Console.WriteLine("请重试，该线程数量违规!!");
                MessageBox.Show("请重试，该线程数量违规!!");
                goto youGotItWrong;

                // return;
            }

            //这是将启动的线程数
            string tcpTimeout;
            tcpTimeout = timeoutText.Text;
            //MessageBox.Show("tcpTimeout : " + tcpTimeout);

            //此检查以查看是否可以解析超时
            int number4;
            bool resultTimeout = int.TryParse(tcpTimeout, out number4);

            if (resultTimeout)
            {
                timeout = int.Parse(tcpTimeout) * 1000;

            }

            else
            {
                MessageBox.Show("请重试，该超时时间违规!!");
                goto youGotItWrong;
                //  return;
            }

            try
            {

                host = ip;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            if (resultStart == true && resultEnd == true)
            {
                try
                {

                    portStart = int.Parse(startPort);
                    portStop = int.Parse(endPort);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

            }
            if (resultThreads == true)
            {
                try
                {

                    Threads = int.Parse(threadsToRun);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    return;
                }
            }

            ps = new PortScanner(host, portStart, portStop, timeout,this);
            ps.start(Threads);
        }

        public void progressUpdate(int value)
        {
            this.scanprogressBar.Value = value;
        }
        /*******************************响应事件*************************************/
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /**
         * 开始扫描按钮事件
         */
        private void btn_start_Click(object sender, EventArgs e)
        {
            if(is_scanning == false) {
                startScan();
                is_scanning = true;
            }
            else
            {
                ps.ScanStop();
                startScan();
            }
            
        }
        /**
         * 停止扫描按钮事件
         */
        private void btn_stop_Click(object sender, EventArgs e)
        {
            ps.ScanPause();
        }
        /**
         * 恢复扫描事件
         */
        private void btn_resume_Click(object sender, EventArgs e)
        {
            ps.ScanResume();
        }

        /*****************************************************************************/
    }
}
