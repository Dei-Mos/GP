using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using Client_Server;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClientGP
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();
        private TcpClient Client { get; set; }
        private bool Minimized;
        private int UserType {get;set;}
        public Form1(TcpClient client)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
            t.Interval = 2;
            t.Tick += new EventHandler(timer_Tick);
            this.SizeChanged += new EventHandler(this_SizeChanged);
            t1.Interval = 1;
            t1.Tick += new EventHandler(timer1_Tick);
            t1.Start();
            Client = client;
        }

        private void this_SizeChanged(object source, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                Minimized = false;
            }
        }

        private void timer_Tick(object source, EventArgs e)
        {
            this.Height = this.Height - 12;
            if (this.Height <= 39)
            {
                t.Stop();
                t.Enabled = false;
                this.WindowState = FormWindowState.Minimized;
                Minimized = true;
            }
        }

        private void timer1_Tick(object source, EventArgs e)
        {
            if (Minimized == false && t.Enabled == false)
            {
                this.Height = 600;
            }
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

        private void Key1_Pressed(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
            {
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(255, 246, 180);
        }

        private void pictureBox1_MouseLeaved(object sender, EventArgs e)
        {
            pictureBox1.BackColor = this.BackColor;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            t.Start();
        }

        private void pictureBox2_MouseMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(255, 246, 180);
        }

        private void pictureBox2_MouseLeaved(object sender, EventArgs e)
        {
            pictureBox2.BackColor = this.BackColor;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            TabsControl tab = new TabsControl(this);
            panel1.Controls.Add(tab);
            panel1.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel2.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            WelcomePage page = new WelcomePage(Client);
            panel3.Controls.Add(page);
            panel3.Show();
        }

        public void panel3_Profile()
        {
            ProfilePage page = new ProfilePage(Client);
            panel3.Controls.Clear();
            panel3.Controls.Add(page);
            panel3.Show();
        }

        public void panel3_Schedule()
        {
            SchedulePage page = new SchedulePage(Client);
            panel3.Controls.Clear();
            panel3.Controls.Add(page);
            panel3.Show();
        }

        public void panel3_Cirriculum()
        {
            CirriculumPage page = new CirriculumPage(Client);
            panel3.Controls.Clear();
            panel3.Controls.Add(page);
            panel3.Show();
        }
        public void panel3_Progress()
        {
            GetUserType();
            panel3.Controls.Clear();
            if (UserType == 0)
            {
                ProgressPage page = new ProgressPage(Client);
                panel3.Controls.Add(page);
            }
            else
            {
                ProgressPage_2 page = new ProgressPage_2(Client);
                panel3.Controls.Add(page);
            }
            panel3.Show();
        }

        private void GetUserType()
        {
            try
            {
                NetworkStream stream = Client.GetStream();
                Request request = new Request();
                request.Data = new List<String>();
                request.Type = 6;
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, request);
                String answer = (String)formatter.Deserialize(stream);
                if (answer != null)
                {
                    if (answer.Equals("Student"))
                        UserType = 0;
                    else
                        UserType = 1;
                }
            }
            catch
            {

            }
        }
    }
}
