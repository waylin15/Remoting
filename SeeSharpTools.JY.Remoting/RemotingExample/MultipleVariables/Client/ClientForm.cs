using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SeeSharpTools.JY.Remoting.Common;

namespace Client
{
    public partial class ClientForm : Form
    {
        private Configuration config = new Configuration();
        private List<SeeSharpTools.JY.Remoting.Common.Client> clientList = new List<SeeSharpTools.JY.Remoting.Common.Client>();

        public ClientForm()
        {
            InitializeComponent();
            config.Setting.Add(new ClientSetting() { LocalPort = 0, ConnectedPort = 8088, Name = "switch" });
            config.Setting.Add(new ClientSetting() { LocalPort=1, ConnectedPort = 8088, Name = "text" });
        }

        private void InitializeClient()
        {
            clientList.Clear();
            foreach (ClientSetting item in config.Setting)
            {
                SeeSharpTools.JY.Remoting.Common.Client client=new SeeSharpTools.JY.Remoting.Common.Client(item);
                clientList.Add(client);
                client.ServerDisconnectionEvent += Client_ServerDisconnectionEvent;
                client.Start();
            }
        }

        private void Client_ServerDisconnectionEvent(object sender, EventArgs e)
        {
            MessageBox.Show("服务器断线");
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitializeClient();
            timer1.Start();
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
                    led1.Value = (bool)clientList[0].ReadData();

                }
                if (clientList[1].IsDataUpdated)
                {
                    textBox2.Text = clientList[1].ReadData().ToString();
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

        private void button3_Click(object sender, EventArgs e)
        {
            clientList[1].WriteData(textBox1.Text);
        }

        private void buttonSwitch1_ValueChanged(object sender, EventArgs e)
        {
            led1.Value = buttonSwitch1.Value;
            clientList[0].WriteData(buttonSwitch1.Value);
        }
    }
}