using SeeSharpTools.JY.Remoting;
using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;

namespace Server
{
    public partial class ServerForm : Form
    {
        private Random rand = new Random();
        private double[] data = new double[10];
        private JYRemotingServer _server;
        private ServerSetting setting;

        public ServerForm()
        {
            InitializeComponent();
            setting = new ServerSetting() { LocalPort = int.Parse(textBox_port.Text) };
            InitializeServer();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (_server.Variables[0].IsDataUpdated)
            {
                led_variable1.Value = (bool)_server.Variables[0].Read();
            }
            if (_server.Variables[1].IsDataUpdated)
            {
                textBox_variable2.Text = _server.Variables[1].Read().ToString();
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
            _server = new JYRemotingServer(setting);
            _server.Start();
            _server.AddVariable(textBox_varName1.Text,led_variable1.Value.GetType());
            _server.AddVariable(textBox_varName2.Text, textBox_variable2.Text.GetType());
            _server.Variables[0].DataUpdatedEvent += ServerForm_DataUpdatedEvent;
        }

        private void ServerForm_DataUpdatedEvent(object msg)
        {
        }

        private void buttonSwitch1_ValueChanged(object sender, EventArgs e)
        {
            led_variable1.Value = buttonSwitch_update.Value;
            _server.Variables[0].Write(buttonSwitch_update.Value);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            _server.Variables[1].Write(textBox_variable2.Text);
        }
    }
}