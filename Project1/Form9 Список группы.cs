using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class Form9 : Form
    {
        string code, vcode="";
        int count = 0;

        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Base.mdb;";
        //public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Base.mdb;";
        private OleDbConnection myConnection;

        public Form9(string c)
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            code = c;
            textBox1.ReadOnly = true;
            button1.Text = "Изменить";

            if (Form1.level == 3)
                button1.Visible = false;

            Columns();
            List();
            Vosp();

        }


        public void Columns()
        {
            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("Код", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Фамилия", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Имя", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Отчество", 200, HorizontalAlignment.Center);
            listView1.Columns.Add("Дата рождения", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Группа Здоровья", 150, HorizontalAlignment.Center);
        }
        public void List()
        {
            string query = "SELECT Код, Фамилия, Имя, Отчество, ДатаРождения, ГруппаЗдоровья FROM Воспитаники WHERE Группа=" + code;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                count++;
                string date1 = reader[4].ToString();
                string gr = reader[5].ToString();
                string queryH = "SELECT Наименование FROM ГруппыЗдоровья WHERE Код=" + gr;
                if (gr != "")
                {
                    OleDbCommand commandH = new OleDbCommand(queryH, myConnection);
                    gr = commandH.ExecuteScalar().ToString();
                }
                else
                    gr = "";
                ListViewItem zapis = new ListViewItem(new string[] { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), date1.Remove(10), gr });
                listView1.Items.Add(zapis);
            }
            label8.Text = count.ToString();
            reader.Close();

            query = "SELECT Название FROM Группы WHERE Код=" + code;
            OleDbCommand command2 = new OleDbCommand(query, myConnection);
            textBox1.Text = command2.ExecuteScalar().ToString();
        }
        public void Vosp()
        {
            string query = "SELECT Воспитатель1, Воспитатель2, Помощник FROM Группы  WHERE Код=" + code;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string vosp1 = reader[0].ToString();
                if (vosp1 != "")
                {
                    if (vosp1 != "0")
                    {
                        string query1 = "SELECT Фамилия, Имя, Отчество FROM Сотрудники WHERE Код=" + vosp1;
                        OleDbCommand command1 = new OleDbCommand(query1, myConnection);
                        OleDbDataReader reader1 = command1.ExecuteReader();
                        while (reader1.Read())
                        {
                            label3.Text = reader1[0].ToString() + " " + reader1[1].ToString() + " " + reader1[2].ToString();
                        }
                        reader1.Close();

                    }
                    else
                        label3.Text = "-";
                }
                else
                    label3.Text = "-";

                string vosp2 = reader[1].ToString();
                if (vosp2 != "")
                {
                    if (vosp2 != "0")
                    {
                        string query1 = "SELECT Фамилия, Имя, Отчество FROM Сотрудники WHERE Код=" + vosp2;
                        OleDbCommand command1 = new OleDbCommand(query1, myConnection);
                        OleDbDataReader reader1 = command1.ExecuteReader();
                        while (reader1.Read())
                        {
                            label5.Text = reader1[0].ToString() + " " + reader1[1].ToString() + " " + reader1[2].ToString();
                        }
                        reader1.Close();
                    }
                    else
                        label5.Text = "-";
                }
                else
                    label5.Text = "-";

                string helper = reader[2].ToString();
                if (helper != "")
                {
                    if (helper != "0")
                    {
                        string query1 = "SELECT Фамилия, Имя, Отчество FROM Сотрудники WHERE Код=" + helper;
                        OleDbCommand command1 = new OleDbCommand(query1, myConnection);
                        OleDbDataReader reader1 = command1.ExecuteReader();
                        while (reader1.Read())
                        {
                            label6.Text = reader1[0].ToString() + " " + reader1[1].ToString() + " " + reader1[2].ToString();
                        }
                        reader1.Close();
                    }
                    else
                        label6.Text = "-";
                }
                else
                    label6.Text = "-";

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Изменить")
            {
                textBox1.ReadOnly = false;
                button1.Text = "OK";
            }
            else
            {
                textBox1.ReadOnly = true;
                button1.Text = "Изменить";
                string Ngroup = textBox1.Text;
                string query = "UPDATE Группы SET Название = '" + Ngroup + "' WHERE Код = " + code;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
            }

        }

        public string ScalarCommand(string query)
        {
            OleDbCommand command = new OleDbCommand(query, myConnection);
            string text = command.ExecuteScalar().ToString();
            return text;
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(vcode, false);
            f2.ShowDialog();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listView1.FocusedItem.Index;
            vcode = listView1.Items[index].SubItems[0].Text;
        }
    }
}