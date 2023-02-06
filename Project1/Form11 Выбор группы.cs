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
    public partial class Form11 : Form
    {
        string gr = "";

        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Base.mdb;";
        private OleDbConnection myConnection;


        public Form11()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();

            string query = "SELECT Название FROM Группы ORDER BY Название";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0].ToString());
            }
            reader.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gr = comboBox1.Text;
            string query = "SELECT Код FROM Группы WHERE Название='" + gr + "'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            if (gr != "")
            {
                gr = command.ExecuteScalar().ToString();
                Form10 f10 = new Form10(gr, comboBox1.Text, false, 0, 0);
                DateTime now = DateTime.Today;
                int year = Convert.ToInt32(now.Year);
                int month = Convert.ToInt32(now.Month);
                int days = DateTime.DaysInMonth(year, month);
                f10.Width = (days + 1) * 30 + 205 + 40;
                f10.ShowDialog();
                Close();
            }
        }
    }
}
