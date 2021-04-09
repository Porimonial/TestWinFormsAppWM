using System;
using System.Xml;
using System.IO;
using System.Data.SqlClient;

namespace TestApp1
{
    class Program
    {
        public struct Person //Структура для элемента Person в XML-файле
            {
                public string p_name;
                public string p_surname;
                public string p_mname;
                public string p_age;
            }
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            XmlNodeList xmlnode;
            int i;
            FileStream fs = new FileStream("data1.xml", FileMode.Open, FileAccess.Read);
            doc.Load(fs);
            xmlnode = doc.GetElementsByTagName("Person"); //Загрузка множества элементов Person в список "узлов" XML
            string [] field_names = new string [xmlnode[0].ChildNodes.Count];
            Person [] mas_persons = new Person[xmlnode.Count];
            for (i = 0; i <= xmlnode[0].ChildNodes.Count - 1; i++) //Формирование списка имен полей
            {
                field_names[i] = xmlnode[0].ChildNodes.Item(i).Name;
            }
            for (i = 0; i <= xmlnode.Count - 1; i++) //Формирование списка элементов
            {
                mas_persons[i].p_name = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                mas_persons[i].p_surname = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                mas_persons[i].p_mname = xmlnode[i].ChildNodes.Item(2).InnerText.Trim();
                mas_persons[i].p_age = xmlnode[i].ChildNodes.Item(3).InnerText;
            }
            SqlConnection conn = new SqlConnection
            {
                ConnectionString =
                    "Data Source=XELLOP-PC\\SQLEXPRESS;" +
                    "User id=sa;" +
                    "Password=75758780;"
            }; //Подключение к MSSQL

            string sql_create_db = "CREATE DATABASE Persons_db ON PRIMARY " +
             "(NAME = Persons_Data, " +
             "FILENAME = 'C:\\Persons_DB\\PersonsData.mdf', " +
             "SIZE = 20MB, MAXSIZE = 100MB, FILEGROWTH = 10%)" +
             "LOG ON (NAME = Persons_Log, " +
             "FILENAME = 'C:\\Persons_DB\\PersonsLog.ldf', " +
             "SIZE = 10MB, " +
             "MAXSIZE = 50MB, " +
             "FILEGROWTH = 10%)";
            string sql_use_db = "USE Persons_db";
            string sql_create_table = "CREATE TABLE Persons " + 
                "(Name varchar(255), " +
                "Surname varchar(255), " +
                "MiddleName varchar(255), " +
		        "Age varchar(255));";
            string sql_insert_data;


            SqlCommand com_create_db = new SqlCommand(sql_create_db, conn);
            SqlCommand com_use_db = new SqlCommand(sql_use_db, conn);
            SqlCommand com_create_table = new SqlCommand(sql_create_table, conn);
            try
            {
                conn.Open();
                com_create_db.ExecuteNonQuery();
                Console.WriteLine("Persons_db is created successfully");
                com_use_db.ExecuteNonQuery();
                Console.WriteLine("Persons_db is using now");
                com_create_table.ExecuteNonQuery();
                Console.WriteLine("Table Persons is created successfully");
                for (i = 0; i <= xmlnode.Count - 1; i++) //Добавление данных в таблицу
                {
                    sql_insert_data = "INSERT INTO Persons " +
                        "(Name, Surname, MiddleName, Age) " +
                        "VALUES (" + "'" + mas_persons[i].p_name + "', " +
                        "'" + mas_persons[i].p_surname + "', " +
                        "'" + mas_persons[i].p_mname + "', " +
                        "'" + mas_persons[i].p_age + "');";
                    SqlCommand com_insert_data = new SqlCommand(sql_insert_data, conn);
                    com_insert_data.ExecuteNonQuery();
                }
                Console.WriteLine("Data is created successfully");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            Console.ReadLine();
        }
    }
}
