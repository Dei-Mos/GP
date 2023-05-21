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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Client_Server;

namespace ClientGP
{
    public partial class ProgressPage_2 : UserControl
    {
        private TcpClient Client { get; set; }

        public ProgressPage_2(TcpClient client)
        {
            InitializeComponent();
            Client = client;
            LoadCourse();
        }

        private void LoadCourse()
        {
            try
            {
                NetworkStream stream = Client.GetStream();
                Request request = new Request();
                request.Data = new List<String>();
                request.Type = 8;
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, request);
                List<String> answer = (List<String>)formatter.Deserialize(stream);
                if (answer != null)
                {
                    int i;
                    foreach (String elem in answer)
                        comboBox1.Items.Add(elem);
                }
            }
            catch
            {

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            comboBox2.Enabled = true;
            if (dataGridView1.Rows.Count > 0)
                dataGridView1.Rows.Clear();
            Error.Visible = false;
            LoadGroup();
        }

        private void LoadGroup()
        {
            try
            {
                NetworkStream stream = Client.GetStream();
                Request request = new Request();
                request.Data = new List<String>();
                request.Data.Add(comboBox1.SelectedItem.ToString());
                request.Type = 9;
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, request);
                List<String> answer = (List<String>)formatter.Deserialize(stream);
                if (answer != null)
                {
                    int i;
                    foreach (String elem in answer)
                        comboBox2.Items.Add(elem);
                }
            }
            catch
            {

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
                dataGridView1.Rows.Clear();
            Error.Visible = false;
            LoadTable();
        }

        private void LoadTable()
        {
            try
            {
                NetworkStream stream = Client.GetStream();
                Request request = new Request();
                request.Data = new List<String>();
                request.Data.Add(comboBox1.SelectedItem.ToString());
                request.Data.Add(comboBox2.SelectedItem.ToString());
                request.Type = 10;
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, request);
                List<Progress> answer = (List<Progress>)formatter.Deserialize(stream);
                if (answer != null)
                {

                    if (answer.Count > 0)
                    {
                        int i = 0;
                        foreach (Progress elem in answer)
                        {
                            i = dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells[0].Value = elem.Name;
                            dataGridView1.Rows[i].Cells[1].Value = elem.Grade;
                            dataGridView1.Rows[i].Cells[2].Value = elem.Date;
                        }
                    }                        
                    else
                        Error.Visible = true;
                }
            }
            catch
            {

            }
        }
    }
}
