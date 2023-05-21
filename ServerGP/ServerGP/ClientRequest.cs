using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Client_Server;
using Microsoft.Data.SqlClient;

namespace ServerGP
{
    class ClientRequest
    {
        private TcpClient R_Client { get; set; }
        public ClientRequest(TcpClient client)
        {
            R_Client = client;
        }
        public void Process(SqlConnection connectionSQL)
        {
            NetworkStream stream = null;
            String login = null;
            Console.WriteLine("Пользователь подключился");
            try
            {
                Request request;
                stream = R_Client.GetStream();
                IFormatter formatter = new BinaryFormatter();
                while (true)
                {
                    request = (Request)formatter.Deserialize(R_Client.GetStream());
                    Console.Write("Получено: Тип - " + request.Type.ToString() + ", Информация - ");
                    foreach (String elem in request.Data)
                        Console.Write(elem + " ");
                    Console.WriteLine();
                    if (request.Data != null || request.Type != -1)
                        ProcessRequest(request, connectionSQL, ref login);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }

        private void ProcessRequest(Request req, SqlConnection connectionSQL, ref String login)
        {
            switch (req.Type)
            {
                case 0:
                    ExecuteCode0(req, connectionSQL, ref login);
                    break;
                case 1:
                    ExecuteCode1(req, connectionSQL, ref login);
                    break;
                case 2:
                    ExecuteCode2(req, connectionSQL, ref login);
                    break;
                case 3:
                    ExecuteCode3(req, connectionSQL, ref login);
                    break;
                case 4:
                    ExecuteCode4(req, connectionSQL, ref login);
                    break;
                case 5:
                    ExecuteCode5(req, connectionSQL, ref login);
                    break;
                case 6:
                    ExecuteCode6(req, connectionSQL, ref login);
                    break;
                case 7:
                    ExecuteCode7(req, connectionSQL, ref login);
                    break;
                case 8:
                    ExecuteCode8(req, connectionSQL, ref login);
                    break;
                case 9:
                    ExecuteCode9(req, connectionSQL, ref login);
                    break;
                case 10:
                    ExecuteCode10(req, connectionSQL, ref login);
                    break;
                default:
                    break;
            }
        }
        private void ExecuteCode0(Request req, SqlConnection connectionSQL, ref String login)
        {
            string sqlExpr;
            SqlCommand command;
            IFormatter formatter = new BinaryFormatter();
            Request request = new Request();
            SqlDataReader reader;

            request.Type = 100;
            request.Data = new List<string>();
            sqlExpr = "SELECT * FROM Авторизация WHERE Логин='" + req.Data[0] + "' AND Пароль='" + req.Data[1] + "'";
            command = new SqlCommand(sqlExpr, connectionSQL);
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                login = req.Data[0];
                request.Data.Add("1");
            }
            else
                request.Data.Add("0");
            reader.Close();
            formatter.Serialize(R_Client.GetStream(), request);
            Console.WriteLine("Отправлено: Тип - " + request.Type.ToString() + ", Информация - " + request.Data[0]);
        }

        private void ExecuteCode1(Request req, SqlConnection connectionSQL, ref String login)
        {
            string sqlExpr;
            SqlCommand command;
            IFormatter formatter = new BinaryFormatter();
            Request request = new Request();
            SqlDataReader reader;

            request.Type = 101;
            request.Data = new List<string>();
            String sqlExpr1 = "Select * from НПР where (Логин = '" + login + "')";
            command = new SqlCommand(sqlExpr1, connectionSQL);
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                Console.WriteLine("Логин - " + login);
                sqlExpr = "declare @name1[varchar](100) \n declare @name2[varchar](100) \n declare @name1_1[varchar](100) \n" +
                        "declare @name1_2[varchar](100) \n set @name1 = (SELECT ФИО_НПР from dbo.НПР where Логин='" + login + "') \n" +
                        "set @name2 = 'hello' \n exec dbo.DeCipher1 @name1, @name2, @name1_1 output, @name1_2 output \n" +
                        "select @name1_1 as ФИО_НПР from dbo.НПР where Логин='" + login + "'";
                command = new SqlCommand(sqlExpr, connectionSQL);
                reader = command.ExecuteReader();
                if (reader.Read())
                    request.Data.Add(reader.GetString(0));
            }
            else
            {
                reader.Close();
                sqlExpr = "SELECT ФИО_обчающегося from Обучающийся where (Логин = '" + login + "')";
                command = new SqlCommand(sqlExpr, connectionSQL);
                reader = command.ExecuteReader();
                if (reader.Read())
                    request.Data.Add(reader.GetString(0));
            }
            reader.Close();
            formatter.Serialize(R_Client.GetStream(), request);
            Console.WriteLine("Отправлено: Тип - " + request.Type.ToString() + ", Информация - " + request.Data[0]);
        }

        private void ExecuteCode2(Request req, SqlConnection connectionSQL, ref String login)
        {
            string sqlExpr;
            SqlCommand command;
            IFormatter formatter = new BinaryFormatter();
            Profile profile = new Profile();
            SqlDataReader reader;

            String sqlExpr1 = "Select * from НПР where (Логин = '" + login + "')";
            command = new SqlCommand(sqlExpr1, connectionSQL);
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                Console.WriteLine("Логин - " + login);
                sqlExpr = "declare @name1[varchar](100) \n declare @name2[varchar](100) \n declare @name1_1[varchar](100) \n" +
                        "declare @name1_2[varchar](100) \n set @name1 = (SELECT ФИО_НПР from dbo.НПР where Логин='" + login + "') \n" +
                        "set @name2 = (SELECT ДолжностьНПР from dbo.НПР where Логин='" + login + "') \n exec dbo.DeCipher1 @name1, @name2, @name1_1 output, @name1_2 output \n" +
                        "select @name1_1 as ФИО_НПР, ДатаРожденияНПР, ТелефонНПР, ПочтаНПР, @name1_2 as ДолжностьНПР from dbo.НПР where Логин='" + login + "'";
                command = new SqlCommand(sqlExpr, connectionSQL);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    profile.UserType = "0";
                    profile.Name = reader.GetString(0);
                    profile.Date = reader.GetDateTime(1).ToShortDateString();
                    profile.Mail = reader.GetString(2);
                    profile.Number = reader.GetString(3);
                    profile.GroupPost = reader.GetString(4);
                }
            }
            else
            {
                reader.Close();
                sqlExpr = "SELECT ФИО_обчающегося, ДатаРожденияОбучающегося, ТелефонОбучающегося, ПочтаОбучающегося, КодГруппы from Обучающийся where (Логин = '" + login + "')";
                command = new SqlCommand(sqlExpr, connectionSQL);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    profile.UserType = "1";
                    profile.Name = reader.GetString(0);
                    profile.Date = reader.GetDateTime(1).ToShortDateString();
                    profile.Mail = reader.GetString(2);
                    profile.Number = reader.GetString(3);
                    profile.GroupPost = reader.GetString(4);
                }
            }
            reader.Close();
            formatter.Serialize(R_Client.GetStream(), profile);
            Console.WriteLine("Отправлено: Тип - " + profile.UserType + ", Информация - " + profile.Name);
        }

        private void ExecuteCode3(Request req, SqlConnection connectionSQL, ref String login)
        {
            string sqlExpr;
            SqlCommand command;
            IFormatter formatter = new BinaryFormatter();
            List<Schedule> listSchedule = new List<Schedule>();
            SqlDataReader reader;

            String sqlExpr1 = "Select * from НПР where (Логин = '" + login + "')";
            command = new SqlCommand(sqlExpr1, connectionSQL);
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                Console.WriteLine("НПР Логин - " + login + " День - " + req.Data[0]);
                sqlExpr = "declare @name1[varchar](100) declare @name2 int set @name1 = (SELECT ИД_НПР from dbo.НПР where Логин='" + login + "') \n" +
                        "set @name2 = (SELECT КодДняНед from День_недели where НаменДняНед='" + req.Data[0] + "')" +
                        "select КодВрЗанятия, КодКурса, НомерКабинета, КодГруппы from Расписание where (ИД_НПР=@name1 AND КодДняНед=@name2) order by КодВрЗанятия";
                command = new SqlCommand(sqlExpr, connectionSQL);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Schedule schedule = new Schedule();
                    String sqlExpr2 = "select ВремяНачала, ВремяОкончания from Время_Занятия where КодВрЗанятия=" + reader.GetInt32(0).ToString();
                    SqlCommand command2 = new SqlCommand(sqlExpr2, connectionSQL);
                    SqlDataReader reader2 = command2.ExecuteReader();
                    if (reader2.Read())
                    {
                        schedule.TimeStart = reader2.GetTimeSpan(0).ToString();
                        schedule.TimeEnd = reader2.GetTimeSpan(1).ToString();
                    }
                    reader2.Close();
                    sqlExpr2 = "select НазваниеКурса from Курс where КодКурса=" + reader.GetInt32(1).ToString();
                    command2 = new SqlCommand(sqlExpr2, connectionSQL);
                    reader2 = command2.ExecuteReader();
                    if (reader2.Read())
                        schedule.Subject = reader2.GetString(0);
                    reader2.Close();
                    schedule.Cabinet = reader.GetString(2);
                    schedule.Group = reader.GetString(3);
                    listSchedule.Add(schedule);
                }
            }
            else
            {
                reader.Close();
                Console.WriteLine("Обучающийся Логин - " + login + " День - " + req.Data[0]);
                sqlExpr = "declare @name1[varchar](100) declare @name2 int set @name1 = (SELECT КодГруппы from Обучающийся where Логин='" + login + "') \n" +
                        "set @name2 = (SELECT КодДняНед from День_недели where НаменДняНед='" + req.Data[0] + "')" +
                        "select КодВрЗанятия, КодКурса, НомерКабинета, КодГруппы from Расписание where КодГруппы=@name1 AND КодДняНед=@name2 order by КодВрЗанятия";
                command = new SqlCommand(sqlExpr, connectionSQL);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Schedule schedule = new Schedule();
                    String sqlExpr2 = "select ВремяНачала, ВремяОкончания from Время_Занятия where КодВрЗанятия=" + reader.GetInt32(0).ToString();
                    SqlCommand command2 = new SqlCommand(sqlExpr2, connectionSQL);
                    SqlDataReader reader2 = command2.ExecuteReader();
                    if (reader2.Read())
                    {
                        schedule.TimeStart = reader2.GetTimeSpan(0).ToString();
                        schedule.TimeEnd = reader2.GetTimeSpan(1).ToString();
                    }
                    reader2.Close();

                    sqlExpr2 = "select НазваниеКурса from Курс where КодКурса=" + reader.GetInt32(1).ToString();
                    command2 = new SqlCommand(sqlExpr2, connectionSQL);
                    reader2 = command2.ExecuteReader();
                    if (reader2.Read())
                        schedule.Subject = reader2.GetString(0);
                    reader2.Close();
                    schedule.Cabinet = reader.GetString(2);
                    schedule.Group = reader.GetString(3);
                    listSchedule.Add(schedule);
                }
            }
            reader.Close();
            formatter.Serialize(R_Client.GetStream(), listSchedule);
            Console.WriteLine("Отправлено: Тип - Расписание");
        }

        private void ExecuteCode4(Request req, SqlConnection connectionSQL, ref String login)
        {
            string sqlExpr;
            SqlCommand command;
            IFormatter formatter = new BinaryFormatter();
            List<String> list = new List<String>();
            SqlDataReader reader;

            String sqlExpr1 = "Select * from НПР where (Логин = '" + login + "')";
            command = new SqlCommand(sqlExpr1, connectionSQL);
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                sqlExpr = "declare @name1[varchar](100) set @name1 = (SELECT ИД_НПР from dbo.НПР where Логин='" + login + "') \n" +
                        "select НазваниеКурса from Курс where ИД_НПР=@name1";
                command = new SqlCommand(sqlExpr, connectionSQL);
                reader = command.ExecuteReader();
                while (reader.Read())
                    list.Add(reader.GetString(0));
            }
            else
            {
                sqlExpr = "declare @name1[varchar](100) set @name1 = (SELECT КодГруппы from Обучающийся where Логин='" + login + "') \n" +
                        "select КодУП from Группа where КодГруппы=@name1";
                command = new SqlCommand(sqlExpr, connectionSQL);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String sqlExpr2 = "select НазваниеКурса from Курс where КодУП='" + reader.GetString(0) + "'";
                    SqlCommand command2 = new SqlCommand(sqlExpr2, connectionSQL);
                    SqlDataReader reader2 = command2.ExecuteReader();
                    while (reader2.Read())
                        list.Add(reader2.GetString(0));
                }
            }
            reader.Close();
            formatter.Serialize(R_Client.GetStream(), list);
            Console.WriteLine("Отправлено: Тип - Код Курса");
        }

        private void ExecuteCode5(Request req, SqlConnection connectionSQL, ref String login)
        {
            string sqlExpr;
            SqlCommand command;
            IFormatter formatter = new BinaryFormatter();
            List<String> list = new List<String>();
            SqlDataReader reader;

            String sqlExpr1 = "select КодУП from Курс where НазваниеКурса='" + req.Data[0] + "'";
            command = new SqlCommand(sqlExpr1, connectionSQL);
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                list.Add(reader.GetString(0));
                sqlExpr = "select НаправлениеПодготовки from Учебный_план where КодУП='" + reader.GetString(0) + "'";
                SqlCommand command2 = new SqlCommand(sqlExpr, connectionSQL);
                SqlDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                    list.Add(reader2.GetString(0));
            }
            reader.Close();
            formatter.Serialize(R_Client.GetStream(), list);
            Console.WriteLine("Отправлено: Тип - КодУП");
        }

        private void ExecuteCode6(Request req, SqlConnection connectionSQL, ref String login)
        {
            string sqlExpr;
            SqlCommand command;
            IFormatter formatter = new BinaryFormatter();
            String result;
            SqlDataReader reader;

            String sqlExpr1 = "Select * from НПР where (Логин = '" + login + "')";
            command = new SqlCommand(sqlExpr1, connectionSQL);
            reader = command.ExecuteReader();
            if (reader.HasRows)
                result = "Teacher";
            else
                result = "Student";
            reader.Close();
            formatter.Serialize(R_Client.GetStream(), result);
            Console.WriteLine("Отправлено: Тип - Тип_Пользователя");
        }

        private void ExecuteCode7(Request req, SqlConnection connectionSQL, ref String login)
        {
            string sqlExpr;
            SqlCommand command;
            IFormatter formatter = new BinaryFormatter();
            List<Progress> result = new List<Progress>();
            SqlDataReader reader;

            sqlExpr = "Select ИД_обучающегося from Обучающийся where Логин='" + login + "'";
            command = new SqlCommand(sqlExpr, connectionSQL);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Progress subResult = new Progress();
                String id = reader.GetString(0);
                String sqlExpr1 = "Select КодКурса, РезультатАттестации, ДатаАттестации from Аттестация where (ИД_обучающегося = '" + id + "')";
                SqlCommand command1 = new SqlCommand(sqlExpr1, connectionSQL);
                SqlDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    String sqlExpr2 = "Select НазваниеКурса from Курс where КодКурса=" + reader1.GetInt32(0).ToString();
                    SqlCommand command2 = new SqlCommand(sqlExpr2, connectionSQL);
                    SqlDataReader reader2 = command2.ExecuteReader();
                    while (reader2.Read())
                        subResult.Name = reader2.GetString(0);
                    subResult.Grade = reader1.GetString(1);
                    subResult.Date = reader1.GetDateTime(2).ToShortDateString();
                    result.Add(subResult);
                }
            }
            reader.Close();
            formatter.Serialize(R_Client.GetStream(), result);
            Console.WriteLine("Отправлено: Тип - Таблица");
        }

        private void ExecuteCode8(Request req, SqlConnection connectionSQL, ref String login)
        {
            string sqlExpr;
            SqlCommand command;
            IFormatter formatter = new BinaryFormatter();
            List<String> result = new List<String>();
            SqlDataReader reader;

            sqlExpr = "Select ИД_НПР from НПР where Логин='" + login + "'";
            command = new SqlCommand(sqlExpr, connectionSQL);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                String id = reader.GetString(0);
                String sqlExpr1 = "Select НазваниеКурса from Курс where (ИД_НПР = '" + id + "')";
                SqlCommand command1 = new SqlCommand(sqlExpr1, connectionSQL);
                SqlDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                    result.Add(reader1.GetString(0));
            }
            reader.Close();
            formatter.Serialize(R_Client.GetStream(), result);
            Console.WriteLine("Отправлено: Тип - Таблица");
        }

        private void ExecuteCode9(Request req, SqlConnection connectionSQL, ref String login)
        {
            string sqlExpr;
            SqlCommand command;
            IFormatter formatter = new BinaryFormatter();
            List<String> result = new List<String>();
            SqlDataReader reader;

            sqlExpr = "Select КодКурса from Курс where НазваниеКурса='" + req.Data[0] + "'";
            command = new SqlCommand(sqlExpr, connectionSQL);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                String sqlExpr2 = "Select ИД_обучающегося from Аттестация where (КодКурса = " + reader.GetInt32(0).ToString() + ")";
                SqlCommand command2 = new SqlCommand(sqlExpr2, connectionSQL);
                SqlDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    String sqlExpr3 = "Select КодГруппы from Обучающийся where (ИД_обучающегося = '" + reader2.GetString(0) + "')";
                    SqlCommand command3 = new SqlCommand(sqlExpr3, connectionSQL);
                    SqlDataReader reader3 = command3.ExecuteReader();
                    while (reader3.Read())
                        result.Add(reader3.GetString(0));
                }
            }
            reader.Close();
            result = result.Distinct<String>().ToList();
            result.Sort();
            formatter.Serialize(R_Client.GetStream(), result);
            Console.WriteLine("Отправлено: Тип - Таблица");
        }

        private void ExecuteCode10(Request req, SqlConnection connectionSQL, ref String login)
        {
            string sqlExpr;
            SqlCommand command;
            IFormatter formatter = new BinaryFormatter();
            List<Progress> result = new List<Progress>();
            SqlDataReader reader;

            sqlExpr = "Select ИД_обучающегося from Обучающийся where КодГруппы='" + req.Data[1] + "'";
            command = new SqlCommand(sqlExpr, connectionSQL);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Progress subRes = new Progress();
                String sqlExpr1 = "Select ФИО_обчающегося from Обучающийся where (ИД_обучающегося = '" + reader.GetString(0) + "')";
                SqlCommand command1 = new SqlCommand(sqlExpr1, connectionSQL);
                SqlDataReader reader1 = command1.ExecuteReader();
                if (reader1.Read()) { }
                String sqlExpr3 = "Select КодКурса from Курс where (НазваниеКурса = '" + req.Data[0] + "')";
                SqlCommand command3 = new SqlCommand(sqlExpr3, connectionSQL);
                SqlDataReader reader3 = command3.ExecuteReader();
                String id = null;
                while (reader3.Read())
                    id = reader3.GetInt32(0).ToString();
                String sqlExpr2 = "Select РезультатАттестации, ДатаАттестации from Аттестация where (ИД_обучающегося = '" + reader.GetString(0) + "' AND КодКурса = " + id + ")";
                SqlCommand command2 = new SqlCommand(sqlExpr2, connectionSQL);
                SqlDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    subRes.Name = reader1.GetString(0);
                    subRes.Grade = reader2.GetString(0);
                    subRes.Date = reader2.GetDateTime(1).ToShortDateString();
                    result.Add(subRes);
                }
            }
            reader.Close();
            formatter.Serialize(R_Client.GetStream(), result);
            if (result.Count > 0)
                Console.WriteLine("Отправлено: Тип - Таблица" + result[0].Name + " " + result[0].Grade + " " + result[0].Date);
        }
    }
}
