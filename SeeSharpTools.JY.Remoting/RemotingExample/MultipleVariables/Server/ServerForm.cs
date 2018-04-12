using SeeSharpTools.JY.Remoting.Common;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Server
{
    public partial class ServerForm : Form
    {
        private Random rand = new Random();
        private double[] data = new double[10];
        private SeeSharpTools.JY.Remoting.Common.Server _server;
        private BindingList<RemotingVariable> variables;
        private ServerSetting setting = new ServerSetting() { LocalPort = 8088 };
        public ServerForm()
        {
            InitializeComponent();
            variables = new BindingList<RemotingVariable>();
            variables.Add(new RemotingVariable("switch",false) );
            variables.Add(new RemotingVariable("text", "text"));

            for (int i = 0; i < variables.Count; i++)
            {
                int index= dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells["uri"].Value = string.Format("tcp://{0}:{1}/{2}", "localhost", setting.LocalPort, variables[i].Name);
                dataGridView1.Rows[index].Cells["name"].Value = variables[i].Name;
                dataGridView1.Rows[index].Cells["type"].Value = variables[i].Value.GetType().ToString();
                dataGridView1.Rows[index].Cells["value"].ValueType = variables[i].Value.GetType();
                //dataGridView1.Rows[index].Cells["value"].bi
            }

            InitializeServer();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (_server.Variables[0].IsDataUpdated)
            {
                led1.Value = (bool)_server.Variables[0].Read();
            }
            if (_server.Variables[1].IsDataUpdated)
            {
                textBox2.Text = _server.Variables[1].Read().ToString();

            }

            //重复读取
            //object data = _server.Variables[0].Read();
            //buttonSwitch1.Value = (bool)data;
            //data = _server.Variables[1].Read();
            //textBox2.Text = data.ToString();


            timer1.Enabled = true;
        }

        private void InitializeServer()
        {
            _server = new SeeSharpTools.JY.Remoting.Common.Server(new ServerSetting() { LocalPort = 8088 });
            _server.Start();
            _server.AddVariable("switch",typeof(bool));
            _server.AddVariable("text",typeof(string));
            _server.Variables[0].DataUpdatedEvent += ServerForm_DataUpdatedEvent;
        }

        private void ServerForm_DataUpdatedEvent(object msg)
        {
        }

        private void buttonSwitch1_ValueChanged(object sender, EventArgs e)
        {
            led1.Value = buttonSwitch1.Value;
            var a = _server.Variables[0];
            a.Write(buttonSwitch1.Value);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            _server.Variables[1].Write(textBox1.Text);
        }
    }

    internal class RemotingVariable
    {
        public object Value { get; set; }
        public string Name { get; }

        public RemotingVariable(string name, object value)
        {
            this.Value = value;
            this.Name = name;
        }

    }
}