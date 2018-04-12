namespace Server
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonSwitch1 = new SeeSharpTools.JY.GUI.ButtonSwitch();
            this.button1 = new System.Windows.Forms.Button();
            this.led1 = new SeeSharpTools.JY.GUI.LED();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.uri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(224, 404);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(210, 28);
            this.textBox1.TabIndex = 1;
            // 
            // buttonSwitch1
            // 
            this.buttonSwitch1.Location = new System.Drawing.Point(454, 357);
            this.buttonSwitch1.Name = "buttonSwitch1";
            this.buttonSwitch1.OffFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSwitch1.OnFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSwitch1.Size = new System.Drawing.Size(50, 19);
            this.buttonSwitch1.TabIndex = 2;
            this.buttonSwitch1.ValueChanged += new SeeSharpTools.JY.GUI.ButtonSwitch.CheckedChangedDelegate(this.buttonSwitch1_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(454, 404);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // led1
            // 
            this.led1.BlinkColor = System.Drawing.Color.Lime;
            this.led1.BlinkInterval = 1000;
            this.led1.BlinkOn = false;
            this.led1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.led1.Interacton = SeeSharpTools.JY.GUI.LED.InteractionStyle.Indicator;
            this.led1.Location = new System.Drawing.Point(352, 316);
            this.led1.Name = "led1";
            this.led1.OffColor = System.Drawing.Color.Gray;
            this.led1.OnColor = System.Drawing.Color.Lime;
            this.led1.Size = new System.Drawing.Size(60, 60);
            this.led1.Style = SeeSharpTools.JY.GUI.LED.LedStyle.Circular;
            this.led1.TabIndex = 4;
            this.led1.Value = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(224, 451);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(210, 28);
            this.textBox2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uri,
            this.name,
            this.type,
            this.value});
            this.dataGridView1.Location = new System.Drawing.Point(71, 66);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(458, 150);
            this.dataGridView1.TabIndex = 5;
            // 
            // uri
            // 
            this.uri.HeaderText = "URI";
            this.uri.Name = "uri";
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            // 
            // type
            // 
            this.type.HeaderText = "Type";
            this.type.Name = "type";
            // 
            // value
            // 
            this.value.HeaderText = "Value";
            this.value.Name = "value";
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 528);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.led1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonSwitch1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "ServerForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
        private SeeSharpTools.JY.GUI.ButtonSwitch buttonSwitch1;
        private System.Windows.Forms.Button button1;
        private SeeSharpTools.JY.GUI.LED led1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn uri;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
    }
}

