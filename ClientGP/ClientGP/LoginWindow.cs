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
using System.Net;
using Client_Server;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClientGP
{
    public partial class LoginWindow : Form
    {
        private Form1 MainWindow { get; set; }
        private int Port { get; set; }
        private string IPAddress { get; set; }

        private TcpClient Client { get; set; }

        private int Spins { get; set; }
        private Timer PictureTimer { get; set; }

        public LoginWindow()
        {
            InitializeComponent();
            Port = 56789;
            IPAddress = "127.0.0.1";
            Client = null;
            PictureTimer = new Timer();
            PictureTimer.Tick += new EventHandler(ChangeRefreshPicture);
            PictureTimer.Interval = 150;
            Connect();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Authorize()
        {
            try
            {
                NetworkStream stream = Client.GetStream();
                Request request = new Request();
                request.Data = new List<String>();
                request.Data.Add(textBox1.Text);
                request.Data.Add(textBox2.Text);
                request.Type = 0;
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, request);
                Request answer = (Request)formatter.Deserialize(stream);
                if (answer.Data != null || answer.Type != -1)
                {
                    if (answer.Type == 100 && answer.Data[0].Equals("1"))
                    {
                        MainWindow = new Form1(Client);
                        MainWindow.ShowDialog();
                    }
                    else
                        label6.Visible = true;
                }
                else
                    label6.Visible = true;
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Visible = false;
            label8.Visible = false;
            if (Client != null)
            {
                Task task = new Task(Authorize, TaskCreationOptions.LongRunning);
                task.Start();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar)
            {
                textBox2.UseSystemPasswordChar = false;
                pictureBox2.Image = ClientGP.Properties.Resources.close_eyes;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                pictureBox2.Image = ClientGP.Properties.Resources.view;
            }
        }

        private void LoginWindow_Load(object sender, EventArgs e)
        {

        }

        private bool Connect()
        {
            try
            {
                Client = new TcpClient(IPAddress, Port);
            }
            catch (Exception ex)
            {
                label7.Visible = true;
                Client = null;
                return (false);
            }
            return (true);
        }

        private void ChangeRefreshPicture(object sender, EventArgs e)
        {
            if (Spins > 3)
                Spins = 0;
            switch (Spins)
            {
                case 0:
                    refreshPicture.Image = ClientGP.Properties.Resources.refresh1;
                    break;
                case 1:
                    refreshPicture.Image = ClientGP.Properties.Resources.refresh2;
                    break;
                case 2:
                    refreshPicture.Image = ClientGP.Properties.Resources.refresh3;
                    break;
                case 3:
                    refreshPicture.Image = ClientGP.Properties.Resources.refresh0;
                    break;
                default:
                    PictureTimer.Stop();
                    break;
            }
            ++Spins;
        }

        private void refresh_MouseMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            refreshPicture.BackColor = Color.FromArgb(255, 246, 180);
            if (!PictureTimer.Enabled)
            {
                Spins = 0;
                PictureTimer.Start();
            }
        }

        private void refresh_MouseLeaved(object sender, EventArgs e)
        {
            Spins = -1;
            refreshPicture.BackColor = this.BackColor;
        }

        private void exit_MouseMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(255, 246, 180);
        }

        private void exit_MouseLeaved(object sender, EventArgs e)
        {
            pictureBox1.BackColor = this.BackColor;
        }

        private void eye_MouseMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(255, 246, 180);
        }

        private void eye_MouseLeaved(object sender, EventArgs e)
        {
            pictureBox2.BackColor = this.BackColor;
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
            if (Client == null)
            {
                if (Connect())
                    label7.Visible = false;
                else
                    label7.Visible = true;
            }
                
        }
    }
}
