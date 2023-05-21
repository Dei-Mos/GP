using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.Data.SqlClient;

namespace ServerGP
{
    class ConnectListener
    {
        private static int Port { get; set; }

        public static void Listen(SqlConnection connectionSQL)
        {
            TcpListener listener = null;
            Port = 56789;
            try
            {
                listener = new TcpListener(IPAddress.Any, Port);
                listener.Start();
                while(true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    ClientRequest request = new ClientRequest(client);
                    Thread clientThread = new Thread(()=>request.Process(connectionSQL));
                    clientThread.Start();
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            finally
            {
                if (listener != null)
                    listener.Stop();
            }
        }
    }
}
