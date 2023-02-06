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
    public partial class Form8 : Form
    {
        internal static string Fcode;
        internal static bool check;
        string query;
        int count = 0;

        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Base.mdb;";
        //public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=base1.mdb;";
        private OleDbConnection myConnection;
        public Form8()
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            InitializeComponent();

            check = false;
            Fcode = "";
            query = "SELECT Код, Название, Воспитатель1, Воспитатель2, Помощник FROM Группы ORDER BY Код";
            List(query, false);
        }

       //поиск
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT Код, Название, Воспитатель1, Воспитатель2, Помощник FROM Группы ORDER BY Код";
            List(query, true);
        }


        //выбор    
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listView1.FocusedItem.Index;
            Fcode = listView1.Items[index].SubItems[0].Text;
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            check = true;
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            check = true;
            Close();
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                query = "SELECT Код, Название, Воспитатель1, Воспитатель2, Помощник FROM Группы ORDER BY Код";
                List(query, true);
            }
            else
                sort(e.Column);
        }


        //вспомогательное
        public string ScalarCommand(string query)
        {
            OleDbCommand command = new OleDbCommand(query, myConnection);
            string text = command.ExecuteScalar().ToString();
            return text;
        }
        public void List(string query, bool change)
        {
            count = 0;
            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("Код", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Название", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Воспитатель 1", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Воспитатель 2", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Помощник воспитателя", 150, HorizontalAlignment.Center);
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string text = textBox1.Text;
                string vosp1 = reader[2].ToString();
                if (vosp1 != "")
                {
                    if (vosp1 != "0")
                    {
                        string query2 = "SELECT Фамилия FROM Сотрудники WHERE Код=" + vosp1;
                        vosp1 = ScalarCommand(query2);
                    }
                    else
                        vosp1 = "";
                }

                string vosp2 = reader[3].ToString();
                if (vosp2 != "")
                {
                    if (vosp2 != "0")
                    {
                        string query2 = "SELECT Фамилия FROM Сотрудники WHERE Код=" + vosp2;
                        vosp2 = ScalarCommand(query2);
                    }
                    else
                        vosp2 = "";
                }

                string helper = reader[4].ToString();
                if (helper != "")
                {
                    if (helper != "0")
                    {
                        string query2 = "SELECT Фамилия FROM Сотрудники WHERE Код=" + helper;
                        helper = ScalarCommand(query2);
                    }
                    else
                        helper = "";
                }

                ListViewItem zapis = new ListViewItem(new string[] { reader[0].ToString(), reader[1].ToString(), vosp1, vosp2, helper });
                if ((reader[1].ToString().StartsWith(text) == true || vosp1.StartsWith(text) == true || vosp2.StartsWith(text) == true || helper.StartsWith(text) == true) && change == true)
                {
                    listView1.Items.Add(zapis);
                    count++;
                }
                else if (change == false)
                { listView1.Items.Add(zapis);
                    count++;
                }
            }
        }
        public void sort(int sort)
        {
            string[,] list = new string[count, 5];
            int countN = count;
            for (int i = 0; i < count; i++)
                for (int j = 0; j < 5; j++)
                {
                    string text = listView1.Items[i].SubItems[j].Text;
                    list[i, j] = text;
                }

            for (int repeat = 0; repeat < count; repeat++)
            {
                for (int i = 0; i < countN - 1; i++)
                {
                    sbyte zamena = 0;
                    if (sort > 0 && sort < 5) //если сравнение по текстовым полям
                    {
                        if (String.Compare(list[i, sort], list[i + 1, sort], true) > 0)
                            zamena++;
                        else if (String.Compare(list[i, sort], list[i + 1, sort], true) == 0 && String.Compare(list[i, 0], list[i + 1, 0], true) > 0)
                            zamena++;
                    }
                    if (zamena == 1)
                        for (int j = 0; j < 5; j++)
                        {
                            string temp = list[i, j];
                            list[i, j] = list[i + 1, j];
                            list[i + 1, j] = temp;
                        }

                }
            }
            
            count = 0;
            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("Код", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Название", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Воспитатель 1", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Воспитатель 2", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Помощник воспитателя", 150, HorizontalAlignment.Center);
            for (int i = 0; i < countN; i++)
            {
                ListViewItem zapis = new ListViewItem(new string[] { list[i, 0], list[i, 1], list[i, 2], list[i, 3], list[i, 4] });
                listView1.Items.Add(zapis);
                count++;
            }
        }
    }
}
