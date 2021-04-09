#define LOCALDB_DEFINE_PROXY_FUNCTIONS

using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;



namespace TestWinFormsAppWM
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public struct Person //Структура для элемента Person в XML-файле
        {
            public string p_name;
            public string p_surname;
            public string p_mname;
            public int p_age;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
        private void btnClearData_Click(object sender, EventArgs e)
        {
            dgwPersons.DataSource = null;
            SqlConnection conn = new SqlConnection
            {
                ConnectionString =
                    "Data Source=(LocalDB)\\MSSQLLocalDB;Integrated Security=True"
            };
            string sql_use_db = "USE DB_Persons;";
            SqlCommand com_use_db = new SqlCommand(sql_use_db, conn); 
            string sql_clear_table = "DELETE FROM Persons";
            SqlCommand com_clear_table = new SqlCommand(sql_clear_table, conn);
            try
            {
                conn.Open();
                com_use_db.ExecuteNonQuery();
                com_clear_table.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection
            {
                ConnectionString =
                    "Data Source=(LocalDB)\\MSSQLLocalDB;Integrated Security=True;"
            };
            try
            {
                conn.Open();
                string sql_use_db = "USE DB_Persons;";
                SqlCommand com_use_db = new SqlCommand(sql_use_db, conn);
                com_use_db.ExecuteNonQuery();
                DataSet ds = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Name, Surname, MiddleName, Age FROM Persons;", conn);
                dataAdapter.Fill(ds, "Persons");
                bsData.DataSource = ds.Tables["Persons"];
                bsData.Filter = ""; //Формирование строки для фильтрации по полям
                if (tbName.Text != "")
                    bsData.Filter += "Name='" + tbName.Text + "' ";
                if (tbSurname.Text != "")
                    bsData.Filter += "Surname='" + tbSurname.Text + "' ";
                if (tbMidname.Text != "")
                    bsData.Filter += "MiddleName='" + tbMidname.Text + "' ";
                if ((tbAgeFrom.Text != "") & (tbAgeTo.Text != ""))
                    bsData.Filter += "Age >= " + tbAgeFrom.Text + " AND Age <= " + tbAgeTo.Text;
                if ((tbName.Text == "") & (tbSurname.Text == "") & (tbMidname.Text == "") & (tbAgeFrom.Text == "") & (tbAgeTo.Text == ""))
                    bsData.Filter = ""; //сброс фильтра
                dgwPersons.DataSource = bsData.DataSource;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void chrtAges_Click(object sender, EventArgs e)
        {

        }

        private void dgwPersons_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            XmlNodeList xmlnode;
            int i;
            ofdOpenXML.ShowDialog();  //Открытие XML-файла
            string filepath = ofdOpenXML.FileName;
            if (filepath == "")
                Application.Exit();
            else
            {
                FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                doc.Load(fs);
                xmlnode = doc.GetElementsByTagName("Person"); //Загрузка множества элементов Person в список "узлов" XML
                Person[] mas_persons = new Person[xmlnode.Count];
                int max_age=0;
                for (i = 0; i <= xmlnode.Count - 1; i++) //Формирование массива элементов типа Person
                {
                    mas_persons[i].p_name = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                    mas_persons[i].p_surname = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                    mas_persons[i].p_mname = xmlnode[i].ChildNodes.Item(2).InnerText.Trim();
                    mas_persons[i].p_age = Convert.ToInt32(xmlnode[i].ChildNodes.Item(3).InnerText);
                    if (max_age < mas_persons[i].p_age)
                        max_age = mas_persons[i].p_age;
                    dgwPersons.Tag = max_age;
                    
                }
                SqlConnection conn = new SqlConnection
                {
                    ConnectionString =
                        "Data Source=(LocalDB)\\MSSQLLocalDB;Integrated Security=True;"
                }; //Подключение к LocalDB
                string path = Directory.GetParent(Application.StartupPath).FullName;
                string sql_existing_dbs = "SELECT DB_ID ('DB_Persons');";
                string sql_create_db = "CREATE DATABASE DB_Persons ON PRIMARY " +
                 "(NAME = DB_Persons, " +
                 "FILENAME = '" + path + "\\Debug\\DB_Persons.mdf', " +
                 "SIZE = 20MB, MAXSIZE = 100MB, FILEGROWTH = 10%)" +
                 "LOG ON (NAME = DB_Persons_log, " +
                 "FILENAME = '" + path + "\\Debug\\PersonsLog.ldf', " +
                 "SIZE = 10MB, " +
                 "MAXSIZE = 50MB, " +
                 "FILEGROWTH = 10%) " + "COLLATE Cyrillic_General_CI_AS";
                string sql_use_db = "USE DB_Persons;";
                string sql_create_table = "CREATE TABLE Persons " +
                    "( " +
                        "id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, " +
                        "Name NVARCHAR(50) NOT NULL, " +
                        "Surname NVARCHAR(50) NOT NULL, " +
                        "MiddleName NVARCHAR(50) NOT NULL, " +
                        "Age INT NOT NULL" +
                    ");";
                string sql_insert_data;
                try
                {
                    conn.Open();
                    SqlCommand com_existing_dbs = new SqlCommand(sql_existing_dbs, conn);//Проверка существования БД DB_Persons
                    string exist_db = com_existing_dbs.ExecuteScalar().ToString();
                    SqlCommand com_use_db = new SqlCommand(sql_use_db, conn);
                    if (exist_db == "")
                    {
                        SqlCommand com_create_db = new SqlCommand(sql_create_db, conn);
                        com_create_db.ExecuteNonQuery();
                        com_use_db.ExecuteNonQuery();
                        SqlCommand com_create_table = new SqlCommand(sql_create_table, conn);
                        com_create_table.ExecuteNonQuery();
                    }
                    com_use_db.ExecuteNonQuery();
                    string sql_clear_table = "DELETE FROM Persons";
                    SqlCommand com_clear_table = new SqlCommand(sql_clear_table, conn);
                    com_clear_table.ExecuteNonQuery();
                    for (i = 0; i <= xmlnode.Count - 1; i++) //Добавление данных в таблицу
                    {
                        int id = i + 1;
                        int percentage = (100 / 60) * mas_persons[i].p_age;
                        sql_insert_data = "INSERT INTO Persons " +
                            "(Name, Surname, MiddleName, Age) " +
                            "VALUES ('" + mas_persons[i].p_name + "', " +
                            "'" + mas_persons[i].p_surname + "', " +
                            "'" + mas_persons[i].p_mname + "', " +
                            "'" + mas_persons[i].p_age + "'); ";
                        SqlCommand com_insert_data = new SqlCommand(sql_insert_data, conn);
                        com_insert_data.ExecuteNonQuery();
                    }
                    DataSet ds = new DataSet();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Name, Surname, MiddleName, Age FROM Persons;", conn); //Выгрузка данных из таблицы на форму
                    dataAdapter.Fill(ds, "Persons");
                    bsData.DataSource = ds.Tables["Persons"];
                    dgwPersons.DataSource = bsData.DataSource;
                    dgwPersons.ReadOnly = true;                    
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {

                        conn.Close();
                    }
                }
            }
        }

        private void dgwPersons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgwPersons_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (this.dgwPersons.Columns["Age"].Index ==
                e.ColumnIndex && e.RowIndex >= 0)
            {
                Rectangle newRect = new Rectangle(e.CellBounds.X + 1,
                    e.CellBounds.Y + 1, ((e.CellBounds.Right - e.CellBounds.Left) * Convert.ToInt32(e.Value) / Convert.ToInt32(dgwPersons.Tag)) - 4,
                    e.CellBounds.Height - 4); //Формирование прямоугольника согласно значению ячейки

                using (
                    Brush gridBrush = new SolidBrush(this.dgwPersons.GridColor),
                    backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                {
                    using (Pen gridLinePen = new Pen(gridBrush))
                    {
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                            e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom - 1);
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                            e.CellBounds.Top, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom);

                        e.Graphics.DrawRectangle(Pens.Blue, newRect);

                        if (e.Value != null)
                        {
                            e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font,
                                Brushes.Black, e.CellBounds.X + 2,
                                e.CellBounds.Y + 2, StringFormat.GenericDefault);
                        }
                        e.Handled = true;
                    }
                }
            }
        }
    }
}
