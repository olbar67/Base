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
    public partial class Form10 : Form
    {
        int count = 0, days = 0, monthN = 0, ite = 0, SubItembIndex, mcount, yearN, monthOpen=0;
        string gr;
        int index = 0;
        bool read = false;

        //static string[] codes;
        List<string> codesList = new List<string>();

        //разрешение на изменение ячейки
        bool CancelEdit = false;
        //Текущий столбец
        ListViewItem.ListViewSubItem CurrentSubItem = default(ListViewItem.ListViewSubItem);
        //текущая строка таблицы
        ListViewItem CurrentItem = default(ListViewItem);           

        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Base.mdb;";
        private OleDbConnection myConnection;


        public Form10(string Cgr, string nazv, bool read, int monthR, int yearR)
        {
            InitializeComponent();
            this.Text = "Группа " + nazv;

            myConnection = new OleDbConnection(connectString);
            myConnection.Open();

            //какое число сегодня
            DateTime now = DateTime.Today;
            int day = Convert.ToInt32(now.Day);
            monthN = Convert.ToInt32(now.Month);
            yearN = Convert.ToInt32(now.Year);
            td();

            //определение количества дней в месяце
            monthOpen = monthN;
            days = Days();
            label11.Visible = false;
                        gr = Cgr;
            Vvod();

            if (Form1.Vcheck == false)
            {
                this.Height = 423;
                button1.Visible = false;
                button2.Visible = false;
                read = true;
                label11.Visible = true;
            }          
            Columns();
            List(monthN);
            menu();

        }

        //построение списка
        public void listCount()
        {
            //подсчет числа строк
            mcount = 0;
            string queryT = "SELECT '2' FROM " + monthN + " WHERE Группа=" + gr;
            OleDbCommand commandT = new OleDbCommand(queryT, myConnection);
            OleDbDataReader readerT = commandT.ExecuteReader();
            while (readerT.Read())
            {
                mcount++;
            }
            readerT.Close();
        }
        public void Vvod()
        {
            //определение количества записей
            listCount();
            //очистить массив
            codesList.Clear();
            //заполнить лист кодами нужных строк журнала
            count = 0;
            string query = "SELECT Код FROM " + monthN + " WHERE Группа=" + gr;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                codesList.Add(reader[0].ToString());
                count++;
            }
            reader.Close();
        }
        public void Columns()
        {
            listView1.Width = (days + 1) * 30 + 205;
           // MessageBox.Show(Convert.ToString(listView1.Width));
            this.Width = (days + 1) * 30 + 205 + 40;
           // MessageBox.Show(Convert.ToString(this.Width));
            listView2.Width = (days + 1) * 30 + 205;

            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("№", 30, HorizontalAlignment.Center);
            listView1.Columns.Add("ФИО", 200, HorizontalAlignment.Left);
            int d = 1;
            while (d <= days)
            {
                listView1.Columns.Add(d.ToString(), 30, HorizontalAlignment.Center);
                d++;
            }
        }
        public void List(int month)
        {
            count = 0;

            //получить воспитанника
            string query = "SELECT Воспитанник, Код FROM " + month + " WHERE Группа=" + gr;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string vosp = "";
                count++;
                string code = reader[0].ToString();

                //получить данные воспитанника
                string query1 = "SELECT Фамилия, Имя, Отчество FROM Воспитаники WHERE Код=" + code;
                OleDbCommand command1 = new OleDbCommand(query1, myConnection);
                OleDbDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    vosp = reader1[0].ToString() + " " + reader1[1].ToString() + " " + reader1[2].ToString();
                }
                reader1.Close();

                //получить посещаемость воспитанника за месяц
                string[] zap = new string[days + 2];
                for (int i = 0; i < days + 2; i++)
                {
                    if (i == 0)
                        zap[0] = count.ToString();
                    else if (i == 1)
                        zap[1] = vosp;
                    else
                    {
                        string queryD = "SELECT д" + (i - 1).ToString() + " FROM " + month + " WHERE Воспитанник=" + code;
                        zap[i] = ScalarCommand(queryD);
                    }
                }
                ListViewItem zapis = new ListViewItem(zap);
                listView1.Items.Add(zapis);
            }
            reader.Close();
            summery(month);
        }
        public void summery(int month)
        {
            //расчет итогов
            string search = "";
            listView2.Clear();
            listView2.View = View.Details;
            listView2.Columns.Add("№", 30, HorizontalAlignment.Center);
            listView2.Columns.Add("ФИО", 200, HorizontalAlignment.Left);

            int d = 1;
            while (d <= days)
            {
                listView2.Columns.Add(d.ToString(), 30, HorizontalAlignment.Center);
                d++;
            }


            for (int i = 0; i < 4; i++)
            {
                string[] sum = new string[days + 2];
                sum[0] = "";

                //заполнение боковины
                if (i == 0)
                {
                    sum[1] = "Присутствует";
                    search = "я";
                }
                else if (i == 1)
                {
                    sum[1] = "Отпуск";
                    search = "о";
                }
                else if (i == 2)
                {
                    sum[1] = "Домашние причины";
                    search = "д";
                }
                else if (i == 3)
                {
                    sum[1] = "Больничный";
                    search = "б";
                }

                //расчет
                for (int j = 2; j <= days + 1; j++)
                {
                    int c = 0;
                    bool space = false, weekand = false;
                    string query = "SELECT д" + (j - 1).ToString() + " FROM " + month + " WHERE Группа=" + gr;
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string ch = reader[0].ToString();
                        if (ch == search)
                            c++;
                        else if (ch == "")
                            space = true;
                        else if (ch == "-")
                            weekand = true;
                    }
                    reader.Close();
                    if (weekand == false && space == false)
                        sum[j] = c.ToString();
                    else if (weekand == true)
                        sum[j] = "-";
                    else if (space == true)
                        sum[j] = " ";
                }

                //добавление результатов в новый лист
                ListViewItem zapis = new ListViewItem(sum);
                listView2.Items.Add(zapis);
                //MessageBox.Show("обновил");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TClear();
        }
        //очистка листа и проставление выходных
        public void TClear()
        {
            for (int d = 1; d <= days; d++)
            {
                DateTime day = new DateTime(yearN, monthN, d);
                string Wday = day.DayOfWeek.ToString();
                if (Wday == "Saturday" || Wday == "Sunday")
                {
                    for (int i = 0; i < mcount; i++)
                    {
                        string query = "UPDATE " + monthN + " SET д" + d + " = '-' WHERE Код=" + codesList[i];
                        NoReturnCommand(query);
                    }
                }
                else
                {
                    for (int i = 0; i < mcount; i++)
                    {
                        string query = "UPDATE " + monthN + " SET д" + d + " = '' WHERE Код=" + codesList[i];
                        NoReturnCommand(query);
                    }
                }
            }
            Columns();
            List(monthOpen);
        }

        //сохранение ячейки
        public void save(int month)
        {
            string itemCode = codesList[ite - 1];
            string query = "UPDATE  " + month + " SET д" + (SubItembIndex - 1).ToString() + " = '" + textBox1.Text + "' WHERE Код = " + itemCode;
            NoReturnCommand(query);
        }


        //выбрать выходные
        private void button1_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12(days);
            f12.ShowDialog();

            //если число выходных не 0
            if (Form12.Wc != 0)
            {
                for (int j = 0; j < Form12.Wc; j++) //по кол-ву выходных дней
                {
                    for (int i = 0; i < mcount; i++)    //по строкам
                    {
                        string query = "UPDATE " + monthN + " SET д" + Form12.weekand[j] + " = '-' WHERE Код=" + codesList[i];
                        NoReturnCommand(query);
                    }
                }
                Vvod();
                Columns();
                List(monthN);
            }
        }


        //расчет показателей
        private void button2_Click(object sender, EventArgs e)
        {
            //проверка, что все заполнено
            string test1 = listView2.Items[0].SubItems[days + 1].Text;
            string test2 = listView2.Items[0].SubItems[days].Text;
            string test3 = listView2.Items[0].SubItems[days - 1].Text;
            if (test1 == " " || test1 == "-" && test2 == " " || test1 == "-" && test2 == "-" && test3 == " ")
                MessageBox.Show("Не все рабоиче дни заполнены");
            else
            {
                int y = 0, d = 0, b = 0, o = 0, w = 0;      //получение показателей
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 2; j < days + 2; j++)
                    {

                        if (listView2.Items[0].SubItems[j].ToString() != "ListViewSubItem: {-}")        //если не выходной
                        {
                            if (i == 0)
                            {
                                w++;
                                string text = listView2.Items[i].SubItems[j].Text;
                                int value;
                                int.TryParse(string.Join("", text.Where(c => char.IsDigit(c))), out value);     //получить число из строки ЛИСТ

                                y = y + value;
                            }
                            else if (i == 1)
                            {
                                string text = listView2.Items[i].SubItems[j].Text;
                                int value;
                                int.TryParse(string.Join("", text.Where(c => char.IsDigit(c))), out value);

                                o = o + value;
                            }
                            else if (i == 2)
                            {
                                string text = listView2.Items[i].SubItems[j].Text;
                                int value;
                                int.TryParse(string.Join("", text.Where(c => char.IsDigit(c))), out value);

                                d = d + value;
                            }
                            else if (i == 3)
                            {
                                string text = listView2.Items[i].SubItems[j].Text;
                                int value;
                                int.TryParse(string.Join("", text.Where(c => char.IsDigit(c))), out value);

                                b = b + value;
                            }
                        }
                    }
                }

                //расчет показателей
                int plan = 0;
                double indZ = 0, indB = 0;

                plan = mcount * w;
                indB = Math.Round(Convert.ToDouble(b) * 100 / plan, 2);
                indZ = Math.Round((Convert.ToDouble(y) + Convert.ToDouble(d) + Convert.ToDouble(o)) * 100 / plan, 2);

                //для перевода в нужный формат
                int B = b * 100 / plan;
                int Z = (y + d + o) * 100 / plan;
                string Bcut = "", Zcut = "";

                //обрезать, если больше 2-х знаков
                for (int i = 1; i < (indB - B).ToString().Length; i++)
                {
                    string str = (indB - B).ToString();
                    if (i < 4)
                        Bcut = Bcut + str[i];
                    Bcut = Bcut.Replace(",", ".");
                }
                for (int i = 1; i < (indZ - Z).ToString().Length; i++)
                {
                    string str = (indZ - Z).ToString();
                    if (i < 4)
                        Zcut = Zcut + str[i];
                    Zcut = Zcut.Replace(",", ".");      //поменять, на . 
                }

                //Результативная строка
                string strB = B.ToString() + Bcut;
                string strZ = Z.ToString() + Zcut;

                int month;
                //проверка текущий месяц или предыдущий
                if (monthN != monthOpen)
                    month = monthOpen;
                else
                    month = monthN;

                MessageBox.Show("Данные переданы!");    
                //перенос расчитанных параметров в итоговую таблицу
                string query = "SELECT Месяц, Год, План, ИндексЗдоровья, ИндексЗаболевания, Код  FROM Итоги WHERE Группа=" + gr;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                OleDbDataReader reader = command.ExecuteReader();
                int l = 0; //число записей данной группы
                int ok = 0; //число записей данной группы за текущий месяц
                while (reader.Read())
                {
                    l++;
                    string m = "", year = "";
                    m = reader[0].ToString();
                    year = reader[1].ToString();
                    if (m == month.ToString() && year == yearN.ToString())     //если запись уже существует, то обновить ее
                    {
                        ok++;
                        string query1 = "UPDATE Итоги SET План=" + plan + " WHERE Код = " + reader[5].ToString();
                        NoReturnCommand(query1);
                        query1 = "UPDATE Итоги SET ИндексЗдоровья=" + strZ + " WHERE Код = " + reader[5].ToString();
                        NoReturnCommand(query1);
                        query1 = "UPDATE Итоги SET ИндексЗаболевания=" + strB + " WHERE Код = " + reader[5].ToString();
                        NoReturnCommand(query1);
                    }
                }
                if (l == 0 || ok == 0)      //если записи не существует, создать новую
                {
                    string query1 = "INSERT INTO Итоги (Месяц, Год, Группа, План, ИндексЗдоровья, ИндексЗаболевания) VALUES (" + month + "," + yearN + "," + gr + "," + plan + "," + strZ + "," + strB + ")";
                    NoReturnCommand(query1);
                }
                reader.Close();
            }
        }


        //вспомогательное
        public string ScalarCommand(string query)
        {
            OleDbCommand command = new OleDbCommand(query, myConnection);
            string text = command.ExecuteScalar().ToString();
            return text;
        }
        public void NoReturnCommand(string query)
        {
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }


        //редактирование ячеек
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (label11.Visible == false)
            {
                // Получить текущий элемент ListView
                CurrentItem = listView1.GetItemAt(e.X, e.Y);
                if (CurrentItem == null)
                    return;

                // получить столбец
                CurrentSubItem = CurrentItem.GetSubItemAt(e.X, e.Y);
                SubItembIndex = CurrentItem.SubItems.IndexOf(CurrentSubItem);

                // проверка столбца
                while ((SubItembIndex < 2 || SubItembIndex > (days + 1) || index >= mcount) && read == false)
                    return;

                // задаем параметры TextBox, отображаем и делаем фокус
                if (read == false)
                {
                    int lLeft = CurrentSubItem.Bounds.Left + 2;
                    int lWidth = CurrentSubItem.Bounds.Width - 2;
                    textBox1.SetBounds(lLeft + listView1.Left, CurrentSubItem.Bounds.Top + listView1.Top, lWidth, CurrentSubItem.Bounds.Height);
                    textBox1.Text = CurrentSubItem.Text;
                    textBox1.Show();
                    textBox1.Focus();
                }
            }

        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Hide();
            if (CancelEdit == false)
            {
                CurrentSubItem.Text = textBox1.Text;
                save(monthOpen);
                summery(monthOpen);
                textBox1.Hide();
            }
            else
            {
                CancelEdit = false;
            }

            listView1.Focus();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char E = e.KeyChar;
            if ((E == 'я' || E == 'о' || E == 'д' || E == 'б') || E == (char)Keys.Back || E == (char)Keys.Delete)
                return;
            else
                e.Handled = true;

            switch (e.KeyChar)
            {
                // нажатие Enter копирует данные из  TextBox в ListView
                case (char)Keys.Enter:
                    save(monthOpen);
                    CancelEdit = false;
                    e.Handled = true;
                    textBox1.Hide();
                    break;

                // нажатие Escape отменит изменения в ListView 
                case (char)Keys.Escape:
                    CancelEdit = true;
                    e.Handled = true;
                    textBox1.Hide();
                    break;
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = listView1.FocusedItem.Index;
            if (index < mcount)
                ite = Convert.ToInt32(listView1.Items[index].SubItems[0].Text);
            //sub = Convert.ToInt32(listView1.FocusedItem.Su);
        }

        public void month_load(int m) {
            days = Days();
            Columns();
            List(m);
            if ((monthN == m || monthN == m+1) && Form1.Vcheck == true)
            {
                this.Height = 510;
                if (monthN == m)
                    button1.Visible = true;
                else
                    button1.Visible = false;
                button2.Visible = true;
                read = false;
                label11.Visible = false;
            }
            else
            {
                this.Height = 423;
                button1.Visible = false;
                button2.Visible = false;
                read = true;
                label11.Visible = true;
            }
            if (monthN == m)
                button3.Visible = true;
            else
                button3.Visible = false;

        }

        //открытие журналов за месяцы
        private void Menu1_Click(object sender, EventArgs e)
        {
            month_load(1);
        }
        private void Menu2_Click(object sender, EventArgs e)
        {
            month_load(2);
        }
        private void Menu3_Click(object sender, EventArgs e)
        {
            month_load(3);
        }
        private void Menu4_Click(object sender, EventArgs e)
        {
            month_load(4);
        }
        private void Menu5_Click(object sender, EventArgs e)
        {
            month_load(5);
        }
        private void Menu6_Click(object sender, EventArgs e)
        {
            month_load(6);
        }
        private void Menu7_Click(object sender, EventArgs e)
        {
            month_load(7);
        }
        private void Menu8_Click(object sender, EventArgs e)
        {
            month_load(8);
        }
        private void Menu9_Click(object sender, EventArgs e)
        {
            month_load(9);
        }
        private void Menu10_Click(object sender, EventArgs e)
        {
            month_load(10);
        }
        private void Menu11_Click(object sender, EventArgs e)
        {
            month_load(11);
        }
        private void Menu12_Click(object sender, EventArgs e)
        {
            month_load(12);
        }


        //вид меню
        public void menu() {
            if (monthN == 1)
            { 
                Menu1.Text = Menu1.Text + " " + yearN.ToString() + " (сейчас)";
                Menu2.Text = Menu2.Text + " " + (yearN-1).ToString();
                Menu3.Text = Menu3.Text + " " + (yearN - 1).ToString();
                Menu4.Text = Menu4.Text + " " + (yearN - 1).ToString();
                Menu5.Text = Menu5.Text + " " + (yearN - 1).ToString();
                Menu6.Text = Menu6.Text + " " + (yearN - 1).ToString();
                Menu7.Text = Menu7.Text + " " + (yearN - 1).ToString();
                Menu8.Text = Menu8.Text + " " + (yearN - 1).ToString();
                Menu9.Text = Menu9.Text + " " + (yearN - 1).ToString();
                Menu10.Text = Menu10.Text + " " + (yearN - 1).ToString();
                Menu11.Text = Menu11.Text + " " + (yearN - 1).ToString();
                Menu12.Text = Menu12.Text + " " + (yearN - 1).ToString();
            }
            else
            {
                Menu1.Text = Menu1.Text + " " + yearN.ToString();
                if (monthN == 2)
                {
                    Menu2.Text = Menu2.Text + " " + yearN.ToString() + " (сейчас)";
                    Menu3.Text = Menu3.Text + " " + (yearN - 1).ToString();
                    Menu4.Text = Menu4.Text + " " + (yearN - 1).ToString();
                    Menu5.Text = Menu5.Text + " " + (yearN - 1).ToString();
                    Menu6.Text = Menu6.Text + " " + (yearN - 1).ToString();
                    Menu7.Text = Menu7.Text + " " + (yearN - 1).ToString();
                    Menu8.Text = Menu8.Text + " " + (yearN - 1).ToString();
                    Menu9.Text = Menu9.Text + " " + (yearN - 1).ToString();
                    Menu10.Text = Menu10.Text + " " + (yearN - 1).ToString();
                    Menu11.Text = Menu11.Text + " " + (yearN - 1).ToString();
                    Menu12.Text = Menu12.Text + " " + (yearN - 1).ToString();
                }
                else
                {
                    Menu2.Text = Menu2.Text + " " + yearN.ToString();
                    if (monthN == 3)
                    {
                        Menu3.Text = Menu3.Text + " " + yearN.ToString() + " (сейчас)";
                        Menu4.Text = Menu4.Text + " " + (yearN - 1).ToString();
                        Menu5.Text = Menu5.Text + " " + (yearN - 1).ToString();
                        Menu6.Text = Menu6.Text + " " + (yearN - 1).ToString();
                        Menu7.Text = Menu7.Text + " " + (yearN - 1).ToString();
                        Menu8.Text = Menu8.Text + " " + (yearN - 1).ToString();
                        Menu9.Text = Menu9.Text + " " + (yearN - 1).ToString();
                        Menu10.Text = Menu10.Text + " " + (yearN - 1).ToString();
                        Menu11.Text = Menu11.Text + " " + (yearN - 1).ToString();
                        Menu12.Text = Menu12.Text + " " + (yearN - 1).ToString();
                    }
                    else
                    {
                        Menu3.Text = Menu3.Text + " " + yearN.ToString();
                        if (monthN == 4)
                        {
                            Menu4.Text = Menu4.Text + " " + yearN.ToString() + " (сейчас)";
                            Menu5.Text = Menu5.Text + " " + (yearN - 1).ToString();
                            Menu6.Text = Menu6.Text + " " + (yearN - 1).ToString();
                            Menu7.Text = Menu7.Text + " " + (yearN - 1).ToString();
                            Menu8.Text = Menu8.Text + " " + (yearN - 1).ToString();
                            Menu9.Text = Menu9.Text + " " + (yearN - 1).ToString();
                            Menu10.Text = Menu10.Text + " " + (yearN - 1).ToString();
                            Menu11.Text = Menu11.Text + " " + (yearN - 1).ToString();
                            Menu12.Text = Menu12.Text + " " + (yearN - 1).ToString();
                        }
                        else
                        {
                            Menu4.Text = Menu4.Text + " " + yearN.ToString();
                            if (monthN == 5)
                            {
                                Menu5.Text = Menu5.Text + " " + yearN.ToString() + " (сейчас)";
                                Menu6.Text = Menu6.Text + " " + (yearN - 1).ToString();
                                Menu7.Text = Menu7.Text + " " + (yearN - 1).ToString();
                                Menu8.Text = Menu8.Text + " " + (yearN - 1).ToString();
                                Menu9.Text = Menu9.Text + " " + (yearN - 1).ToString();
                                Menu10.Text = Menu10.Text + " " + (yearN - 1).ToString();
                                Menu11.Text = Menu11.Text + " " + (yearN - 1).ToString();
                                Menu12.Text = Menu12.Text + " " + (yearN - 1).ToString();
                            }
                            else
                            {
                                Menu5.Text = Menu5.Text + " " + yearN.ToString();
                                if (monthN == 6)
                                {
                                    Menu6.Text = Menu6.Text + " " + yearN.ToString() + " (сейчас)";
                                    Menu7.Text = Menu7.Text + " " + (yearN - 1).ToString();
                                    Menu8.Text = Menu8.Text + " " + (yearN - 1).ToString();
                                    Menu9.Text = Menu9.Text + " " + (yearN - 1).ToString();
                                    Menu10.Text = Menu10.Text + " " + (yearN - 1).ToString();
                                    Menu11.Text = Menu11.Text + " " + (yearN - 1).ToString();
                                    Menu12.Text = Menu12.Text + " " + (yearN - 1).ToString();
                                }
                                else {
                                    Menu6.Text = Menu6.Text + " " + yearN.ToString();
                                    if (monthN == 7)
                                    {
                                        Menu7.Text = Menu7.Text + " " + yearN.ToString() + " (сейчас)";
                                        Menu8.Text = Menu8.Text + " " + (yearN - 1).ToString();
                                        Menu9.Text = Menu9.Text + " " + (yearN - 1).ToString();
                                        Menu10.Text = Menu10.Text + " " + (yearN - 1).ToString();
                                        Menu11.Text = Menu11.Text + " " + (yearN - 1).ToString();
                                        Menu12.Text = Menu12.Text + " " + (yearN - 1).ToString();
                                    }
                                    else {
                                        Menu7.Text = Menu7.Text + " " + yearN.ToString();
                                        if (monthN == 8)
                                        {
                                            Menu8.Text = Menu8.Text + " " + yearN.ToString() + " (сейчас)";
                                            Menu9.Text = Menu9.Text + " " + (yearN - 1).ToString();
                                            Menu10.Text = Menu10.Text + " " + (yearN - 1).ToString();
                                            Menu11.Text = Menu11.Text + " " + (yearN - 1).ToString();
                                            Menu12.Text = Menu12.Text + " " + (yearN - 1).ToString();
                                        }
                                        else
                                        {
                                            Menu8.Text = Menu8.Text + " " + yearN.ToString();
                                            if (monthN == 9)
                                            {
                                                Menu9.Text = Menu9.Text + " " + yearN.ToString() + " (сейчас)";
                                                Menu10.Text = Menu10.Text + " " + (yearN - 1).ToString();
                                                Menu11.Text = Menu11.Text + " " + (yearN - 1).ToString();
                                                Menu12.Text = Menu12.Text + " " + (yearN - 1).ToString();
                                            }
                                            else {
                                                Menu9.Text = Menu9.Text + " " + yearN.ToString();
                                                if (monthN == 10)
                                                {
                                                    Menu10.Text = Menu10.Text + " " + yearN.ToString() + " (сейчас)";
                                                    Menu11.Text = Menu11.Text + " " + (yearN - 1).ToString();
                                                    Menu12.Text = Menu12.Text + " " + (yearN - 1).ToString();
                                                }
                                                else
                                                {
                                                    Menu10.Text = Menu10.Text + " " + yearN.ToString();
                                                    if (monthN == 11)
                                                    {
                                                        Menu11.Text = Menu11.Text + " " + yearN.ToString() + " (сейчас)";
                                                        Menu12.Text = Menu12.Text + " " + (yearN - 1).ToString();
                                                    }
                                                    else {
                                                        Menu11.Text = Menu11.Text + " " + yearN.ToString();
                                                        Menu12.Text = Menu12.Text + " " + yearN.ToString() + " (сейчас)";
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
        }

        //даты
        public int Days()
        {
            //проверка месяца
            DateTime now = DateTime.Today;
         
            int year = Convert.ToInt32(now.Year);
            int days = DateTime.DaysInMonth(year, monthOpen);
            return days;
        }
        public void td() {
            DateTime now = DateTime.Today;
            int day = Convert.ToInt32(now.Day);
            int m = Convert.ToInt32(now.Month);
            int y = Convert.ToInt32(now.Year);
            string Wday = now.DayOfWeek.ToString();
            label2.Text = day.ToString();
            if (m == 1)
                label2.Text = label2.Text + " января " + y.ToString() + " год, ";
            else if (m == 2)
                label2.Text = label2.Text + " февраля " + y.ToString() + " год, ";
            else if (m == 3)
                label2.Text = label2.Text + " марта " + y.ToString() + " год, ";
            else if (m == 4)
                label2.Text = label2.Text + " апреля " + y.ToString() + " год, ";
            else if (m == 5)
                label2.Text = label2.Text + " мая " + y.ToString() + " год, ";
            else if (m == 6)
                label2.Text = label2.Text + " июня " + y.ToString() + " год, ";
            else if (m == 7)
                label2.Text = label2.Text + " июля " + y.ToString() + " год, ";
            else if (m == 8)
                label2.Text = label2.Text + " августа " + y.ToString() + " год, ";
            else if (m == 9)
                label2.Text = label2.Text + " сентября " + y.ToString() + " год, ";
            else if (m == 10)
                label2.Text = label2.Text + " октября " + y.ToString() + " год, ";
            else if (m == 11)
                label2.Text = label2.Text + " ноября " + y.ToString() + " год, ";
            else if (m == 12)
                label2.Text = label2.Text + " декабря " + y.ToString() + " год, ";

            if (Wday=="Monday")
                label2.Text = label2.Text + " понедельник ";
            else if(Wday == "Tuesday")
                label2.Text = label2.Text + "  вторник ";
            else if(Wday == "Wednesday")
                label2.Text = label2.Text + " среда ";
            else if(Wday == "Thursday")
                label2.Text = label2.Text + " четверг ";
            else if(Wday == "Friday")
                label2.Text = label2.Text + " пятница ";
            else if(Wday == "Saturday")
                label2.Text = label2.Text + " суббота ";
            else if(Wday == "Sunday")
                label2.Text = label2.Text + " воскресенье ";
        }
    }
}
