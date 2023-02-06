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
    public partial class Form6 : Form
    {
        string code, CleanData = "", snomer = "", childCode;
        bool create, check = true;

        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Base.mdb;";
        private OleDbConnection myConnection;

        public Form6(string c, bool cr)
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
                button3.Visible = true;
            }
            else if (Form1.level == 1)
            {
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = false;
            }
        }

       
        private void Form6_Load(object sender, EventArgs e)
        {
            //режим просмотра
            if (create == false)
            {
                textBox1.ReadOnly = textBox2.ReadOnly = textBox3.ReadOnly = textBox4.ReadOnly = textBox5.ReadOnly = textBox6.ReadOnly = true;
                
                button1.Text = "Изменить";
                button2.Text = "Удалить";
                add();
                AddChild();
            }
            //режим создания
            else {
                button1.Text = "Сохранить";
                button2.Text = "Завершить";
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
        private void textBox6_KeyDown(object sender, KeyEventArgs e)
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


        //отлов клавиш в блоке Телефон
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char E = e.KeyChar;
            if ((E >= '0' && E <= '9') || E == (char)Keys.Back || E == (char)Keys.Delete || E == (char)Keys.Home || E == (char)Keys.End)
                return;
            else
                e.Handled = true;
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            snomer = Nomer(textBox6.Text);
            string nomer = Testing();
            textBox6.Text = nomer;
            if (nomer.Length >= 1)
            {
                if (snomer.Length == 1)
                    textBox6.SelectionStart = snomer.Length;
                else if (snomer.Length >= 2 && snomer.Length <= 4)
                    textBox6.SelectionStart = snomer.Length + 2;
                else if (snomer.Length >= 5 && snomer.Length <= 7)
                    textBox6.SelectionStart = snomer.Length + 4;
                else if (snomer.Length == 8 || snomer.Length == 9)
                    textBox6.SelectionStart = snomer.Length + 5;
                else if (snomer.Length >= 10 && snomer.Length <= 12)
                    textBox6.SelectionStart = snomer.Length + 6;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listView1.FocusedItem.Index;
            childCode = listView1.Items[index].SubItems[0].Text;
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(childCode, false);
            f2.ShowDialog();
            AddChild();
        }


        //Нажатие кнопок
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Изменить")
            {
                listView1.Clear();
                textBox1.ReadOnly = textBox2.ReadOnly = textBox3.ReadOnly = textBox4.ReadOnly = textBox5.ReadOnly = textBox6.ReadOnly = false;
                button1.Text = "Сохранить";
                button2.Text = "Завершить";
            }
            else if (button1.Text == "Сохранить")
            {
                
                check = true;
                string Sname, name, Fname, birth, work, phone;
                Sname = textBox1.Text;
                name = textBox2.Text;
                Fname = textBox3.Text;
                birth = textBox4.Text + " 00:00:00";
                work = textBox5.Text;
                phone = textBox6.Text;
                //если не заполнены поля
                if ((Sname.Length == 0) || (name.Length == 0) || (Fname.Length == 0) || (birth.Length == 0) || (phone.Length == 0))
                {
                    MessageBox.Show("Нужно обязательно укаазать:\n1. Фамилию\n2. Имя\n3. Отчество\n 4. Дату рождения\n5. Телефон");
                }
                //если все заполнено
                else
                {
                    //сохранение изменений
                    if (create == false)
                    {
                        string query = "UPDATE Родители SET Фамилия = '" + Sname + "' WHERE Код = " + code;
                        NoReturnCommand(query);

                        query = "UPDATE Родители SET Имя = '" + name + "' WHERE Код = " + code;
                        NoReturnCommand(query);

                        query = "UPDATE Родители SET Отчество = '" + Fname + "' WHERE Код = " + code;
                        NoReturnCommand(query);

                        query = "UPDATE Родители SET ДатаРождения = '" + birth + "' WHERE Код = " + code;
                        NoReturnCommand(query);

                        query = "UPDATE Родители SET МестоРаботы ='" + work + "' WHERE Код = " + code;
                        NoReturnCommand(query);

                        query = "UPDATE Родители SET Телефон = '" + phone + "' WHERE Код = " + code;
                        NoReturnCommand(query);

                        label8.Visible = true;

                    }
                    //добавление новой записи
                    else
                    {
                        string query = "INSERT INTO Родители (Фамилия, Имя, Отчество, ДатаРождения, МестоРаботы, Телефон) VALUES ('" + Sname + "','" + name + "','" + Fname + "','" + birth + "','" + work + "','" + phone + "')";
                        NoReturnCommand(query);

                        label8.Visible = true;
                        textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text =  "";

                        check = true;
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
                    string query = "DELETE FROM Родители WHERE Код=" + code;
                    NoReturnCommand(query);
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
                    label8.Visible = false;
                    textBox1.ReadOnly = textBox2.ReadOnly = textBox3.ReadOnly = textBox4.ReadOnly = textBox5.ReadOnly = textBox6.ReadOnly = true;
                    button1.Text = "Изменить";
                    button2.Text = "Удалить";
                    add();
                    AddChild();
                }
                //сбросить введенные данные по новой записи
                else if ((create == true) && (Form3.Finish == true) || check == true)
                {
                    Close();
                }

            }
        }


        //вспомогательное
        public void AddChild() {
            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("Код", 40, HorizontalAlignment.Center);
            listView1.Columns.Add("Фамилия", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Имя", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Отчество", 120, HorizontalAlignment.Center);
            listView1.Columns.Add("Дата рождения", 100, HorizontalAlignment.Center);

            string query = "SELECT Код, Фамилия, Имя, Отчество, ДатаРождения FROM Воспитаники WHERE Родитель1 = " + code;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string date1 = reader[4].ToString();
                ListViewItem zapis = new ListViewItem(new string[] { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), date1.Remove(10) });
                listView1.Items.Add(zapis);
            }
            query = "SELECT Код, Фамилия, Имя, Отчество, ДатаРождения FROM Воспитаники WHERE Родитель2 = " + code;
            OleDbCommand command1 = new OleDbCommand(query, myConnection);
            OleDbDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                string date1 = reader1[4].ToString();
                ListViewItem zapis = new ListViewItem(new string[] { reader1[0].ToString(), reader1[1].ToString(), reader1[2].ToString(), reader1[3].ToString(), date1.Remove(10) });
                listView1.Items.Add(zapis);
            }
            reader1.Close();
        }
        public void add()
        {
            string query = "SELECT Фамилия, Имя, Отчество, ДатаРождения, МестоРаботы, Телефон FROM Родители WHERE Код=" + code;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string date1 = reader[3].ToString();
                textBox1.Text = reader[0].ToString();
                textBox2.Text = reader[1].ToString();
                textBox3.Text = reader[2].ToString();
                textBox4.Text = date1.Remove(10);
                textBox5.Text = reader[4].ToString();
                textBox6.Text = reader[5].ToString();
            }
            reader.Close();
        }
        public void change()
        {
            check = false;
            label8.Visible = false;
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
        public string Nomer(string text)
        {
            string nomer = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != '-' && text[i] != ' ' && text[i] != '(' && text[i] != ')') nomer = nomer + text[i];

            }
            return nomer;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        public string Testing()
        {
            string nomer = "";
            int l = snomer.Length;
            if (l > 0)
            {
                if (l == 1)
                    nomer = snomer[0].ToString();
                else if (l == 2)
                    nomer = snomer[0].ToString() + " (" + snomer[1].ToString();
                else if (l == 3)
                    nomer = snomer[0].ToString() + " (" + snomer[1].ToString() + snomer[2].ToString();
                else if (l == 4)
                    nomer = snomer[0].ToString() + " (" + snomer[1].ToString() + snomer[2].ToString() + snomer[3].ToString() + ") ";
                else if (l == 5)
                    nomer = snomer[0].ToString() + " (" + snomer[1].ToString() + snomer[2].ToString() + snomer[3].ToString() + ") " + snomer[4].ToString();
                else if (l == 6)
                    nomer = snomer[0].ToString() + " (" + snomer[1].ToString() + snomer[2].ToString() + snomer[3].ToString() + ") " + snomer[4].ToString() + snomer[5].ToString();
                else if (l == 7)
                    nomer = snomer[0].ToString() + " (" + snomer[1].ToString() + snomer[2].ToString() + snomer[3].ToString() + ") " + snomer[4].ToString() + snomer[5].ToString() + snomer[6].ToString() + "-";
                else if (l == 8)
                    nomer = snomer[0].ToString() + " (" + snomer[1].ToString() + snomer[2].ToString() + snomer[3].ToString() + ") " + snomer[4].ToString() + snomer[5].ToString() + snomer[6].ToString() + "-" + snomer[7].ToString();
                else if (l == 9)
                    nomer = snomer[0].ToString() + " (" + snomer[1].ToString() + snomer[2].ToString() + snomer[3].ToString() + ") " + snomer[4].ToString() + snomer[5].ToString() + snomer[6].ToString() + "-" + snomer[7].ToString() + snomer[8].ToString() + "-";
                else if (l == 10)
                    nomer = snomer[0].ToString() + " (" + snomer[1].ToString() + snomer[2].ToString() + snomer[3].ToString() + ") " + snomer[4].ToString() + snomer[5].ToString() + snomer[6].ToString() + "-" + snomer[7].ToString() + snomer[8].ToString() + "-" + snomer[9].ToString();
                else if ((l == 11) || (l == 12))
                    nomer = snomer[0].ToString() + " (" + snomer[1].ToString() + snomer[2].ToString() + snomer[3].ToString() + ") " + snomer[4].ToString() + snomer[5].ToString() + snomer[6].ToString() + "-" + snomer[7].ToString() + snomer[8].ToString() + "-" + snomer[9].ToString() + snomer[10].ToString();
            }
            return nomer;

        }  
        public void NoReturnCommand(string query)
        {
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }
        public string ScalarCommand(string query)
        {
            OleDbCommand command = new OleDbCommand(query, myConnection);
            string text = command.ExecuteScalar().ToString();
            return text;
        }
        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

    } 
}
