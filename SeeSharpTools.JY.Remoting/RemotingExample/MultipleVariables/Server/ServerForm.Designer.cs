﻿namespace Server
{
    partial class ServerForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox_variable2 = new System.Windows.Forms.TextBox();
            this.buttonSwitch_update = new SeeSharpTools.JY.GUI.ButtonSwitch();
            this.button_writeText = new System.Windows.Forms.Button();
            this.led_variable1 = new SeeSharpTools.JY.GUI.LED();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.textBox_varName1 = new System.Windows.Forms.TextBox();
            this.textBox_varName2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox_variable2
            // 
            this.textBox_variable2.Location = new System.Drawing.Point(342, 245);
            this.textBox_variable2.Name = "textBox_variable2";
            this.textBox_variable2.Size = new System.Drawing.Size(152, 28);
            this.textBox_variable2.TabIndex = 1;
            // 
            // buttonSwitch_update
            // 
            this.buttonSwitch_update.Location = new System.Drawing.Point(518, 198);
            this.buttonSwitch_update.Name = "buttonSwitch_update";
            this.buttonSwitch_update.OffFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSwitch_update.OnFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSwitch_update.Size = new System.Drawing.Size(80, 28);
            this.buttonSwitch_update.TabIndex = 2;
            this.buttonSwitch_update.ValueChanged += new SeeSharpTools.JY.GUI.ButtonSwitch.CheckedChangedDelegate(this.buttonSwitch1_ValueChanged);
            // 
            // button_writeText
            // 
            this.button_writeText.Location = new System.Drawing.Point(518, 245);
            this.button_writeText.Name = "button_writeText";
            this.button_writeText.Size = new System.Drawing.Size(75, 28);
            this.button_writeText.TabIndex = 3;
            this.button_writeText.Text = "写入";
            this.button_writeText.UseVisualStyleBackColor = true;
            this.button_writeText.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // led_variable1
            // 
            this.led_variable1.BlinkColor = System.Drawing.Color.Lime;
            this.led_variable1.BlinkInterval = 1000;
            this.led_variable1.BlinkOn = false;
            this.led_variable1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.led_variable1.Interacton = SeeSharpTools.JY.GUI.LED.InteractionStyle.Indicator;
            this.led_variable1.Location = new System.Drawing.Point(342, 198);
            this.led_variable1.Name = "led_variable1";
            this.led_variable1.OffColor = System.Drawing.Color.Gray;
            this.led_variable1.OnColor = System.Drawing.Color.Lime;
            this.led_variable1.Size = new System.Drawing.Size(152, 28);
            this.led_variable1.Style = SeeSharpTools.JY.GUI.LED.LedStyle.Rectangular;
            this.led_variable1.TabIndex = 4;
            this.led_variable1.Value = false;
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(460, 118);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(151, 28);
            this.textBox_port.TabIndex = 6;
            this.textBox_port.Text = "8088";
            // 
            // textBox_varName1
            // 
            this.textBox_varName1.Location = new System.Drawing.Point(165, 198);
            this.textBox_varName1.Name = "textBox_varName1";
            this.textBox_varName1.Size = new System.Drawing.Size(151, 28);
            this.textBox_varName1.TabIndex = 6;
            this.textBox_varName1.Text = "switch";
            // 
            // textBox_varName2
            // 
            this.textBox_varName2.Location = new System.Drawing.Point(165, 245);
            this.textBox_varName2.Name = "textBox_varName2";
            this.textBox_varName2.Size = new System.Drawing.Size(151, 28);
            this.textBox_varName2.TabIndex = 6;
            this.textBox_varName2.Text = "text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "服务器端口号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "变量1名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "变量2名称";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(29)))), ((int)(((byte)(34)))));
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(717, 80);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(29)))), ((int)(((byte)(34)))));
            this.label1.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(88, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(572, 48);
            this.label1.TabIndex = 9;
            this.label1.Text = "JYRemotingServer 服务器";
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 325);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_varName2);
            this.Controls.Add(this.textBox_varName1);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.led_variable1);
            this.Controls.Add(this.button_writeText);
            this.Controls.Add(this.buttonSwitch_update);
            this.Controls.Add(this.textBox_variable2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ServerForm";
            this.Text = "JYRemotingServer 服务器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox_variable2;
        private SeeSharpTools.JY.GUI.ButtonSwitch buttonSwitch_update;
        private System.Windows.Forms.Button button_writeText;
        private SeeSharpTools.JY.GUI.LED led_variable1;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.TextBox textBox_varName1;
        private System.Windows.Forms.TextBox textBox_varName2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label1;
    }
}

