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
    public partial class ProgressPage : UserControl
    {
        private TcpClient Client { get; set; }

        public ProgressPage(TcpClient client)
        {
            InitializeComponent();
            Client = client;
            LoadTable();
        }

        private void LoadTable()
        {
            try
            {
                NetworkStream stream = Client.GetStream();
                Request request = new Request();
                request.Data = new List<String>();
                request.Type = 7;
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, request);
                List<Progress> answer = (List<Progress>)formatter.Deserialize(stream);
                if (answer != null)
                {
                    if (answer.Count > 0)
                    {
                        int i;
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
