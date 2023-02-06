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
    public partial class Form13 : Form
    {
        int lcount = 0;
        internal static List<string> listM = new List<string>();
        internal static List<string> listY = new List<string>();
        internal static List<string> listG = new List<string>();
        internal static int countM = 0, countY = 0, countG = 0;


        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Base.mdb;";
        //public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=base1.mdb;";
        private OleDbConnection myConnection;


        public Form13()
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            InitializeComponent();

            Columns();
            Lcount();
            List();
        }

        public void Columns()
        {
            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("№", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Месяц", 120, HorizontalAlignment.Center);
            listView1.Columns.Add("Год", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("Группа", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("План", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("Инд. Здоровья", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Инд. Заболеваемости", 160, HorizontalAlignment.Center);

        }
        public void Lcount() {
            string queryL = "SELECT Код FROM Итоги ORDER BY Код";
            OleDbCommand commandL = new OleDbCommand(queryL, myConnection);
            OleDbDataReader readerL = commandL.ExecuteReader();
            while (readerL.Read())
            {
                lcount++;
            }
            readerL.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            countM = 0;
            countY = 0;
            countG = 0;
            listM.Clear();
            listY.Clear();
            listG.Clear();

            Columns();
            List();

        }

        public void List() {
            int count = 0;

            string query = "SELECT Месяц, Год,Группа, План, ИндексЗдоровья, ИндексЗаболевания FROM Итоги ORDER BY Код";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                count++;
                string[] zap = new string[7];
                zap[0] = count.ToString();
                zap[1] = reader[0].ToString();
                zap[2] = reader[1].ToString();
                zap[3] = reader[2].ToString();
                zap[4] = reader[3].ToString();
                zap[5] = reader[4].ToString();
                zap[6] = reader[5].ToString();

                //фильтров нет
                if (countG == 0 && countM == 0 && countY == 0)
                {
                    ListViewItem zapis = new ListViewItem(zap);
                    listView1.Items.Add(zapis);
                }

                
                if (countG != 0)
                {
                    bool g = false, m = false, y = false;
                    
                    //проверка группы
                    for (int i = 0; i < countG; i++)
                    {
                        if (zap[3] == listG[i])
                            g = true;
                    }

                    //группа совпала, 1 условие соблюдено
                    if (g == true)
                    {
                        //доп условия
                        if (countM != 0)
                        {
                            //подправить формат месяца
                            if (zap[1].Length == 1)
                                zap[1] = "0" + zap[1];

                            //начать проверку
                            for (int i = 0; i < countM; i++)
                            {
                                if (zap[1] == listM[i])
                                    m = true;
                            }

                            //проверка пройдена успешно, 2 условия соблюдены
                            if (m == true)
                            {
                                //есть доп условия
                                if (countY != 0)
                                {
                                    for (int i = 0; i < countY; i++)
                                    {
                                        if (zap[2] == listY[i])
                                            y = true;
                                    }

                                    //3 условия соблюдены
                                    if (y == true)
                                    {
                                        ListViewItem zapis1 = new ListViewItem(zap);
                                        listView1.Items.Add(zapis1);
                                    }
                                    else
                                        count--;
                                }

                                //доп условий нет
                                else
                                {
                                    ListViewItem zapis = new ListViewItem(zap);
                                    listView1.Items.Add(zapis);
                                }
                            }
                            else
                                count--;
                        }
                        else if (countY != 0)
                        {
                            for (int i = 0; i < countY; i++)
                            {
                                if (zap[2] == listY[i])
                                    y = true;
                            }

                            //2 условия соблюдены
                            if (y == true)
                            {
                                ListViewItem zapis1 = new ListViewItem(zap);
                                listView1.Items.Add(zapis1);
                            }
                            else
                                count--;
                        }

                        //доп условий нет, вывести запись
                        else
                        {
                            ListViewItem zapis = new ListViewItem(zap);
                            listView1.Items.Add(zapis);
                        }
                    }
                    else
                        count--;
                }
                if (countG == 0)
                {
                    bool m = false, y = false;

                    //есть условие на МЕСЯЦ
                    if (countM != 0)
                    {

                        //подправить формат месяца
                        if (zap[1].Length == 1)
                            zap[1] = "0" + zap[1];

                        //начать проверку
                        for (int i = 0; i < countM; i++)
                        {
                            if (zap[1] == listM[i])
                                m = true;
                        }

                        //проверка пройдена успешно, условие соблюдено
                        if (m == true)
                        {
                            //есть доп условия
                            if (countY != 0)
                            {
                                for (int i = 0; i < countY; i++)
                                {
                                    if (zap[2] == listY[i])
                                        y = true;
                                }

                                //2 условия соблюдены
                                if (y == true)
                                {
                                    ListViewItem zapis1 = new ListViewItem(zap);
                                    listView1.Items.Add(zapis1);
                                }
                                else
                                    count--;
                            }

                            //доп условий нет
                            else
                            {
                                ListViewItem zapis = new ListViewItem(zap);
                                listView1.Items.Add(zapis);
                            }
                        }
                        else
                            count--;
                    }

                    //есть условие на ГОД
                    else if (countY != 0)
                    {
                        for (int i = 0; i < countY; i++)
                        {
                            if (zap[2] == listY[i])
                                y = true;
                        }

                        // условиe соблюденo
                        if (y == true)
                        {
                            ListViewItem zapis1 = new ListViewItem(zap);
                            listView1.Items.Add(zapis1);
                        }
                        else
                            count--;
                    }
                }
            }
            reader.Close();

            sort(count);
            format(count);
        }

        public void sort(int count)
        {
            string[,] list = new string[count, 6];

            for (int i = 0; i < count; i++)
                for (int j = 0; j < 6; j++)
                {
                    string text = listView1.Items[i].SubItems[j + 1].Text;
                    list[i, j] = text;
                }

            for (int repeat = 0; repeat < count; repeat++)
            {
                for (int i = 0; i < count - 1; i++)
                {
                    sbyte zamena = 0;
                    if (list[i, 0].Length == 1)
                        list[i, 0] = "0" + list[i, 0];
                    
                    if (list[i+1, 0].Length == 1)
                        list[i + 1, 0] = "0" + list[i + 1, 0];
                    

                    //string y1=
                    DateTime date1 = new DateTime();
                    date1 = Convert.ToDateTime("01." + list[i, 0] + "." + list[i, 1]);
                    DateTime date2 = new DateTime();
                    date2 = Convert.ToDateTime("01." + list[i + 1, 0] + "." + list[i + 1, 1]);

                    if (date1.CompareTo(date2) > 0)
                        zamena++;
                    else if (date1.CompareTo(date2) == 0 && String.Compare(list[i, 0], list[i + 1, 0], true) > 0)
                        zamena++;

                    if (zamena == 1)
                        for (int j = 0; j < 6; j++)
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
                ListViewItem zapis = new ListViewItem(new string[] {(i+1).ToString(), list[i, 0], list[i, 1], list[i, 2], list[i, 3], list[i, 4], list[i, 5] });
                listView1.Items.Add(zapis);
            }
        }
        public void format(int count) {
            string m = "";
            for (int i = 0; i < count; i++)
            {
                m = listView1.Items[i].SubItems[1].Text;
                if (m=="01")
                    listView1.Items[i].SubItems[1].Text = "Январь";
                else if (m == "02")
                    listView1.Items[i].SubItems[1].Text = "Февраль";
                else if (m == "03")
                    listView1.Items[i].SubItems[1].Text = "Март";
                else if (m == "04")
                    listView1.Items[i].SubItems[1].Text = "Апрель";
                else if (m == "05")
                    listView1.Items[i].SubItems[1].Text = "Май";
                else if (m == "06")
                    listView1.Items[i].SubItems[1].Text = "Июнь";
                else if (m == "07")
                    listView1.Items[i].SubItems[1].Text = "Июль";
                else if (m == "08")
                    listView1.Items[i].SubItems[1].Text = "Август";
                else if (m == "09")
                    listView1.Items[i].SubItems[1].Text = "Сентябрь";
                else if (m == "10")
                    listView1.Items[i].SubItems[1].Text = "Октяябрь";
                else if (m == "11")
                    listView1.Items[i].SubItems[1].Text = "Ноябрь";
                else if (m == "12")
                    listView1.Items[i].SubItems[1].Text = "Декабрь";

                string query = "SELECT Название FROM Группы WHERE Код = " + listView1.Items[i].SubItems[3].Text;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                listView1.Items[i].SubItems[3].Text = command.ExecuteScalar().ToString();
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form14 f14 = new Form14();
            f14.ShowDialog();

            Columns();
            List();
        }
    }
}
