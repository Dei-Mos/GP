
namespace ClientGP
{
    partial class TabsControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabsControl));
            this.schedule = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.Label();
            this.cirriculum = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picture_Profile = new System.Windows.Forms.PictureBox();
            this.picture_Cirriculum = new System.Windows.Forms.PictureBox();
            this.picture_Progress = new System.Windows.Forms.PictureBox();
            this.profile = new System.Windows.Forms.Label();
            this.picture_Schedule = new System.Windows.Forms.PictureBox();
            this.signOut = new System.Windows.Forms.Label();
            this.signOutPicture = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Profile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Cirriculum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Progress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Schedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signOutPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // schedule
            // 
            this.schedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.schedule.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.schedule.Location = new System.Drawing.Point(0, 90);
            this.schedule.Name = "schedule";
            this.schedule.Size = new System.Drawing.Size(174, 90);
            this.schedule.TabIndex = 1;
            this.schedule.Text = "             Расписание";
            this.schedule.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.schedule.Click += new System.EventHandler(this.schedule_Click);
            this.schedule.Paint += new System.Windows.Forms.PaintEventHandler(this.schedule_Paint);
            this.schedule.MouseLeave += new System.EventHandler(this.schedule_MouseLeaved);
            this.schedule.MouseMove += new System.Windows.Forms.MouseEventHandler(this.schedule_MouseMoved);
            // 
            // progress
            // 
            this.progress.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.progress.Location = new System.Drawing.Point(0, 180);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(174, 90);
            this.progress.TabIndex = 2;
            this.progress.Text = "                Успеваемость";
            this.progress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.progress.Click += new System.EventHandler(this.progress_Click);
            this.progress.Paint += new System.Windows.Forms.PaintEventHandler(this.progress_Paint);
            this.progress.MouseLeave += new System.EventHandler(this.progress_MouseLeaved);
            this.progress.MouseMove += new System.Windows.Forms.MouseEventHandler(this.progress_MouseMoved);
            // 
            // cirriculum
            // 
            this.cirriculum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.cirriculum.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cirriculum.Location = new System.Drawing.Point(0, 270);
            this.cirriculum.Name = "cirriculum";
            this.cirriculum.Size = new System.Drawing.Size(174, 90);
            this.cirriculum.TabIndex = 3;
            this.cirriculum.Text = "                Учебный план";
            this.cirriculum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cirriculum.Click += new System.EventHandler(this.cirriculum_Click);
            this.cirriculum.Paint += new System.Windows.Forms.PaintEventHandler(this.cirriculum_Paint);
            this.cirriculum.MouseLeave += new System.EventHandler(this.cirriculum_MouseLeaved);
            this.cirriculum.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cirriculum_MouseMoved);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.picture_Profile);
            this.panel1.Controls.Add(this.picture_Cirriculum);
            this.panel1.Controls.Add(this.picture_Progress);
            this.panel1.Controls.Add(this.profile);
            this.panel1.Controls.Add(this.picture_Schedule);
            this.panel1.Controls.Add(this.cirriculum);
            this.panel1.Controls.Add(this.schedule);
            this.panel1.Controls.Add(this.progress);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(174, 360);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(159, 271);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(15, 88);
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.pictureBox3.Location = new System.Drawing.Point(159, 181);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(15, 88);
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(159, 91);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(15, 88);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.pictureBox1.Location = new System.Drawing.Point(159, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 88);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // picture_Profile
            // 
            this.picture_Profile.Image = ((System.Drawing.Image)(resources.GetObject("picture_Profile.Image")));
            this.picture_Profile.Location = new System.Drawing.Point(15, 26);
            this.picture_Profile.Name = "picture_Profile";
            this.picture_Profile.Size = new System.Drawing.Size(40, 40);
            this.picture_Profile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_Profile.TabIndex = 4;
            this.picture_Profile.TabStop = false;
            this.picture_Profile.Click += new System.EventHandler(this.profile_Click);
            this.picture_Profile.MouseLeave += new System.EventHandler(this.profile_MouseLeaved);
            this.picture_Profile.MouseMove += new System.Windows.Forms.MouseEventHandler(this.profile_MouseMoved);
            // 
            // picture_Cirriculum
            // 
            this.picture_Cirriculum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.picture_Cirriculum.Image = ((System.Drawing.Image)(resources.GetObject("picture_Cirriculum.Image")));
            this.picture_Cirriculum.Location = new System.Drawing.Point(15, 294);
            this.picture_Cirriculum.Name = "picture_Cirriculum";
            this.picture_Cirriculum.Size = new System.Drawing.Size(40, 40);
            this.picture_Cirriculum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_Cirriculum.TabIndex = 7;
            this.picture_Cirriculum.TabStop = false;
            this.picture_Cirriculum.Click += new System.EventHandler(this.cirriculum_Click);
            this.picture_Cirriculum.MouseLeave += new System.EventHandler(this.cirriculum_MouseLeaved);
            this.picture_Cirriculum.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cirriculum_MouseMoved);
            // 
            // picture_Progress
            // 
            this.picture_Progress.Image = ((System.Drawing.Image)(resources.GetObject("picture_Progress.Image")));
            this.picture_Progress.Location = new System.Drawing.Point(15, 206);
            this.picture_Progress.Name = "picture_Progress";
            this.picture_Progress.Size = new System.Drawing.Size(40, 40);
            this.picture_Progress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_Progress.TabIndex = 6;
            this.picture_Progress.TabStop = false;
            this.picture_Progress.Click += new System.EventHandler(this.progress_Click);
            this.picture_Progress.MouseLeave += new System.EventHandler(this.progress_MouseLeaved);
            this.picture_Progress.MouseMove += new System.Windows.Forms.MouseEventHandler(this.progress_MouseMoved);
            // 
            // profile
            // 
            this.profile.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.profile.Location = new System.Drawing.Point(0, 0);
            this.profile.Name = "profile";
            this.profile.Size = new System.Drawing.Size(174, 90);
            this.profile.TabIndex = 0;
            this.profile.Text = "        Профиль";
            this.profile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.profile.Click += new System.EventHandler(this.profile_Click);
            this.profile.Paint += new System.Windows.Forms.PaintEventHandler(this.profile_Paint);
            this.profile.MouseLeave += new System.EventHandler(this.profile_MouseLeaved);
            this.profile.MouseMove += new System.Windows.Forms.MouseEventHandler(this.profile_MouseMoved);
            // 
            // picture_Schedule
            // 
            this.picture_Schedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.picture_Schedule.Image = ((System.Drawing.Image)(resources.GetObject("picture_Schedule.Image")));
            this.picture_Schedule.Location = new System.Drawing.Point(15, 114);
            this.picture_Schedule.Name = "picture_Schedule";
            this.picture_Schedule.Size = new System.Drawing.Size(40, 40);
            this.picture_Schedule.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_Schedule.TabIndex = 5;
            this.picture_Schedule.TabStop = false;
            this.picture_Schedule.Click += new System.EventHandler(this.schedule_Click);
            this.picture_Schedule.MouseLeave += new System.EventHandler(this.schedule_MouseLeaved);
            this.picture_Schedule.MouseMove += new System.Windows.Forms.MouseEventHandler(this.schedule_MouseMoved);
            // 
            // signOut
            // 
            this.signOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.signOut.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.signOut.Location = new System.Drawing.Point(1, 461);
            this.signOut.Name = "signOut";
            this.signOut.Size = new System.Drawing.Size(174, 89);
            this.signOut.TabIndex = 11;
            this.signOut.Text = "        Выйти";
            this.signOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.signOut.Click += new System.EventHandler(this.signOut_Click);
            this.signOut.Paint += new System.Windows.Forms.PaintEventHandler(this.signOut_Paint);
            this.signOut.MouseLeave += new System.EventHandler(this.signOut_MouseLeaved);
            this.signOut.MouseMove += new System.Windows.Forms.MouseEventHandler(this.signOut_MouseMoved);
            // 
            // signOutPicture
            // 
            this.signOutPicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.signOutPicture.Image = ((System.Drawing.Image)(resources.GetObject("signOutPicture.Image")));
            this.signOutPicture.Location = new System.Drawing.Point(15, 486);
            this.signOutPicture.Name = "signOutPicture";
            this.signOutPicture.Size = new System.Drawing.Size(40, 40);
            this.signOutPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.signOutPicture.TabIndex = 12;
            this.signOutPicture.TabStop = false;
            this.signOutPicture.Click += new System.EventHandler(this.signOut_Click);
            this.signOutPicture.MouseLeave += new System.EventHandler(this.signOut_MouseLeaved);
            this.signOutPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.signOut_MouseMoved);
            // 
            // TabsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(151)))), ((int)(((byte)(108)))));
            this.Controls.Add(this.signOutPicture);
            this.Controls.Add(this.signOut);
            this.Controls.Add(this.panel1);
            this.Name = "TabsControl";
            this.Size = new System.Drawing.Size(174, 551);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TabsControl_Paint);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Profile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Cirriculum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Progress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Schedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.signOutPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label schedule;
        private System.Windows.Forms.Label progress;
        private System.Windows.Forms.Label cirriculum;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picture_Cirriculum;
        private System.Windows.Forms.PictureBox picture_Progress;
        private System.Windows.Forms.PictureBox picture_Schedule;
        private System.Windows.Forms.PictureBox picture_Profile;
        private System.Windows.Forms.Label profile;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label signOut;
        private System.Windows.Forms.PictureBox signOutPicture;
    }
}
