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
    public partial class Form15 : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Base.mdb;";
        //public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=base1.mdb;";
        private OleDbConnection myConnection;

        public Form15()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string log = textBox1.Text;
            string pas = textBox2.Text;
            int sotr = 0, lev = 0;
            string pas_check;


            string query = "SELECT Код, Сотрудник, Уровень, Пароль FROM Вход WHERE Логин = '" + log + "'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();

            int count = 0;
            while (reader.Read())
            {

                sotr = Convert.ToInt32(reader[1]);
                lev = Convert.ToInt32(reader[2]);
                pas_check = Convert.ToString(reader[3]);

                if (pas == pas_check) count++;
            }
            reader.Close();

            if (count == 1 && lev!=4)
            {
                Form1.sotr = sotr;
                Form1.level = lev;
                Close();
            }
            else if (count == 0 && lev!=4)
                MessageBox.Show("Неверный логин или пароль");
            else
                MessageBox.Show("Доступ запрещен");

        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }
    }
}
