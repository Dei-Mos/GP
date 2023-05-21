using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientGP
{
    public partial class TabsControl : UserControl
    {
        private Color ProfileColor { get; set; }
        private Color ScheduleColor { get; set; }
        private Color ProgressColor { get; set; }
        private Color CirriculumColor { get; set; }
        private Color SignOutColor { get; set; }

        private int ActiveTab { get; set; }

        private Form1 MainWindow { get; set; }

        public TabsControl(Form1 window)
        {
            InitializeComponent();
            ProfileColor = profile.BackColor;
            ScheduleColor = schedule.BackColor;
            ProgressColor = progress.BackColor;
            CirriculumColor = cirriculum.BackColor;
            SignOutColor = signOut.BackColor;
            MainWindow = window;
            ActiveTab = 4;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void SetDefaultTab()
        {
            switch(ActiveTab)
            {
                case 0:
                    pictureBox1.Visible = false;
                    break;
                case 1:
                    pictureBox2.Visible = false;
                    break;
                case 2:
                    pictureBox3.Visible = false;
                    break;
                case 3:
                    pictureBox4.Visible = false;
                    break;
                default:
                    break;
            }
        }

        private void profile_Click(object sender, EventArgs e)
        {
            MainWindow.panel3_Profile();
            SetDefaultTab();
            pictureBox1.Visible = true;
            ActiveTab = 0;
        }

        private void TabsControl_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void profile_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, profile.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void schedule_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, schedule.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void progress_Paint(object sender, PaintEventArgs e)
        {
           ControlPaint.DrawBorder(e.Graphics, progress.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void cirriculum_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, cirriculum.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }
        private void signOut_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, signOut.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void profile_MouseMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            profile.BackColor = Color.FromArgb(255, 183, 150);
            picture_Profile.BackColor = Color.FromArgb(255, 183, 150);
        }

        private void profile_MouseLeaved(object sender, EventArgs e)
        {
            profile.BackColor = ProfileColor;
            picture_Profile.BackColor = ProfileColor;
        }
        private void schedule_MouseMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            schedule.BackColor = Color.FromArgb(205, 249, 255);
            picture_Schedule.BackColor = Color.FromArgb(205, 249, 255);
        }

        private void schedule_MouseLeaved(object sender, EventArgs e)
        {
            schedule.BackColor = ScheduleColor;
            picture_Schedule.BackColor = ScheduleColor;
        }
        private void progress_MouseMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            progress.BackColor = Color.FromArgb(255, 183, 150);
            picture_Progress.BackColor = Color.FromArgb(255, 183, 150);
        }

        private void progress_MouseLeaved(object sender, EventArgs e)
        {
            progress.BackColor = ProgressColor;
            picture_Progress.BackColor = ProgressColor;
        }
        private void cirriculum_MouseMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            cirriculum.BackColor = Color.FromArgb(205, 249, 255);
            picture_Cirriculum.BackColor = Color.FromArgb(205, 249, 255);
        }

        private void cirriculum_MouseLeaved(object sender, EventArgs e)
        {
            cirriculum.BackColor = CirriculumColor;
            picture_Cirriculum.BackColor = CirriculumColor;
        }

        private void signOut_MouseMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            signOut.BackColor = Color.FromArgb(205, 249, 255);
            signOutPicture.BackColor = Color.FromArgb(205, 249, 255);
        }

        private void signOut_MouseLeaved(object sender, EventArgs e)
        {
            signOut.BackColor = SignOutColor;
            signOutPicture.BackColor = SignOutColor;
        }

        private void schedule_Click(object sender, EventArgs e)
        {
            MainWindow.panel3_Schedule();
            SetDefaultTab();
            pictureBox2.Visible = true;
            ActiveTab = 1;
        }

        private void progress_Click(object sender, EventArgs e)
        {
            MainWindow.panel3_Progress();
            SetDefaultTab();
            pictureBox3.Visible = true;
            ActiveTab = 2;
        }

        private void cirriculum_Click(object sender, EventArgs e)
        {
            MainWindow.panel3_Cirriculum();
            SetDefaultTab();
            pictureBox4.Visible = true;
            ActiveTab = 3;
        }

        private void signOut_Click(object sender, EventArgs e)
        {
            MainWindow.Close();
        }
    }
}
