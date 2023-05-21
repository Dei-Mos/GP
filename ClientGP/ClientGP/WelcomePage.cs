using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using Client_Server;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClientGP
{
    
    public partial class WelcomePage : UserControl
    {
        private TcpClient tcpClient { get; set; }
        public WelcomePage(TcpClient client)
        {
            InitializeComponent();
            tcpClient = client;
            GetProfileData();

        }

        private void GetProfileData()
        {
            try
            {
                NetworkStream stream = tcpClient.GetStream();
                Request request = new Request();
                request.Data = new List<String>();
                request.Type = 1;
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, request);
                Request answer = (Request)formatter.Deserialize(stream);
                if (answer.Data != null || answer.Type != -1)
                {
                    if (answer.Type == 101 && answer.Data.Count > 0)
                    {
                        label2.Text = answer.Data[0];
                    }
                }
            }
            catch
            {

            }
        }

        private void WelcomePage_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
