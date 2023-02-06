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
    public partial class Form16 : Form
    {
        string code = "", entercode="";
        int index = -1;

        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Base.mdb;";
        //public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=base1.mdb;";
        private OleDbConnection myConnection;

        public Form16()
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            InitializeComponent();

            Columns();
            List();
        }

        public void Columns()
        {
            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("№", 30, HorizontalAlignment.Center);
            listView1.Columns.Add("Фамилия", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Имя", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Отчество", 130, HorizontalAlignment.Center);
        }

        public void List()
        {
            string queryС = "SELECT Сотрудник, Код FROM Вход ORDER BY Код";
            OleDbCommand commandС = new OleDbCommand(queryС, myConnection);
            OleDbDataReader readerС = commandС.ExecuteReader();
            while (readerС.Read())
            {
                entercode = readerС[1].ToString();
                string Scode = readerС[0].ToString();
                string query = "SELECT Код, Фамилия, Имя, Отчество FROM Сотрудники WHERE Код=" + Scode;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem zapis = new ListViewItem(new string[] { entercode, reader[1].ToString(), reader[2].ToString(), reader[3].ToString() });
                    listView1.Items.Add(zapis);
                }
                reader.Close();
            }
        }
    

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = listView1.FocusedItem.Index;
            code = listView1.Items[index].SubItems[0].Text;
            label2.Text = listView1.Items[index].SubItems[1].Text + " " + listView1.Items[index].SubItems[2].Text + " " + listView1.Items[index].SubItems[3].Text;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (code == "")
                MessageBox.Show("Вы не выбрали сотрудника!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pas = textBox1.Text;
            if (code != "" && pas != "")
            {
                string query = "UPDATE Вход SET Пароль = '" + pas + "' WHERE Код = " + entercode;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
                Close();
            }
            else if (code == "")
                MessageBox.Show("Вы не выбрали сотрудника!");
            else if (pas == "")
                MessageBox.Show("Вы не ввели пароль!");
        }
    }
}
