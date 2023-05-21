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
    public partial class ProfilePage : UserControl
    {
        private bool Picture1_Edit { get; set; }
        private bool Picture2_Edit { get; set; }

        private TcpClient tcpClient { get; set; }
        public ProfilePage(TcpClient client)
        {
            InitializeComponent();
            Picture1_Edit = false;
            Picture2_Edit = false;
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
                request.Type = 2;
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, request);
                Profile answer = (Profile)formatter.Deserialize(stream);
                if (answer != null)
                {
                    textBox1.Text = answer.Name;
                    textBox2.Text = answer.Date;
                    textBox3.Text = answer.Mail;
                    textBox4.Text = answer.Number;
                    textBox5.Text = answer.GroupPost;
                    if (answer.UserType == "0")
                        label6.Text = "Должность";
                    else
                        label6.Text = "Группа";
                }
            }
            catch
            {

            }
        }

        private void SaveData()
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Picture1_Edit)
            {
                Picture1_Edit = false;
                SaveData();
                textBox3.ReadOnly = true;
                pictureBox1.Image = ClientGP.Properties.Resources.pen_1_;
                
            }
            else
            {
                Picture1_Edit = true;
                textBox3.ReadOnly = false;
                pictureBox1.Image = ClientGP.Properties.Resources.tick_1_;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Picture2_Edit)
            {
                Picture2_Edit = false;
                SaveData();
                textBox4.ReadOnly = true;
                pictureBox2.Image = ClientGP.Properties.Resources.pen_1_;
                
            }
            else
            {
                Picture2_Edit = true;
                textBox4.ReadOnly = false;
                pictureBox2.Image = ClientGP.Properties.Resources.tick_1_;
            }
        }
    }
}
