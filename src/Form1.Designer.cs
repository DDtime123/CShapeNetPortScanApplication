
namespace CShapeNetPortScanApplication
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.IpAddressText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.startportText = new System.Windows.Forms.TextBox();
            this.endportText = new System.Windows.Forms.TextBox();
            this.threadnumText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timeoutText = new System.Windows.Forms.TextBox();
            this.scanprogressBar = new System.Windows.Forms.ProgressBar();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_resume = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(389, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(353, 426);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(12, 358);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(97, 44);
            this.btn_start.TabIndex = 1;
            this.btn_start.Text = "开始扫描";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // IpAddressText
            // 
            this.IpAddressText.Location = new System.Drawing.Point(12, 49);
            this.IpAddressText.Name = "IpAddressText";
            this.IpAddressText.Size = new System.Drawing.Size(371, 23);
            this.IpAddressText.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "输入IP地址或者域名(www.xxx.com) : ";
            // 
            // startportText
            // 
            this.startportText.Location = new System.Drawing.Point(13, 115);
            this.startportText.Name = "startportText";
            this.startportText.Size = new System.Drawing.Size(370, 23);
            this.startportText.TabIndex = 4;
            // 
            // endportText
            // 
            this.endportText.Location = new System.Drawing.Point(13, 178);
            this.endportText.Name = "endportText";
            this.endportText.Size = new System.Drawing.Size(370, 23);
            this.endportText.TabIndex = 5;
            // 
            // threadnumText
            // 
            this.threadnumText.Location = new System.Drawing.Point(13, 257);
            this.threadnumText.Name = "threadnumText";
            this.threadnumText.Size = new System.Drawing.Size(370, 23);
            this.threadnumText.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "请输入一个起始端口 : (最小起始端口 : 0)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "请输入一个终止端口 : (最大终止端口 : 65535)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(261, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "输入要运行的线程数 : (线程数量在 1 - 50 之间)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(308, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "输入超时时间 : (超时时间介于 1 - 10 秒之间（1 = 1 秒)";
            // 
            // timeoutText
            // 
            this.timeoutText.Location = new System.Drawing.Point(13, 323);
            this.timeoutText.Name = "timeoutText";
            this.timeoutText.Size = new System.Drawing.Size(370, 23);
            this.timeoutText.TabIndex = 11;
            // 
            // scanprogressBar
            // 
            this.scanprogressBar.Location = new System.Drawing.Point(13, 415);
            this.scanprogressBar.Name = "scanprogressBar";
            this.scanprogressBar.Size = new System.Drawing.Size(370, 23);
            this.scanprogressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.scanprogressBar.TabIndex = 12;
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(137, 358);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(101, 44);
            this.btn_stop.TabIndex = 13;
            this.btn_stop.Text = "停止扫描";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_resume
            // 
            this.btn_resume.Location = new System.Drawing.Point(263, 358);
            this.btn_resume.Name = "btn_resume";
            this.btn_resume.Size = new System.Drawing.Size(97, 44);
            this.btn_resume.TabIndex = 14;
            this.btn_resume.Text = "恢复扫描";
            this.btn_resume.UseVisualStyleBackColor = true;
            this.btn_resume.Click += new System.EventHandler(this.btn_resume_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 450);
            this.Controls.Add(this.btn_resume);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.scanprogressBar);
            this.Controls.Add(this.timeoutText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.threadnumText);
            this.Controls.Add(this.endportText);
            this.Controls.Add(this.startportText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IpAddressText);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.TextBox IpAddressText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox startportText;
        private System.Windows.Forms.TextBox endportText;
        private System.Windows.Forms.TextBox threadnumText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox timeoutText;
        private System.Windows.Forms.ProgressBar scanprogressBar;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_resume;
    }
}

