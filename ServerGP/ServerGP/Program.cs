using System;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;
using System.Text.Json;
using System.IO;

namespace ServerGP
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string path = @"MyTest.txt";
            string connectionString = null;
            int i = 0;
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    connectionString += s;
                }
            }
            
            if (connectionString != null)
            {
                Console.WriteLine(connectionString);
                SqlConnection connectionSQL = new SqlConnection(connectionString);
                try
                {
                    await connectionSQL.OpenAsync();
                    ConnectListener.Listen(connectionSQL);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (connectionSQL.State == System.Data.ConnectionState.Open)
                    {
                        await connectionSQL.CloseAsync();
                        Console.WriteLine("Подключение закрыто");
                    }
                }
            }
            Console.WriteLine("connectionString error");
            //Console.Read();
        }
    }
}
