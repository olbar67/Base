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
    public partial class Form7 : Form
    {
        string code, dol, kvalif, group, CleanData, groupBefor="";
        bool create, check = true;

        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Base.mdb;";
        private OleDbConnection myConnection;

        public Form7(string c, bool cr)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            code = c;
            create = cr;
            InitializeComponent();

            if (Form1.level == 3)
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = true;
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            //режим просмотра
            if (create == false)
            {
                textBox1.ReadOnly = textBox2.ReadOnly = textBox3.ReadOnly = textBox4.ReadOnly = textBox5.ReadOnly = textBox6.ReadOnly = true;
                textBox6.Visible = false;
                comboBox1.BackColor = comboBox2.BackColor = Color.FromArgb(240, 240, 240);

                comboBox1.BackColor = Color.FromArgb(240, 240, 240);

                button1.Text = "Изменить";
                button2.Text = "Удалить";
                button3.Visible = false;
                add();
            }
            //режим создания
            else
            {
                comboBox1.Items.Clear();
                string query = "SELECT Наименование FROM Должности ORDER BY Код";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[0].ToString());
                }
                reader.Close();

                comboBox2.Items.Clear();
                query = "SELECT Степень FROM Квалификация ORDER BY Код";
                OleDbCommand command2 = new OleDbCommand(query, myConnection);
                OleDbDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    comboBox2.Items.Add(reader2[0].ToString());
                }
                reader2.Close();
                button1.Text = "Сохранить";
                button2.Text = "Завершить";
                button3.Visible = false;

            }
        }

        //отлов изменений на форме
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            change();
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            change();
        }
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            change();
        }
        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            change();
        }
        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            change();
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            change();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            change();
            if (comboBox1.Text == "Воспитатель" || comboBox1.Text == "Помощник воспитателя")
                textBox6.Visible = button3.Visible = label10.Visible = true;
            else
                textBox6.Visible = button3.Visible = label10.Visible = false;

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            change();
        }


        //отлов клавиш в блоке Дата Рождения
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char E = e.KeyChar;
            if ((E >= '0' && E <= '9') || E == (char)Keys.Back || E == (char)Keys.Delete || E == (char)Keys.Home || E == (char)Keys.End)
                return;
            else
                e.Handled = true;
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            CleanData = dataClean(textBox4.Text);
            string data = dataTesting();
            textBox4.Text = data;
            if (CleanData.Length >= 1)
            {
                if (CleanData.Length == 2 || CleanData.Length == 1)
                    textBox4.SelectionStart = CleanData.Length;
                else if (CleanData.Length == 3 || CleanData.Length == 4)
                    textBox4.SelectionStart = CleanData.Length + 1;
                else if ((CleanData.Length > 4) && (CleanData.Length < 9))
                    textBox4.SelectionStart = CleanData.Length + 2;
            }
        }


        //отлов клавиш в блоке Дата начала работы
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char E = e.KeyChar;
            if ((E >= '0' && E <= '9') || E == (char)Keys.Back || E == (char)Keys.Delete || E == (char)Keys.Home || E == (char)Keys.End)
                return;
            else
                e.Handled = true;
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            CleanData = dataClean(textBox5.Text);
            string data = dataTesting();
            textBox5.Text = data;
            if (CleanData.Length >= 1)
            {
                if (CleanData.Length == 2 || CleanData.Length == 1)
                    textBox5.SelectionStart = CleanData.Length;
                else if (CleanData.Length == 3 || CleanData.Length == 4)
                    textBox5.SelectionStart = CleanData.Length + 1;
                else if ((CleanData.Length > 4) && (CleanData.Length < 9))
                    textBox5.SelectionStart = CleanData.Length + 2;
            }
        }


        //Нажатие кнопок
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Изменить")
            {
                if (textBox6.Text != "")
                    groupBefor = textBox6.Text;
                textBox1.ReadOnly = textBox2.ReadOnly = textBox3.ReadOnly = textBox4.ReadOnly = textBox5.ReadOnly = false;
                button1.Text = "Сохранить";
                button2.Text = "Завершить";
                if (textBox6.Visible == true)
                    button3.Visible = true;
                textBox6.BackColor = Color.White;

                comboBox1.BackColor = comboBox2.BackColor = Color.White;

                label8.Text = "00 лет, 00 мес.";

                string query = "SELECT Наименование FROM Должности ORDER BY Код";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[0].ToString());
                }
                reader.Close();

                comboBox2.Items.Clear();
                query = "SELECT Степень FROM Квалификация ORDER BY Код";
                OleDbCommand command2 = new OleDbCommand(query, myConnection);
                OleDbDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    comboBox2.Items.Add(reader2[0].ToString());
                }
                reader2.Close();

            }
            else if (button1.Text == "Сохранить")
            {
                check = true;
                string Sname, name, Fname, birth, work, dol, Sdol, kval, group;
                Sname = textBox1.Text;
                name = textBox2.Text;
                Fname = textBox3.Text;
                birth = textBox4.Text + " 00:00:00";
                work = textBox5.Text + " 00:00:00";
                dol = Sdol = comboBox1.Text;
                kval = comboBox2.Text;
                group = textBox6.Text;
                
                //group
                                
                if ((Sname.Length == 0) || (name.Length == 0) || (Fname.Length == 0) || (birth.Length == 0) || (dol.Length == 0) || ((dol == "Воспитатель") && (group.Length == 0)))
                {
                    MessageBox.Show("Нужно обязательно укаазать:\n1. Фамилию\n2. Имя\n3. Отчество\n 4. Дату рождения\n5. Должность\n6. Для воспитателя - группу");
                }
                 
                //если все заполнено
                else
                {
                    //сохранение изменений
                    if (create == false && check == true)
                    {
                        string query = "SELECT Код FROM Должности WHERE Наименование='" + dol + "'";
                        dol = ScalarCommand(query);

                        if (kval != "")
                        {
                            query = "SELECT Код FROM Квалификация WHERE Степень='" + kval + "'";
                            kval = ScalarCommand(query);
                        }

                        query = "UPDATE Сотрудники SET Фамилия = '" + Sname + "' WHERE Код = " + code;
                        NoReturnCommand(query);

                        query = "UPDATE Сотрудники SET Имя = '" + name + "' WHERE Код = " + code;
                        NoReturnCommand(query);

                        query = "UPDATE Сотрудники SET Отчество = '" + Fname + "' WHERE Код = " + code;
                        NoReturnCommand(query);

                        query = "UPDATE Сотрудники SET ДатаРождения = '" + birth + "' WHERE Код = " + code;
                        NoReturnCommand(query);

                        query = "UPDATE Сотрудники SET ДатаНачалаРаботы = '" + work + "' WHERE Код = " + code;
                        NoReturnCommand(query);

                        string stazh = stazhInFloat(work);
                        query = "UPDATE Сотрудники SET Стаж = '" + stazh + "' WHERE Код = " + code;
                        NoReturnCommand(query);

                        if (kval != "")
                        {
                            query = "UPDATE Сотрудники SET Квалификация = " + kval + " WHERE Код = " + code;
                            NoReturnCommand(query);
                        }

                        query = "UPDATE Сотрудники SET Должность = " + dol + " WHERE Код = " + code;
                        NoReturnCommand(query);

                        //ZAPIS GROUP(false, code)
                        if (group != "")
                            Group_change(code, Sdol, group);

                        label11.Visible = true;

                    }
                    //добавление новой записи
                    else if (create == true)
                    {
                        
                        string stazh = stazhInFloat(work);
                        string query = "SELECT Код FROM Должности WHERE Наименование='" + dol + "'";
                        dol = ScalarCommand(query);

                       
                        if (kval != "")
                        {
                            query = "SELECT Код FROM Квалификация WHERE Степень='" + kval + "'";
                            kval = ScalarCommand(query);
                            query = "INSERT INTO Сотрудники (Фамилия, Имя, Отчество, ДатаРождения, ДатаНачалаРаботы, Стаж, Квалификация, Должность) VALUES ('" + Sname + "','" + name + "','" + Fname + "','" + birth + "','" + work + "','" + stazh + "'," + kval + "," + dol + ")";
                            NoReturnCommand(query);

                        }
                        else if (kval == "")
                        {
                            query = "INSERT INTO Сотрудники (Фамилия, Имя, Отчество, ДатаРождения, ДатаНачалаРаботы, Стаж, Должность) VALUES ('" + Sname + "','" + name + "','" + Fname + "','" + birth + "','" + work + "','" + stazh + "'," + dol + ")";
                            NoReturnCommand(query);

                        }




                        //поиск кода созданного сотрудника
                        string newCode = "";
                        query = "SELECT Код FROM Сотрудники ORDER BY Код";
                        OleDbCommand commandC = new OleDbCommand(query, myConnection);
                        OleDbDataReader readerC = commandC.ExecuteReader();
                        while (readerC.Read())
                        {
                            newCode = readerC[0].ToString();
                        }
                        readerC.Close();

                        //создание логина
                        string log = Sname + name[0] + Fname[0];

                        //установка уровня доступа
                        int Idol = Convert.ToInt32(dol);
                        sbyte lev = 0;
                        if (Idol == 1)
                            lev = 1;
                        else if (Idol == 2 || Idol == 3)
                            lev = 2;
                        else if(Idol==4)
                            lev = 3;
                        else
                            lev = 4;

                        query = "INSERT INTO Вход (Логин, Сотрудник, Уровень) VALUES ('" + log + "'," + newCode + "," + lev + ")";
                        NoReturnCommand(query);

                        //ZAPIS GROUP(true, code, Sdol)
                        if (group != "")
                            Group_change(newCode, Sdol, group);


                        label11.Visible = true;
                        textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";

                        comboBox1.Items.Clear();
                        comboBox1.Text = "";
                        query = "SELECT Наименование FROM Должности ORDER BY Код";
                        OleDbCommand command = new OleDbCommand(query, myConnection);
                        OleDbDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader[0].ToString());
                        }
                        reader.Close();

                        comboBox2.Items.Clear();
                        comboBox2.Text = "";
                        query = "SELECT Степень FROM Квалификация ORDER BY Код";
                        OleDbCommand command2 = new OleDbCommand(query, myConnection);
                        OleDbDataReader reader2 = command2.ExecuteReader();
                        while (reader2.Read())
                        {
                            comboBox2.Items.Add(reader2[0].ToString());
                        }
                        reader2.Close();

                        button3.Visible = label10.Visible = textBox6.Visible= false;
                        check = true;
                        
                    }
                }
            }
        }

        public void Group_change(string code, string Sdol, string Sgroup) {
            string query = "SELECT Код FROM Группы WHERE Название='" + Sgroup + "'";
            string Qgroup = ScalarCommand(query);
            //MessageBox.Show(query);
            if (Sdol == "Воспитатель")
            {
                query = "SELECT Воспитатель1 FROM Группы WHERE Код=" + Qgroup;
                string vosp1 = ScalarCommand(query);
                query = "SELECT Воспитатель2 FROM Группы WHERE Код=" + Qgroup;
                string vosp2 = ScalarCommand(query);
                if (vosp1 == "" || vosp1 == "0")
                {
                    
                    query = "UPDATE Группы SET Воспитатель1 = " + code + " WHERE Код = " + Qgroup;
                    //MessageBox.Show(query);
                    NoReturnCommand(query);
                }
                else if (vosp2 == "" || vosp2 == "0")
                {

                    query = "UPDATE Группы SET Воспитатель2 = " + code + " WHERE Код = " + Qgroup;
                    NoReturnCommand(query);
                    
                }
                else if (vosp1 != code || vosp2 != code)
                {
                    MessageBox.Show("В группе уже указаны два воспитателя");
                    textBox6.Text = "";
                    check = false;
                }
                if (group != groupBefor && groupBefor!="")
                {
                    query = "SELECT Код FROM Группы WHERE Название='" + groupBefor + "'";
                    string QgroupB = ScalarCommand(query);
                    query = "SELECT Воспитатель1 FROM Группы WHERE Код=" + QgroupB;
                    vosp1 = ScalarCommand(query);

                    query = "SELECT Воспитатель2 FROM Группы WHERE Код=" + QgroupB;
                    vosp2 = ScalarCommand(query);
                    if (vosp1 == code)
                    {
                        query = "UPDATE Группы SET Воспитатель1 = 0  WHERE Код = " + QgroupB;
                        NoReturnCommand(query);
                    }
                    else if (vosp2 == code)
                    {
                        query = "UPDATE Группы SET Воспитатель2 = 0  WHERE Код = " + QgroupB;
                        NoReturnCommand(query);
                    }
                }
            }
            else if (Sdol == "Помощник воспитателя")
            {
                query = "SELECT Помощник FROM Группы WHERE Код=" + Qgroup;
                string pom = ScalarCommand(query);
                if (pom == "" || pom == "0")
                {
                    query = "UPDATE Группы SET Помощник = " + code + " WHERE Код = " + Qgroup;
                    NoReturnCommand(query);
                }
                else if (pom != code)
                {
                    MessageBox.Show("В группе уже указан помощник воспитателя");
                    textBox6.Text = "";
                    check = false;
                }
                if (group != groupBefor && groupBefor != "")
                {
                    query = "SELECT Код FROM Группы WHERE Название='" + groupBefor + "'";
                    string QgroupB = ScalarCommand(query);
                    query = "SELECT Помощник FROM Группы WHERE Код=" + QgroupB;
                    pom = ScalarCommand(query);
                    if (pom == code)
                    {
                        query = "UPDATE Группы SET Помощник = 0  WHERE Код = " + QgroupB;
                        NoReturnCommand(query);
                    }

                }
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Удалить")
            {
                Form4 f4 = new Form4();
                f4.ShowDialog();
                if (Form4.delete == true)
                {
                    string query = "DELETE FROM Сотрудники WHERE Код=" + code;
                    NoReturnCommand(query);

                    //удаление в группах

                    query = "SELECT Код, Название, Воспитатель1, Воспитатель2, Помощник FROM Группы ORDER BY Код";
                    OleDbCommand update_command = new OleDbCommand(query, myConnection);
                    OleDbDataReader reader = update_command.ExecuteReader();
                    while (reader.Read())
                    {
                        string vosp1 = reader[2].ToString();
                        if (vosp1 == code)
                        {
                            string query2 = "UPDATE Группы SET Воспитатель1 = '0' WHERE Код = " + reader[0].ToString();
                            OleDbCommand del_command = new OleDbCommand(query2, myConnection);
                            del_command.ExecuteNonQuery();
                        }

                        string vosp2 = reader[3].ToString();
                        if (vosp2 == code)
                        {
                            string query2 = "UPDATE Группы SET Воспитатель2 = '0' WHERE Код = " + reader[0].ToString();
                            OleDbCommand del_command = new OleDbCommand(query2, myConnection);
                            del_command.ExecuteNonQuery();
                        }

                        string helper = reader[4].ToString();
                        if (helper == code)
                        {
                            string query2 = "UPDATE Группы SET Помощник = '0' WHERE Код = " + reader[0].ToString();
                            OleDbCommand del_command = new OleDbCommand(query2, myConnection);
                            del_command.ExecuteNonQuery();
                        }
                    }

                    //удаление в паролях

                    query = "SELECT Код, Сотрудник FROM Вход ORDER BY Код";
                    OleDbCommand log_command = new OleDbCommand(query, myConnection);
                    reader = log_command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader[1].ToString() == code)
                        {
                            string query2 = "DELETE FROM Вход WHERE Код=" + reader[0].ToString();
                            OleDbCommand del_command = new OleDbCommand(query2, myConnection);
                            del_command.ExecuteNonQuery();
                        }

                    }


                    Close();
                }
            }
            else if (button2.Text == "Завершить")
            {
                //Завершение редактирования
                //если не было сохранено
                if (check == false)
                {
                    Form3 f3 = new Form3();
                    f3.ShowDialog();
                }
                //если Сохранено или Завершить без сохранения
                if ((create == false) && ((check == true) || ((check == false) && (Form3.Finish == true))))
                {
                    check = true;
                    comboBox1.Items.Clear();
                    comboBox2.Items.Clear();
                    label11.Visible = false;
                    textBox1.ReadOnly = textBox2.ReadOnly = textBox3.ReadOnly = textBox4.ReadOnly = textBox5.ReadOnly = textBox6.ReadOnly = true;
                    comboBox1.BackColor = comboBox2.BackColor = Color.FromArgb(240, 240, 240);
                    textBox6.BackColor = textBox6.BackColor = Color.FromArgb(240, 240, 240);
                    button1.Text = "Изменить";
                    button2.Text = "Удалить";
                    button3.Visible = false;
                    add();
                }
                //сбросить введенные данные по новой записи
                else if ((create == true) && (Form3.Finish == true) || check == true)
                {
                    Close();
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.ShowDialog();
            if (Form8.check == true)
            {
                group = Form8.Fcode;
                string queryP2 = "SELECT Название FROM Группы WHERE Код=" + group;
                OleDbCommand commandP2 = new OleDbCommand(queryP2, myConnection);
                OleDbDataReader readerP2 = commandP2.ExecuteReader();
                while (readerP2.Read())
                {
                    textBox6.Text = readerP2[0].ToString();
                }
                readerP2.Close();

            }
        }


        //вспомогательное
        public void change()
        {
            check = false;
            label11.Visible = false;
        }
        public void add()
        {
            string query = "SELECT Фамилия, Имя, Отчество, ДатаРождения, ДатаНачалаРаботы, Должность, Стаж, Квалификация FROM Сотрудники WHERE Код=" + code;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string date1 = reader[3].ToString();
                string date2 = reader[4].ToString();
                textBox1.Text = reader[0].ToString();
                textBox2.Text = reader[1].ToString();
                textBox3.Text = reader[2].ToString();
                textBox4.Text = date1.Remove(10);
                textBox5.Text = date2.Remove(10);

                stazhInString(reader[6].ToString());

                dol = reader[5].ToString();
                query = "SELECT Наименование FROM Должности WHERE Код=" + dol;
                comboBox1.Text = ScalarCommand(query);

                kvalif = reader[7].ToString();
                if (kvalif != "")
                {
                    query = "SELECT Степень FROM Квалификация WHERE Код=" + kvalif;
                    comboBox2.Text = ScalarCommand(query);
                }

                //заполнение группы
                if (comboBox1.Text == "Воспитатель" || comboBox1.Text == "Помощник воспитателя")
                {
                    query = "SELECT Название FROM Группы WHERE Воспитатель1 = " + code;
                    group = "";
                    OleDbCommand commandV1 = new OleDbCommand(query, myConnection);
                    OleDbDataReader readerV = commandV1.ExecuteReader();
                    while (readerV.Read())
                    {
                        group = readerV[0].ToString();
                    }
                    readerV.Close();
                    if (group == "")
                    {
                        query = "SELECT Название FROM Группы WHERE Воспитатель2 = " + code;
                        OleDbCommand commandV2 = new OleDbCommand(query, myConnection);
                        OleDbDataReader readerV2 = commandV2.ExecuteReader();
                        while (readerV2.Read())
                        {
                            group = readerV2[0].ToString();
                        }
                        readerV2.Close();
                        if (group == "")
                        {
                            query = "SELECT Название FROM Группы WHERE Помощник = " + code;
                            OleDbCommand commandP = new OleDbCommand(query, myConnection);
                            OleDbDataReader readerP = commandP.ExecuteReader();
                            while (readerP.Read())
                            {
                                group = readerP[0].ToString();
                            }
                            readerP.Close();
                        }
                    }
                    textBox6.Text = group;
                    textBox6.Visible = true;
                    label10.Visible = true;
                    textBox6.ReadOnly = true;
                }
            }
            reader.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        public string stazhInFloat(string date) {
            string Wdate = date;
            DateTime now = DateTime.Today;
            string day = Wdate[0].ToString() + Wdate[1].ToString();
            string month = Wdate[3].ToString() + Wdate[4].ToString();
            string year = Wdate[6].ToString() + Wdate[7].ToString() + Wdate[8].ToString() + Wdate[9].ToString();

            int dayN = Convert.ToInt32(now.Day);
            int monthN = Convert.ToInt32(now.Month);
            int yearN = Convert.ToInt32(now.Year);

            int dayS = Convert.ToInt32(day);
            int monthS = Convert.ToInt32(month);
            int yearS = Convert.ToInt32(year);

            int stY, stM=0;

            stY = yearN - yearS;
            if (monthS <= monthN && dayN >= dayS)
                stM = monthN - monthS;
            else if (monthS <= monthN && dayN < dayS)
                stM = monthN - monthS - 1;
            else if (monthS > monthN)
            {
                stY --;
                if (dayN >= dayS)
                    stM = 12 - (monthS - monthN);
                else if (dayN < dayS)
                    stM = 12 - (monthS - monthN) - 1;
            }
            string stazh = stY.ToString() + "," + stM.ToString();
            return stazh;
        }
        public void stazhInString (string stazh)
        {
            string st = stazh;
            bool cut = false;
            string stY = "", stM = "";
            for (int i = 0; i < st.Length; i++)
            {
                if (st[i].ToString() != "," && cut == false)
                    stY = stY + st[i].ToString();
                else if (st[i].ToString() != "," && cut == true)
                    stM = stM + st[i].ToString();
                else if (st[i].ToString() == ",")
                    cut = true;
                if (stM == "1")
                    stM = "10";
            }
            label8.Text = stY + " лет " + stM + " мес.";
        }
        public string ScalarCommand(string query)
        {
            OleDbCommand command = new OleDbCommand(query, myConnection);
            string text = command.ExecuteScalar().ToString();
            return text;
        }
        public string dataClean(string text)
        {
            string Dclean = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != '_' && text[i] != '.')
                    Dclean = Dclean + text[i];
            }
            return Dclean;
        }
        public string dataTesting()
        {
            string date = "";
            int l = CleanData.Length;
            if (l > 0)
            {
                if (l == 1)
                    date = CleanData[0] + "_.__.____";
                else if (l == 2)
                    date = CleanData[0].ToString() + CleanData[1].ToString() + ".__.____";
                else if (l == 3)
                    date = CleanData[0].ToString() + CleanData[1].ToString() + "." + CleanData[2].ToString() + "_.____";
                else if (l == 4)
                    date = CleanData[0].ToString() + CleanData[1].ToString() + "." + CleanData[2].ToString() + CleanData[3].ToString() + ".____";
                else if (l == 5)
                    date = CleanData[0].ToString() + CleanData[1].ToString() + "." + CleanData[2].ToString() + CleanData[3].ToString() + "." + CleanData[4].ToString() + "___";
                else if (l == 6)
                    date = CleanData[0].ToString() + CleanData[1].ToString() + "." + CleanData[2].ToString() + CleanData[3].ToString() + "." + CleanData[4].ToString() + CleanData[5].ToString() + "__";
                else if (l == 7)
                    date = CleanData[0].ToString() + CleanData[1].ToString() + "." + CleanData[2].ToString() + CleanData[3].ToString() + "." + CleanData[4].ToString() + CleanData[5].ToString() + CleanData[6].ToString() + "_";
                else if ((l == 8) || (l == 9))
                    date = CleanData[0].ToString() + CleanData[1].ToString() + "." + CleanData[2].ToString() + CleanData[3].ToString() + "." + CleanData[4].ToString() + CleanData[5].ToString() + CleanData[6].ToString() + CleanData[7].ToString();

            }
            return date;
        }
        public void NoReturnCommand(string query)
        {
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }
    }
}
