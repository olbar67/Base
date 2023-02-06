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
    public partial class Form5 : Form
    {
        internal static string Fcode;
        internal static int Fmode;
        internal static bool check;
        int count;
        string query;
        bool search;

        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Base.mdb;";
        //public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=base1.mdb;";
        private OleDbConnection myConnection;

        public Form5(bool searchF)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            InitializeComponent();

            check = false;
            Fmode = 0;
            Fcode = "";
            search = searchF;
            Columns();

            if (search == true)
            {
                button2.Visible = false;
                query = "SELECT Код, Фамилия, Имя, Отчество, ДатаРождения FROM Воспитаники ORDER BY Код";
                fullList(query, 1, false);
                query = "SELECT Код, Фамилия, Имя, Отчество, ДатаРождения FROM Родители ORDER BY Код";
                fullList(query, 2, false);
                query = "SELECT Код, Фамилия, Имя, Отчество, ДатаРождения FROM Сотрудники ORDER BY Код";
                fullList(query, 3, false);
            }
            else
            {
                query = "SELECT Код, Фамилия, Имя, Отчество, ДатаРождения FROM Родители ORDER BY Код";
                List(query, false);
            }
            
        }


        //заполнение списка
        public void Columns()
        {
            listView1.Clear();
            if (search == true)
                listView1.Width = 813;
            else
                listView1.Width = 713;
            listView1.View = View.Details;
            listView1.Columns.Add("Код", 60, HorizontalAlignment.Center);
            if (search == true)
                listView1.Columns.Add("Справочник", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Фамилия", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Имя", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Отчество", 200, HorizontalAlignment.Center);
            listView1.Columns.Add("Дата рождения", 150, HorizontalAlignment.Center);
        }
        public void List( string query, bool change) {
            count = 0;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                count++;
                string date1 = reader[4].ToString();
                ListViewItem zapis = new ListViewItem(new string[] { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), date1.Remove(10) });
                if (change == true)
                {
                    string text = textBox1.Text;
                    if ((reader[1].ToString().StartsWith(text) == true) || (reader[2].ToString().StartsWith(text) == true) || (reader[3].ToString().StartsWith(text) == true) || (date1.Remove(10).Contains(text)))
                        listView1.Items.Add(zapis);
                    else
                        count--;
                }
                else
                    listView1.Items.Add(zapis);
            }
            label2.Text = count.ToString();
            reader.Close();
        }
        public void fullList(string query, int table, bool change) {
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                count++;
                string date1 = reader[4].ToString();
                if (table == 1)
                {
                    ListViewItem zapis = new ListViewItem(new string[] { reader[0].ToString(), "Воспитанник", reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), date1.Remove(10) });
                    if (change == true)
                    {
                        string text = textBox1.Text;
                        if ((reader[1].ToString().StartsWith(text) == true) || (reader[2].ToString().StartsWith(text) == true) || (reader[3].ToString().StartsWith(text) == true) || (date1.Remove(10).Contains(text)))
                            listView1.Items.Add(zapis);
                        else
                            count--;
                    }
                    else
                        listView1.Items.Add(zapis);
                }
                else if (table == 2)
                {
                    ListViewItem zapis = new ListViewItem(new string[] { reader[0].ToString(), "Родитель", reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), date1.Remove(10) });
                    if (change == true)
                    {
                        string text = textBox1.Text;
                        if ((reader[1].ToString().StartsWith(text) == true) || (reader[2].ToString().StartsWith(text) == true) || (reader[3].ToString().StartsWith(text) == true) || (date1.Remove(10).Contains(text)))
                            listView1.Items.Add(zapis);
                        else
                            count--;
                    }
                    else
                        listView1.Items.Add(zapis);
                }
                else if (table == 3)
                {
                    ListViewItem zapis = new ListViewItem(new string[] { reader[0].ToString(), "Сотрудник", reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), date1.Remove(10) });
                    if (change == true)
                    {
                        string text = textBox1.Text;
                        if ((reader[1].ToString().StartsWith(text) == true) || (reader[2].ToString().StartsWith(text) == true) || (reader[3].ToString().StartsWith(text) == true) || (date1.Remove(10).Contains(text)))
                            listView1.Items.Add(zapis);
                        else
                            count--;
                    }
                    else
                        listView1.Items.Add(zapis);
                }


            }
            label2.Text = count.ToString();
            reader.Close();
        }


        //отлов изменений поиска
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            count = 0;
            if (search == true)
            {
                Columns();
                query = "SELECT Код, Фамилия, Имя, Отчество, ДатаРождения FROM Воспитаники ORDER BY Код";
                fullList(query, 1, true);
                query = "SELECT Код, Фамилия, Имя, Отчество, ДатаРождения FROM Родители ORDER BY Код";
                fullList(query, 2, true);
                query = "SELECT Код, Фамилия, Имя, Отчество, ДатаРождения FROM Сотрудники ORDER BY Код";
                fullList(query, 3, true);
            }
            else {
                Columns();
                query = "SELECT Код, Фамилия, Имя, Отчество, ДатаРождения FROM Родители ORDER BY Код";
                List(query, true);
            }
        }


        //выбор элемента
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (search == true)
            {
                int index = listView1.FocusedItem.Index;
                Fcode = listView1.Items[index].SubItems[0].Text;
                if (listView1.Items[index].SubItems[1].Text == "Воспитанник")
                    Fmode = 1;
                if (listView1.Items[index].SubItems[1].Text == "Родитель")
                    Fmode = 2;
                if (listView1.Items[index].SubItems[1].Text == "Сотрудник")
                    Fmode = 3;
            }
            else {
                int index = listView1.FocusedItem.Index;
                Fcode = listView1.Items[index].SubItems[0].Text;
                Fmode = 2;
            }
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (Fcode != "")
            {
                if (Fmode == 1)
                {
                    Form2 f2 = new Form2(Fcode, false);
                    f2.ShowDialog();
                }
                if (Fmode == 2)
                {
                    Form6 f6 = new Form6(Fcode, false);
                    f6.ShowDialog();
                }
                if (Fmode == 3)
                {
                    Form7 f7 = new Form7(Fcode, false);
                    f7.ShowDialog();
                }
            }
        }

        //кнопки
        private void button1_Click(object sender, EventArgs e)
        {
            if (Fcode != "")
            {
                if (Fmode == 1)
                {
                    Form2 f2 = new Form2(Fcode, false);
                    f2.ShowDialog();
                }
                if (Fmode == 2)
                {
                    Form6 f6 = new Form6(Fcode, false);
                    f6.ShowDialog();
                }
                if (Fmode == 3)
                {
                    Form7 f7 = new Form7(Fcode, false);
                    f7.ShowDialog();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            check = true;
            Close();
        }


        //прочее
        public void sort(int sort)
        {
            int ColumnCount=0;
            if (search == true)
                ColumnCount = 6;
            else
                ColumnCount = 5;
            string[,] list = new string[count, ColumnCount];

            for (int i = 0; i < count; i++)
                for (int j = 0; j < ColumnCount; j++)
                {
                    string text = listView1.Items[i].SubItems[j].Text;
                    list[i, j] = text;
                }

            for (int repeat = 0; repeat < count; repeat++)
            {
                for (int i = 0; i < count - 1; i++)
                {
                    sbyte zamena = 0;
                    if ((sort > 0 && sort < 4 && search==false) || (sort > 0 && sort < 5 && search ==true)) //если сравнение по текстовым полям
                    {
                        if (String.Compare(list[i, sort], list[i + 1, sort], true) > 0)
                            zamena++;
                        else if (String.Compare(list[i, sort], list[i + 1, sort], true) == 0 && String.Compare(list[i, 0], list[i + 1, 0], true) > 0)
                            zamena++;
                    }
                    else if ((sort == 4 && search==false) || (sort==5 && search==true))
                    {
                        DateTime date1 = new DateTime();
                        date1 = Convert.ToDateTime(list[i, sort]);
                        DateTime date2 = new DateTime();
                        date2 = Convert.ToDateTime(list[i + 1, sort]);
                        if (date1.CompareTo(date2) > 0)
                            zamena++;
                        else if (date1.CompareTo(date2) == 0 && String.Compare(list[i, 0], list[i + 1, 0], true) > 0)
                            zamena++;
                    }
                    if (zamena == 1)
                        for (int j = 0; j < ColumnCount; j++)
                        {
                            string temp = list[i, j];
                            list[i, j] = list[i + 1, j];
                            list[i + 1, j] = temp;
                        }

                }
            }
            Columns();
            for (int i = 0; i < count; i++)
            {
                if (search == true)
                {
                    ListViewItem zapis = new ListViewItem(new string[] { list[i, 0], list[i, 1], list[i, 2], list[i, 3], list[i, 4], list[i, 5] });
                    listView1.Items.Add(zapis);
                }
                else
                {
                    ListViewItem zapis = new ListViewItem(new string[] { list[i, 0], list[i, 1], list[i, 2], list[i, 3], list[i, 4] });
                    listView1.Items.Add(zapis);
                }

                }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (search == true)
            {
                if (e.Column == 0)
                {
                    count = 0;
                    Columns();
                    query = "SELECT Код, Фамилия, Имя, Отчество, ДатаРождения FROM Воспитаники ORDER BY Код";
                    fullList(query, 1, false);
                    query = "SELECT Код, Фамилия, Имя, Отчество, ДатаРождения FROM Родители ORDER BY Код";
                    fullList(query, 2, false);
                    query = "SELECT Код, Фамилия, Имя, Отчество, ДатаРождения FROM Сотрудники ORDER BY Код";
                    fullList(query, 3, false);
                }
                else
                    sort(e.Column);
            }
            else
            {
                if (e.Column == 0)
                {
                    count = 0;
                    Columns();
                    query = "SELECT Код, Фамилия, Имя, Отчество, ДатаРождения FROM Родители ORDER BY Код";
                    List(query, false);
                }
                else
                    sort(e.Column);
            }
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form18 f18 = new Form18();
            f18.ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
