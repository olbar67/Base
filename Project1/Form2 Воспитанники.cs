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
    public partial class Form2 : Form
    {
        string code, helth, parent1, parent2="", CleanData="", group, grBefor="";
        bool create, check = true;


        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Base.mdb;";
        private OleDbConnection myConnection;

        public Form2(string c, bool cr)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            code = c;
            create = cr;
            InitializeComponent();

            if (Form1.level == 3)
            {
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = true;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //режим просмотра
            if (create == false)
            {
                textBox1.ReadOnly = textBox2.ReadOnly = textBox3.ReadOnly = textBox4.ReadOnly = textBox7.ReadOnly= textBox8.ReadOnly = textBox9.ReadOnly = true;
                comboBox1.BackColor = Color.FromArgb(240, 240, 240);

                button1.Text = "Подробнее";
                button2.Text = "Подробнее";
                button3.Text = "Изменить";
                button4.Text = "Удалить";
                button5.Visible = false;
                add();
            } 
            //режим создания
            else
            {
                string query = "SELECT Наименование FROM ГруппыЗдоровья ORDER BY Код";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[0].ToString());
                }
                reader.Close();
                button1.Text = "Изменить";
                button2.Text = "Изменить";
                button3.Text = "Сохранить";
                button4.Text = "Завершить";
                button5.Visible = true;
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
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            change();

        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            change();
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            change();
        }
        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            change();
        }
        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            change();
        }
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            change();
        }
        
        //отлов клавиш в блоке Дата
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
        
       



        //Нажатие кнопок
        //Изменение родителей
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Изменить")
            {
                Form5 f5 = new Form5(false);
                f5.Width = 800;
                f5.ShowDialog();
                if (Form5.check == true) {
                    parent1 = Form5.Fcode;
                    string queryP1 = "SELECT Фамилия, Имя, Отчество FROM Родители WHERE Код=" + parent1;
                    OleDbCommand commandP1 = new OleDbCommand(queryP1, myConnection);
                    OleDbDataReader readerP1 = commandP1.ExecuteReader();
                    while (readerP1.Read())
                    {
                        textBox5.Text = readerP1[0].ToString() + " " + readerP1[1].ToString() + " " + readerP1[2].ToString();
                    }
                    readerP1.Close();

                }
            }
            else if (button1.Text == "Подробнее") {
                Form6 f6 = new Form6(parent1, false);
                f6.ShowDialog();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Изменить")
            {
                Form5 f5 = new Form5(false);
                f5.Width = 800;
                f5.ShowDialog();
                if (Form5.check == true)
                {
                    parent2 = Form5.Fcode;
                    string queryP2 = "SELECT Фамилия, Имя, Отчество FROM Родители WHERE Код=" + parent2;
                    OleDbCommand commandP2 = new OleDbCommand(queryP2, myConnection);
                    OleDbDataReader readerP2 = commandP2.ExecuteReader();
                    while (readerP2.Read())
                    {
                        textBox6.Text = readerP2[0].ToString() + " " + readerP2[1].ToString() + " " + readerP2[2].ToString();
                    }
                    readerP2.Close();

                }
            }
            else if (button1.Text == "Подробнее") {
                Form6 f6 = new Form6(parent1, false);
                f6.ShowDialog();
            }
        }

        //Системные кнопки
        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Изменить")
            {
                check = false;
                textBox1.ReadOnly = textBox2.ReadOnly = textBox3.ReadOnly = textBox4.ReadOnly =  textBox8.ReadOnly = textBox9.ReadOnly = false;
                button1.Text = "Изменить";
                button2.Text = "Изменить";
                button3.Text = "Сохранить";
                button4.Text = "Завершить";
                button5.Visible = true;
                
                comboBox1.BackColor = Color.White;
                textBox5.BackColor = textBox6.BackColor = textBox7.BackColor = Color.White;

                string query = "SELECT Наименование FROM ГруппыЗдоровья ORDER BY Код";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[0].ToString());
                }

                reader.Close();

            }
            else if (button3.Text == "Сохранить")
            {
                check = true;
                string Sname, name, Fname, birth, helth, diagnoz, adress, group;
                Sname = textBox1.Text;
                name = textBox2.Text;
                Fname = textBox3.Text;
                birth = textBox4.Text + " 00:00:00";
                helth = comboBox1.Text;
                diagnoz = textBox8.Text;
                adress = textBox9.Text;
                group = textBox7.Text;
                string Qgroup="";
                //если не заполнены поля
                if ((Sname.Length == 0) || (name.Length == 0) || (Fname.Length == 0) || (birth.Length == 0) || (helth.Length == 0) || (parent1 == null) || (group.Length == 0))
                {
                    MessageBox.Show("Нужно обязательно укаазать:\n1. Фамилию\n2. Имя\n3. Отчество\n 4. Дату рождения\n5. Группу здоровья\n6. Хотя бы одного родителя\n7. Группу");
                }
                //если все заполнено
                else
                {
                    //сохранение изменений
                    if (create == false)
                    {
                       
                        string query = "SELECT Код FROM ГруппыЗдоровья WHERE Наименование='" + helth + "'";
                        helth = ScalarCommand(query);

                        query = "UPDATE Воспитаники SET Фамилия = '" + Sname + "' WHERE Код = " + code;
                        NoReturnCommand(query);

                        query = "UPDATE Воспитаники SET Имя = '" + name + "' WHERE Код = " + code;
                        NoReturnCommand(query);

                        query = "UPDATE Воспитаники SET Отчество = '" + Fname + "' WHERE Код = " + code;
                        NoReturnCommand(query);

                        query = "UPDATE Воспитаники SET ДатаРождения = '" + birth + "' WHERE Код = " + code;
                        NoReturnCommand(query);

                        query = "UPDATE Воспитаники SET ГруппаЗдоровья=" + helth + " WHERE Код = " + code;
                        NoReturnCommand(query);

                        query = "UPDATE Воспитаники SET Родитель1=" + parent1 + " WHERE Код = " + code;
                        NoReturnCommand(query);

                        if (parent2 != "")
                        {
                            query = "UPDATE Воспитаники SET Родитель2=" + parent2 + " WHERE Код = " + code;
                            NoReturnCommand(query);
                        }

                        query = "UPDATE Воспитаники SET Диагноз = '" + diagnoz + "' WHERE Код = " + code;
                        NoReturnCommand(query);

                        query = "UPDATE Воспитаники SET Адрес = '" + adress + "' WHERE Код = " + code;
                        NoReturnCommand(query);

                        if (group != "")
                        {
                            query = "SELECT Код FROM Группы WHERE Название='" + group + "'";
                            Qgroup = ScalarCommand(query);
                        
                        
                            query = "UPDATE Воспитаники SET Группа=" + Qgroup + " WHERE Код = " + code;
                            NoReturnCommand(query);
                            //если изменили группу
                            if (group != grBefor && grBefor != "")
                            {
                                //проверка месяца
                                DateTime now = DateTime.Today;
                                int monthN = Convert.ToInt32(now.Month);

                                query = "UPDATE " + monthN.ToString() + " SET Группа=" + Qgroup + " WHERE Воспитанник = " + code;
                                NoReturnCommand(query);
                            }
                            else if (group != grBefor && grBefor == "")
                            {
                                //проверка месяца
                                DateTime now = DateTime.Today;
                                int monthN = Convert.ToInt32(now.Month);

                                query = "INSERT INTO " + monthN.ToString() + " (Воспитанник, Группа) VALUES (" + code + "," + Qgroup + ")";
                                NoReturnCommand(query);
                            }
                        }
                        //если группа была удалена
                        else if (Qgroup == "" && grBefor != "")
                        {
                            DateTime now = DateTime.Today;
                            int monthN = Convert.ToInt32(now.Month);

                            query = "DELETE FROM " + monthN.ToString() + " WHERE Воспитанник=" + code;
                            NoReturnCommand(query);
                            query = "UPDATE Воспитаники SET Группа = 0 WHERE Код = " + code;
                            NoReturnCommand(query);
                        }
                        
                        label10.Visible = true;

                    }
                    //добавление новой записи
                    else
                    {
                        string query = "SELECT Код FROM Группы WHERE Название='" + group + "'";
                        Qgroup = ScalarCommand(query);

                         query = "SELECT Код FROM ГруппыЗдоровья WHERE Наименование='" + helth + "'";
                        helth = ScalarCommand(query);
                        if (parent2 == "" && group=="")
                        {
                            query = "INSERT INTO Воспитаники (Фамилия, Имя, Отчество, ДатаРождения, ГруппаЗдоровья, Диагноз, Адрес, Родитель1) VALUES ('" + Sname + "','" + name + "','" + Fname + "','" + birth + "'," + helth + ",'" + diagnoz + "','" + adress + "', " + parent1 + ")";
                            NoReturnCommand(query);

                        }
                        else if (parent2 != "" && group == "")
                        {
                            query = "INSERT INTO Воспитаники (Фамилия, Имя, Отчество, ДатаРождения, ГруппаЗдоровья, Диагноз, Адрес, Родитель1, Родитель2) VALUES ('" + Sname + "','" + name + "','" + Fname + "','" + birth + "'," + helth + ",'" + diagnoz + "','" + adress + "', " + parent1 + ","+ parent2 + ")";
                            NoReturnCommand(query);
                        }
                        if (parent2 == "" && group != "")
                        {
                            query = "INSERT INTO Воспитаники (Фамилия, Имя, Отчество, ДатаРождения, ГруппаЗдоровья, Диагноз, Адрес, Родитель1, Группа) VALUES ('" + Sname + "','" + name + "','" + Fname + "','" + birth + "'," + helth + ",'" + diagnoz + "','" + adress + "', " + parent1 + ", "+Qgroup+")";
                            NoReturnCommand(query);

                        }
                        else if (parent2 != "" && group != "")
                        {
                            query = "INSERT INTO Воспитаники (Фамилия, Имя, Отчество, ДатаРождения, ГруппаЗдоровья, Диагноз, Адрес, Родитель1, Родитель2, Группа) VALUES ('" + Sname + "','" + name + "','" + Fname + "','" + birth + "'," + helth + ",'" + diagnoz + "','" + adress + "', " + parent1 + "," + parent2 + ", " + Qgroup + ")";
                            NoReturnCommand(query);
                        }

                        //проверка наличия группы
                        if (group != "")
                        {
                            query = "SELECT Код FROM Группы WHERE Название='" + group + "'";
                            Qgroup = ScalarCommand(query);//

                            //проверка месяца
                            DateTime now = DateTime.Today;
                            int monthN = Convert.ToInt32(now.Month);

                            //поиск кода созданного воспитанника
                            string newCode = "";
                            query = "SELECT Код FROM Воспитаники ORDER BY Код";
                            OleDbCommand commandC = new OleDbCommand(query, myConnection);
                            OleDbDataReader readerC = commandC.ExecuteReader();
                            while (readerC.Read())
                            {
                                newCode = readerC[0].ToString();
                            }
                            readerC.Close();

                            
                            query = "INSERT INTO "+ monthN.ToString() +" (Воспитанник, Группа) VALUES (" + newCode + "," + Qgroup + ")";
                            NoReturnCommand(query);
                            

                        }


                        label10.Visible = true;
                        textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = "";

                        comboBox1.Items.Clear();
                        comboBox1.Text = "";
                        query = "SELECT Наименование FROM ГруппыЗдоровья ORDER BY Код";
                        OleDbCommand command = new OleDbCommand(query, myConnection);
                        OleDbDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader[0].ToString());
                        }
                        reader.Close();
                        check = true;
                        parent1 = parent2 = "";
                        Close();
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Удалить")
            {
                Form4 f4 = new Form4();
                f4.ShowDialog();
                if (Form4.delete == true) {
                    string query = "DELETE FROM Воспитаники WHERE Код=" + code;
                    NoReturnCommand(query);
                    
                    
                    //удаление в журналах

                    for (int i = 1; i <= 12; i++)
                    {
                        query = "SELECT Код, Воспитанник FROM " + i + " ORDER BY Код";
                        OleDbCommand update_command = new OleDbCommand(query, myConnection);
                        OleDbDataReader reader = update_command.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader[1].ToString() == code)
                            {
                                string query2 = "DELETE FROM " + i + " WHERE Код=" + reader[0].ToString();
                                OleDbCommand del_command = new OleDbCommand(query2, myConnection);
                                del_command.ExecuteNonQuery();
                            }

                        }
                    }

                    Close();
                }
            }
            else if (button4.Text == "Завершить")
            {
                //Завершение редактирования
                //если не было сохранено
                if (check == false) {
                    Form3 f3 = new Form3();
                    f3.ShowDialog();
                    if (Form3.Finish == true)        //Отменить изменения и закрыть
                    {
                        Close();
                        Form3.Finish = false;
                    }
                    else         //Сохранить изменения и закрыть
                    {
                        //button3.PerformClick();
                        //Close();
                    }

                }
                //если Сохранено и это режим Изменения
                else if (check == true && create==false)
                {
                    check = false;
                    comboBox1.Items.Clear();
                    label10.Visible = false;
                    textBox1.ReadOnly = textBox2.ReadOnly = textBox3.ReadOnly = textBox4.ReadOnly = textBox7.ReadOnly = textBox8.ReadOnly = textBox9.ReadOnly = true;
                    comboBox1.BackColor = Color.FromArgb(240, 240, 240);
                    textBox5.BackColor = textBox6.BackColor  = Color.FromArgb(240, 240, 240);
                    button1.Text = "Подробнее";
                    button2.Text = "Подробнее";
                    button3.Text = "Изменить";
                    button4.Text = "Удалить";
                    button5.Visible = false;
                    add();
                    Close();
                }
                //сбросить введенные данные по новой записи
                else if (check == true && create == true)
                {
                    Close();
                }
                
            }
        }
        private void button5_Click(object sender, EventArgs e)
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
                    textBox7.Text = readerP2[0].ToString();
                }
                readerP2.Close();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }


        //вспомогательное
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
        public void add() {
            string query = "SELECT Фамилия, Имя, Отчество, ДатаРождения, ГруппаЗдоровья, Диагноз, Адрес, Родитель1, Родитель2, Группа FROM Воспитаники WHERE Код=" + code;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string date1 = reader[3].ToString();
                textBox1.Text = reader[0].ToString();
                textBox2.Text = reader[1].ToString();
                textBox3.Text = reader[2].ToString();
                textBox4.Text = date1.Remove(10);
                helth = reader[4].ToString();
                string queryH = "SELECT Наименование FROM ГруппыЗдоровья WHERE Код=" + helth;
                comboBox1.Text = ScalarCommand(queryH);

                textBox8.Text = reader[5].ToString();
                textBox9.Text = reader[6].ToString();

                parent1 = reader[7].ToString();
                string queryP1 = "SELECT Фамилия, Имя, Отчество FROM Родители WHERE Код=" + parent1;
                OleDbCommand commandP1 = new OleDbCommand(queryP1, myConnection);
                OleDbDataReader readerP1 = commandP1.ExecuteReader();
                while (readerP1.Read())
                {
                    textBox5.Text = readerP1[0].ToString() + " " + readerP1[1].ToString() + " " + readerP1[2].ToString();
                }
                readerP1.Close();

                parent2 = reader[8].ToString();
                if (parent2 != "")
                {
                    string queryP2 = "SELECT Фамилия, Имя, Отчество FROM Родители WHERE Код=" + parent2;
                    OleDbCommand commandP2 = new OleDbCommand(queryP2, myConnection);
                    OleDbDataReader readerP2 = commandP2.ExecuteReader();
                    while (readerP2.Read())
                    {
                        textBox6.Text = readerP2[0].ToString() + " " + readerP2[1].ToString() + " " + readerP2[2].ToString();
                    }
                    readerP2.Close();
                }

                group = reader[9].ToString();
                if (group != "" && group != "0")
                {
                    string query2 = "SELECT Название FROM Группы WHERE Код=" + group;
                    textBox7.Text = ScalarCommand(query2);
                    grBefor = textBox7.Text;
                }
                else if (group == "0")
                    group = "";
            }
            reader.Close();
        }
        public void change() {
            check = false;
            label10.Visible = false;
        }
        public void NoReturnCommand(string query) {
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }
        public string ScalarCommand(string query) {
            OleDbCommand command = new OleDbCommand(query, myConnection);
            string text = command.ExecuteScalar().ToString();//
            return text;
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }
    }

}
