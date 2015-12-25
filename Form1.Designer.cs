namespace ServerFast
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.lstOnline = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.textBox1_zhujiip = new System.Windows.Forms.TextBox();
            this.textBox2_zhujiduankou = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtString = new System.Windows.Forms.TextBox();
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.textBox1_receive = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1_tiaoshi = new System.Windows.Forms.TextBox();
            this.chkHexReceive = new System.Windows.Forms.CheckBox();
            this.button3_clear = new System.Windows.Forms.Button();
            this.chkHexSend = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(-1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(805, 436);
            this.tabControl1.TabIndex = 0;
            // 
            // lstOnline
            // 
            this.lstOnline.FormattingEnabled = true;
            this.lstOnline.ItemHeight = 12;
            this.lstOnline.Location = new System.Drawing.Point(6, 15);
            this.lstOnline.Name = "lstOnline";
            this.lstOnline.Size = new System.Drawing.Size(183, 400);
            this.lstOnline.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstOnline);
            this.groupBox1.Location = new System.Drawing.Point(825, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 424);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "在线人数：";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(858, 444);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(142, 43);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "开始监听";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // textBox1_zhujiip
            // 
            this.textBox1_zhujiip.Location = new System.Drawing.Point(100, 456);
            this.textBox1_zhujiip.Name = "textBox1_zhujiip";
            this.textBox1_zhujiip.Size = new System.Drawing.Size(127, 21);
            this.textBox1_zhujiip.TabIndex = 4;
            this.textBox1_zhujiip.Text = "192.168.2.113";
            // 
            // textBox2_zhujiduankou
            // 
            this.textBox2_zhujiduankou.Location = new System.Drawing.Point(388, 456);
            this.textBox2_zhujiduankou.Name = "textBox2_zhujiduankou";
            this.textBox2_zhujiduankou.Size = new System.Drawing.Size(100, 21);
            this.textBox2_zhujiduankou.TabIndex = 5;
            this.textBox2_zhujiduankou.Text = "65001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 459);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "主机ip:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 459);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "服务器端口:";
            // 
            // txtString
            // 
            this.txtString.Location = new System.Drawing.Point(22, 20);
            this.txtString.Multiline = true;
            this.txtString.Name = "txtString";
            this.txtString.Size = new System.Drawing.Size(640, 143);
            this.txtString.TabIndex = 0;
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.Location = new System.Drawing.Point(679, 138);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(90, 25);
            this.btnSendMsg.TabIndex = 1;
            this.btnSendMsg.Text = "发送消息";
            this.btnSendMsg.UseVisualStyleBackColor = true;
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // textBox1_receive
            // 
            this.textBox1_receive.Location = new System.Drawing.Point(22, 205);
            this.textBox1_receive.Multiline = true;
            this.textBox1_receive.Name = "textBox1_receive";
            this.textBox1_receive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1_receive.Size = new System.Drawing.Size(406, 171);
            this.textBox1_receive.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(19, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "接收消息：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(462, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "调试信息：";
            // 
            // textBox1_tiaoshi
            // 
            this.textBox1_tiaoshi.Location = new System.Drawing.Point(464, 205);
            this.textBox1_tiaoshi.Multiline = true;
            this.textBox1_tiaoshi.Name = "textBox1_tiaoshi";
            this.textBox1_tiaoshi.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1_tiaoshi.Size = new System.Drawing.Size(311, 171);
            this.textBox1_tiaoshi.TabIndex = 17;
            // 
            // chkHexReceive
            // 
            this.chkHexReceive.AutoSize = true;
            this.chkHexReceive.Location = new System.Drawing.Point(334, 180);
            this.chkHexReceive.Name = "chkHexReceive";
            this.chkHexReceive.Size = new System.Drawing.Size(96, 16);
            this.chkHexReceive.TabIndex = 18;
            this.chkHexReceive.Text = "十六进制接收";
            this.chkHexReceive.UseVisualStyleBackColor = true;
            // 
            // button3_clear
            // 
            this.button3_clear.Location = new System.Drawing.Point(134, 382);
            this.button3_clear.Name = "button3_clear";
            this.button3_clear.Size = new System.Drawing.Size(75, 23);
            this.button3_clear.TabIndex = 19;
            this.button3_clear.Text = "清除";
            this.button3_clear.UseVisualStyleBackColor = true;
            this.button3_clear.Click += new System.EventHandler(this.button3_clear_Click);
            // 
            // chkHexSend
            // 
            this.chkHexSend.AutoSize = true;
            this.chkHexSend.Location = new System.Drawing.Point(679, 79);
            this.chkHexSend.Name = "chkHexSend";
            this.chkHexSend.Size = new System.Drawing.Size(96, 16);
            this.chkHexSend.TabIndex = 22;
            this.chkHexSend.Text = "十六进制发送";
            this.chkHexSend.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkHexSend);
            this.tabPage1.Controls.Add(this.button3_clear);
            this.tabPage1.Controls.Add(this.chkHexReceive);
            this.tabPage1.Controls.Add(this.textBox1_tiaoshi);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBox1_receive);
            this.tabPage1.Controls.Add(this.btnSendMsg);
            this.tabPage1.Controls.Add(this.txtString);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(797, 410);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "收发界面";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 507);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2_zhujiduankou);
            this.Controls.Add(this.textBox1_zhujiip);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ListBox lstOnline;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textBox1_zhujiip;
        private System.Windows.Forms.TextBox textBox2_zhujiduankou;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox chkHexSend;
        private System.Windows.Forms.Button button3_clear;
        private System.Windows.Forms.CheckBox chkHexReceive;
        private System.Windows.Forms.TextBox textBox1_tiaoshi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1_receive;
        private System.Windows.Forms.Button btnSendMsg;
        private System.Windows.Forms.TextBox txtString;
    }
}

