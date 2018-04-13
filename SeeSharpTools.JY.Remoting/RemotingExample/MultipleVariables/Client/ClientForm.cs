using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SeeSharpTools.JY.Remoting;

namespace Client
{
    public partial class ClientForm : Form
    {
        private Configuration config = new Configuration();
        private List<JYRemotingClient> clientList = new List<JYRemotingClient>();

        public ClientForm()
        {
            InitializeComponent();
        }

        private void InitializeClient()
        {
            clientList.Clear();
            config.Setting.Add(new ClientSetting() { ConnectedIP = textBox_ipAddress.Text, LocalPort = 0, ConnectedPort = int.Parse(textBox_port.Text), Name = textBox_varName1.Text });
            config.Setting.Add(new ClientSetting() { ConnectedIP = textBox_ipAddress.Text, LocalPort = 1, ConnectedPort = int.Parse(textBox_port.Text), Name = textBox_varName2.Text });

            foreach (ClientSetting item in config.Setting)
            {
                JYRemotingClient client =new JYRemotingClient(item);
                clientList.Add(client);
                client.ServerDisconnectionEvent += Client_ServerDisconnectionEvent;
                client.Start();
            }
        }

        private void Client_ServerDisconnectionEvent(object sender, EventArgs e)
        {
            MessageBox.Show("服务器断线");
        }


        [Serializable]
        public class Configuration
        {
            public List<ClientSetting> Setting { get; set; }

            public Configuration()
            {
                Setting = new List<ClientSetting>();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;

                if (clientList[0].IsDataUpdated)
                {
                    led_variable1.Value = (bool)clientList[0].Read();

                }
                if (clientList[1].IsDataUpdated)
                {
                    textBox_variable2.Text = clientList[1].Read().ToString();
                }

                //重复读取
                //object data = clientList[0].ReadData();
                //if (data is Boolean)
                //{
                //    led1.Value = (bool)data;
                //}
                //data = clientList[1].ReadData();
                //if (data is String)
                //{
                //    textBox2.Text = data.ToString();
                //}

                timer1.Enabled = true;
            }
            catch (TimeoutException ex)
            {
            }
        }


        private void button_writeText_Click(object sender, EventArgs e)
        {
            clientList[1].Write(textBox_variable2.Text);

        }

        private void buttonSwitch_update_ValueChanged(object sender, EventArgs e)
        {
            led_variable1.Value = buttonSwitch_update.Value;
            clientList[0].Write(buttonSwitch_update.Value);

        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            InitializeClient();
            timer1.Start();
        }
    }
}