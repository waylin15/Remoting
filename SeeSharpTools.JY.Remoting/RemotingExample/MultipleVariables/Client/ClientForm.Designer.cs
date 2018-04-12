namespace Client
{
    partial class ClientForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonSwitch1 = new SeeSharpTools.JY.GUI.ButtonSwitch();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.led1 = new SeeSharpTools.JY.GUI.LED();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(57, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(216, 60);
            this.button1.TabIndex = 3;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonSwitch1
            // 
            this.buttonSwitch1.Location = new System.Drawing.Point(225, 193);
            this.buttonSwitch1.Name = "buttonSwitch1";
            this.buttonSwitch1.OffFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSwitch1.OnFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSwitch1.Size = new System.Drawing.Size(50, 19);
            this.buttonSwitch1.TabIndex = 6;
            this.buttonSwitch1.ValueChanged += new SeeSharpTools.JY.GUI.ButtonSwitch.CheckedChangedDelegate(this.buttonSwitch1_ValueChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(45, 232);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 28);
            this.textBox1.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(225, 232);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // led1
            // 
            this.led1.BlinkColor = System.Drawing.Color.Lime;
            this.led1.BlinkInterval = 1000;
            this.led1.BlinkOn = false;
            this.led1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.led1.Interacton = SeeSharpTools.JY.GUI.LED.InteractionStyle.Indicator;
            this.led1.Location = new System.Drawing.Point(118, 168);
            this.led1.Name = "led1";
            this.led1.OffColor = System.Drawing.Color.Gray;
            this.led1.OnColor = System.Drawing.Color.Lime;
            this.led1.Size = new System.Drawing.Size(60, 60);
            this.led1.Style = SeeSharpTools.JY.GUI.LED.LedStyle.Circular;
            this.led1.TabIndex = 9;
            this.led1.Value = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(45, 266);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(158, 28);
            this.textBox2.TabIndex = 7;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 380);
            this.Controls.Add(this.led1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonSwitch1);
            this.Controls.Add(this.button1);
            this.Name = "ClientForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private SeeSharpTools.JY.GUI.ButtonSwitch buttonSwitch1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private SeeSharpTools.JY.GUI.LED led1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

