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
    public partial class SchedulePage : UserControl
    {
        private TcpClient tcpClient { get; set; }

        public SchedulePage(TcpClient client)
        {
            InitializeComponent();
            comboBox1.Items.Add("понедельник");
            comboBox1.Items.Add("вторник");
            comboBox1.Items.Add("среда");
            comboBox1.Items.Add("четверг");
            comboBox1.Items.Add("пятница");
            comboBox1.Items.Add("суббота");
            comboBox1.Items.Add("воскресенье");
            tcpClient = client;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GetScheduleData();
        }

        private void GetScheduleData()
        {
            try
            {
                NetworkStream stream = tcpClient.GetStream();
                Request request = new Request();
                request.Data = new List<String>();
                request.Data.Add(comboBox1.SelectedItem.ToString());
                request.Type = 3;
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, request);
                List<Schedule> answer = (List<Schedule>)formatter.Deserialize(stream);
                if (answer != null)
                {
                    int i;
                    foreach (Schedule elem in answer)
                    {
                        i = dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells["Time_Start"].Value = elem.TimeStart;
                        dataGridView1.Rows[i].Cells["Time_End"].Value = elem.TimeEnd;
                        dataGridView1.Rows[i].Cells["Subject"].Value = elem.Subject;
                        dataGridView1.Rows[i].Cells["Group"].Value = elem.Group;
                        dataGridView1.Rows[i].Cells["Cabinet"].Value = elem.Cabinet;
                    }
                }
            }
            catch
            {

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
