using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Net.Sockets;
using Client_Server;

namespace ClientGP
{
    public partial class CirriculumPage : UserControl
    {
        private TcpClient tcpClient { get; set; }

        public CirriculumPage(TcpClient client)
        {
            InitializeComponent();
            tcpClient = client;
            GetCourses();
        }

        private void GetCourses()
        {
            try
            {
                NetworkStream stream = tcpClient.GetStream();
                Request request = new Request();
                request.Data = new List<String>();
                request.Type = 4;
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, request);
                List<String> answer = (List<String>)formatter.Deserialize(stream);
                if (answer != null)
                    foreach (String elem in answer)
                        listBox1.Items.Add(elem);
            }
            catch
            {

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = "";
                textBox2.Text = "";
                NetworkStream stream = tcpClient.GetStream();
                Request request = new Request();
                request.Data = new List<String>();
                request.Data.Add(listBox1.SelectedItem.ToString());
                request.Type = 5;
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, request);
                List<String> answer = (List<String>)formatter.Deserialize(stream);
                if (answer != null)
                {
                    textBox1.Text = answer[0];
                    textBox2.Text = answer[1];
                }
            }
            catch
            {

            }
        }
    }
}
