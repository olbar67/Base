using System;
using System.Globalization;
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
    public partial class Form1 : Form
    {
        internal static int level = 0, sotr=0;
        internal static bool Vcheck = false;
        
        int mode=0, count;
        string code="";
        
        bool create;
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Base.mdb;";
        //public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=base1.mdb;";
        private OleDbConnection myConnection;

        public Form1()
        {
            Form15 f15 = new Form15();
            f15.ShowDialog();



            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            InitializeComponent();

            if (level == 3)
            {
                bNew.Visible = false;
                bDelete.Visible = false;
                войтиToolStripMenuItem.Visible = false;
            }
            else if (level == 1)
            {
                паролиToolStripMenuItem.Visible = true;
                войтиToolStripMenuItem.Visible = false;
            }
            else if (level == 0)
            {
                bNew.Enabled = false;
                bMore.Enabled = false;
                bDelete.Enabled = false;
                button1.Enabled = false;
                Search.Enabled = false;
                bChildren.Enabled = false;
                bParents.Enabled = false;
                bWorkers.Enabled = false;
                bGroup.Enabled = false;
                jhgToolStripMenuItem.Enabled = false;
                поискToolStripMenuItem.Enabled = false;
                помощьToolStripMenuItem.Enabled = false;
                паролиToolStripMenuItem.Enabled = false;
                войтиToolStripMenuItem.Visible = true;
            }

        }

        //проверка входа
        public void log() {
            Form15 f15 = new Form15();
            f15.ShowDialog();

            if (level == 3)
            {
                bNew.Visible = false;
                bDelete.Visible = false;
                войтиToolStripMenuItem.Visible = false;

                bNew.Enabled = true;
                bMore.Enabled = true;
                bDelete.Enabled = true;
                button1.Enabled = true;
                Search.Enabled = true;
                bChildren.Enabled = true;
                bParents.Enabled = true;
                bWorkers.Enabled = true;
                bGroup.Enabled = true;
                jhgToolStripMenuItem.Enabled = true;
                поискToolStripMenuItem.Enabled = true;
                помощьToolStripMenuItem.Enabled = true;
                паролиToolStripMenuItem.Enabled = true;
                войтиToolStripMenuItem.Visible = false;
            }
            else if (level == 1)
            {
                паролиToolStripMenuItem.Visible = true;
                войтиToolStripMenuItem.Visible = false;

                bNew.Enabled = true;
                bMore.Enabled = true;
                bDelete.Enabled = true;
                button1.Enabled = true;
                Search.Enabled = true;
                bChildren.Enabled = true;
                bParents.Enabled = true;
                bWorkers.Enabled = true;
                bGroup.Enabled = true;
                jhgToolStripMenuItem.Enabled = true;
                поискToolStripMenuItem.Enabled = true;
                помощьToolStripMenuItem.Enabled = true;
                паролиToolStripMenuItem.Enabled = true;
                войтиToolStripMenuItem.Visible = false;
            }
            else if (level == 0)
            {
                bNew.Enabled = false;
                bMore.Enabled = false;
                bDelete.Enabled = false;
                button1.Enabled = false;
                Search.Enabled = false;
                bChildren.Enabled = false;
                bParents.Enabled = false;
                bWorkers.Enabled = false;
                bGroup.Enabled = false;
                jhgToolStripMenuItem.Enabled = false;
                поискToolStripMenuItem.Enabled = false;
                помощьToolStripMenuItem.Enabled = false;
                паролиToolStripMenuItem.Enabled = false;
                войтиToolStripMenuItem.Visible = true;
            }
        }

        //заполнение списка
        public void Columns(int mode)
        {
            listView1.Clear();
            listView1.View = View.Details;
            if (mode > 0 && mode < 4)
            {
                listView1.Columns.Add("Код", 60, HorizontalAlignment.Center);
                listView1.Columns.Add("Фамилия", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("Имя", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("Отчество", 200, HorizontalAlignment.Center);
                listView1.Columns.Add("Дата рождения", 150, HorizontalAlignment.Center);

                if (mode == 1)
                {
                    listView1.Columns.Add("Группа", 148, HorizontalAlignment.Center);
                }
                if (mode == 2)
                {
                    listView1.Columns.Add("Телефон", 148, HorizontalAlignment.Center);
                }
                if (mode == 3)
                {
                    listView1.Columns.Add("Должность", 148, HorizontalAlignment.Center);
                }
            }
            else if (mode == 4) {
                listView1.Columns.Add("Код", 60, HorizontalAlignment.Center);
                listView1.Columns.Add("Название", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("Воспитатель 1", 180, HorizontalAlignment.Center);
                listView1.Columns.Add("Воспитатель 2", 180, HorizontalAlignment.Center);
                listView1.Columns.Add("Помощник", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("Кол-во детей", 140, HorizontalAlignment.Center);
                }
        }
        public void ChidrenList() {
            
            count = 0;
            code = "";
            string query = "SELECT Код, Фамилия, Имя, Отчество, ДатаРождения, Группа FROM Воспитаники ORDER BY Код";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                count++;
                string date1 = reader[4].ToString();
                string gr = reader[5].ToString();
                string queryH = "SELECT Название FROM Группы WHERE Код=" + gr;
                if (gr != "" && gr!="0")
                {
                    OleDbCommand commandH = new OleDbCommand(queryH, myConnection);
                    gr = commandH.ExecuteScalar().ToString();
                }
                else
                    gr = "";
                ListViewItem zapis = new ListViewItem(new string[] { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), date1.Remove(10), gr });
                listView1.Items.Add(zapis);
            }
            label2.Text = count.ToString();
            reader.Close();
        }
        public void ParentList() {
            count = 0;
            code = "";
            string query = "SELECT Код, Фамилия, Имя, Отчество, ДатаРождения, Телефон FROM Родители ORDER BY Код";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                count++;
                string date1 = reader[4].ToString();
                ListViewItem zapis = new ListViewItem(new string[] { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), date1.Remove(10), reader[5].ToString() });
                listView1.Items.Add(zapis);
            }
            label2.Text = count.ToString();
            reader.Close();
        }
        public void WorkerList() {
            count = 0;
            code = "";
            string query = "SELECT Код, Фамилия, Имя, Отчество, ДатаРождения, Должность FROM Сотрудники ORDER BY Код";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                count++;
                string date1 = reader[4].ToString();
                string dol = reader[5].ToString();
                string queryDol = "SELECT Наименование FROM Должности WHERE Код=" + dol;
                OleDbCommand commandDol = new OleDbCommand(queryDol, myConnection); 
                dol = commandDol.ExecuteScalar().ToString();
                ListViewItem zapis = new ListViewItem(new string[] { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), date1.Remove(10), dol });
                listView1.Items.Add(zapis); 
            }
            label2.Text = count.ToString();
            reader.Close();
        }
        public void GroupList() {
            count = 0;
            code = "";
            string query = "SELECT Код, Название, Воспитатель1, Воспитатель2, Помощник FROM Группы ORDER BY Код";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
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
                

                

                int CHcount = 0;
                query = "SELECT Код FROM Воспитаники WHERE Группа=" + reader[0];
                OleDbCommand command1 = new OleDbCommand(query, myConnection);
                OleDbDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    CHcount++;
                }
               
                    ListViewItem zapis = new ListViewItem(new string[] { reader[0].ToString(), reader[1].ToString(), vosp1, vosp2, helper,CHcount.ToString() });
                    listView1.Items.Add(zapis);
                    count++;
            }
            label2.Text = count.ToString();
        }

        //загрузка списка из базы
        private void bChildren_Click(object sender, EventArgs e)
        {
            mode = 1;
            Columns(mode);
            ChidrenList();
            кодуToolStripMenuItem.Text = "Коду";
            фамилииToolStripMenuItem.Text = "Фамилии";
            имениToolStripMenuItem.Text = "Имени";
            отчествуToolStripMenuItem.Text = "Отчеству";
            датеРожденияToolStripMenuItem.Text = "Дате рождения";
            п1ToolStripMenuItem.Visible = true;
            п1ToolStripMenuItem.Text = "Группе";

            bDelete.Visible = true;
        }
        private void bParents_Click(object sender, EventArgs e)
        {
            mode = 2;
            Columns(mode);
            ParentList();
            кодуToolStripMenuItem.Text = "Коду";
            фамилииToolStripMenuItem.Text = "Фамилии";
            имениToolStripMenuItem.Text = "Имени";
            отчествуToolStripMenuItem.Text = "Отчеству";
            датеРожденияToolStripMenuItem.Text = "Дате рождения";
            п1ToolStripMenuItem.Visible = false;

            bDelete.Visible = true;
        }
        private void bWorkers_Click(object sender, EventArgs e)
        {
            mode = 3;
            Columns(mode);
            WorkerList();
            кодуToolStripMenuItem.Text = "Коду";
            фамилииToolStripMenuItem.Text = "Фамилии";
            имениToolStripMenuItem.Text = "Имени";
            отчествуToolStripMenuItem.Text = "Отчеству";
            датеРожденияToolStripMenuItem.Text = "Дате рождения";
            п1ToolStripMenuItem.Visible = true;
            п1ToolStripMenuItem.Text = "Должности";

            bDelete.Visible = true;
        }
        private void bGroup_Click(object sender, EventArgs e)
        {
            mode = 4;
            Columns(mode);
            GroupList();
            кодуToolStripMenuItem.Text = "Коду";
            фамилииToolStripMenuItem.Text = "Названию";
            имениToolStripMenuItem.Text = "Первому воспитателю";
            отчествуToolStripMenuItem.Text = "Второму воспитателю";
            датеРожденияToolStripMenuItem.Text = "Помощнику";
            п1ToolStripMenuItem.Visible = true;
            п1ToolStripMenuItem.Text = "Количеству детей";

            bDelete.Visible = false;
        }

        //индекс таблицы
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listView1.FocusedItem.Index;
            code = listView1.Items[index].SubItems[0].Text;
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (code != "")
            {
                if (mode == 1)
                {
                    Form2 f2 = new Form2(code, false);
                    f2.ShowDialog();
                }
                if (mode == 2)
                {
                    Form6 f6 = new Form6(code, false);
                    f6.ShowDialog();
                    Reload();
                }
                if (mode == 3)
                {
                    Form7 f7 = new Form7(code, false);
                    f7.ShowDialog();
                    Reload();
                }
                if (mode == 4)
                {
                    Form9 f9 = new Form9(code);
                    f9.ShowDialog();
                    Reload();
                }
            }
            Reload();
        }
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                Columns(mode);
                if (mode == 1)
                    ChidrenList();
                else if (mode == 2)
                    ParentList();
                else if (mode == 3)
                    WorkerList();
            }
            else if (e.Column != 5)
                sort(e.Column);
        }


        //основные функции
        private void bNew_Click(object sender, EventArgs e)
        {
            create = true;
            code = "";
            if (mode == 1)
            {
                Form2 f2 = new Form2(code, create);
                f2.ShowDialog();
            }
            if (mode == 2)
            {
                Form6 f6 = new Form6(code, create);
                f6.ShowDialog();
                Reload();
            }
            if (mode == 3)
            {
                Form7 f7 = new Form7(code, create);
                f7.ShowDialog();
                Reload();
            }
            if (mode == 4)
            {
                string result = Microsoft.VisualBasic.Interaction.InputBox("Введите Название группы:");
                string query = "INSERT INTO Группы (Название) VALUES ('"+ result + "')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
                Reload();
            }
            Reload();
        }
        private void bMore_Click(object sender, EventArgs e)
        {
            create = false;
            if (code != "") {
                if (mode == 1)
                {
                    Form2 f2 = new Form2(code,create);
                    f2.ShowDialog();
                    
                }
                if (mode == 2)
                {
                    Form6 f6 = new Form6(code, create);
                    f6.ShowDialog();
                    Reload();
                }
                if (mode == 3)
                {
                    Form7 f7 = new Form7(code, create);
                    f7.ShowDialog();
                    Reload();
                }
                if (mode == 4)
                {
                    Form9 f9 = new Form9(code);
                    f9.ShowDialog();
                }
                
            }
            Reload();
        }
        private void bDelete_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
            if (Form4.delete == true)
            {
                if (mode == 1)
                {
                    string query = "DELETE FROM Воспитаники WHERE Код=" + code;
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();

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


                }
                else if (mode == 2)
                {
                    string query = "DELETE FROM Родители WHERE Код=" + code;
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();
                    Reload();
                }
                else if (mode == 3)
                {
                    string query = "DELETE FROM Сотрудники WHERE Код=" + code;
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();
                    

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
                    Reload();
                }
            }
            Reload();
        }

        //открытие журнала
        private void Search_Click(object sender, EventArgs e)
        {
            if (level == 1 || level == 2)
            {
                Form11 f11 = new Form11();
                f11.ShowDialog();
            }
            else
            {
                bool check = false;
                string cgr = "";

                string query = "SELECT Код FROM Группы WHERE Воспитатель1=" + sotr;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                cgr = command.ExecuteScalar().ToString();
                if (cgr != "")
                {
                    query = "SELECT Название FROM Группы WHERE Воспитатель1=" + sotr;
                    OleDbCommand command1 = new OleDbCommand(query, myConnection);
                    string nazv = command1.ExecuteScalar().ToString();

                    check = true;
                    Vcheck = true;

                    Form10 f10 = new Form10(cgr, nazv, false, 0, 0);
                    DateTime now = DateTime.Today;
                    int year = Convert.ToInt32(now.Year);
                    int month = Convert.ToInt32(now.Month);
                    int days = DateTime.DaysInMonth(year, month);
                    f10.Width = (days + 1) * 30 + 205 + 40;
                    f10.ShowDialog();
                }
                else {
                    query = "SELECT Код FROM Группы WHERE Воспитатель2=" + sotr;
                    OleDbCommand command1 = new OleDbCommand(query, myConnection);
                    cgr = command1.ExecuteScalar().ToString();

                    query = "SELECT Название FROM Группы WHERE Воспитатель2=" + sotr;
                    OleDbCommand command2 = new OleDbCommand(query, myConnection);
                    string nazv = command2.ExecuteScalar().ToString();

                    if (cgr != "")
                    {
                        check = true;
                        Vcheck = true;
                        Form10 f10 = new Form10(cgr, nazv, false, 0, 0);
                        DateTime now = DateTime.Today;
                        int year = Convert.ToInt32(now.Year);
                        int month = Convert.ToInt32(now.Month);
                        int days = DateTime.DaysInMonth(year, month);
                        f10.Width = (days + 1) * 30 + 205 + 40;
                        f10.Width = 1205;
                        f10.ShowDialog();

                    }
                    
                }

                if (check == false)
                {
                    Form11 f11 = new Form11();
                    f11.ShowDialog();
                }
            }
        }


        //меню
        private void кодуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Columns(mode);
            if (mode == 1)
                ChidrenList();
            else if (mode == 2)
                ParentList();
            else if (mode == 3)
                WorkerList();

        }
        private void фамилииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sort(1);
        }
        private void имениToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sort(2);
        }
        private void отчествуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sort(3);
        }
        private void датеРожденияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sort(4);
        }
        private void п1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sort(5);
        }
        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form17 f17 = new Form17();
            f17.ShowDialog();
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        //прочее
        public void Reload()
        {
            for (int i = 0; i < 3; i++)
            {
                Columns(mode);
                
                

                if (mode == 1)
                    ChidrenList();
                else if (mode == 2)
                    ParentList();
                else if (mode == 3)
                    WorkerList();
                else if (mode == 4)
                    GroupList();
            }
            //MessageBox.Show("i'm here!");
        }
        public void sort(int sort) {
            string[,] list = new string[count,6];

            for (int i = 0; i < count; i++)
                for (int j = 0; j < 6; j++)
                {
                    string text = listView1.Items[i].SubItems[j].Text;
                    list[i, j] = text;
                }
            
            for (int repeat = 0; repeat < count; repeat++) {
                for (int i = 0; i < count-1 ; i++) {
                    sbyte zamena = 0;
                    if (sort > 0 && sort < 4 || sort==5) //если сравнение по текстовым полям
                    {
                        if (String.Compare(list[i, sort], list[i + 1, sort], true) > 0)
                            zamena++;
                        else if (String.Compare(list[i, sort], list[i + 1, sort], true) == 0 && String.Compare(list[i, 0], list[i + 1, 0], true) > 0)
                            zamena++;
                    }
                    else if (sort == 4)
                    {
                        DateTime date1 = new DateTime();
                        date1 = Convert.ToDateTime(list[i, 4]);
                        DateTime date2 = new DateTime();
                        date2 = Convert.ToDateTime(list[i+1, 4]);
                        if (date1.CompareTo(date2) > 0)
                            zamena++;
                        else if (date1.CompareTo(date2) == 0 && String.Compare(list[i, 0], list[i + 1, 0], true) > 0)
                            zamena++;
                    }
                    if (zamena == 1)
                        for (int j = 0; j < 6; j++)
                        {
                            string temp = list[i, j];
                            list[i, j] = list[i + 1, j];
                            list[i + 1, j] = temp;
                        }

                }
            }
            Columns(mode);
            for (int i = 0; i < count; i++)
            {
                ListViewItem zapis = new ListViewItem(new string[] { list[i, 0], list[i, 1], list[i, 2], list[i, 3], list[i, 4], list[i, 5] });
                listView1.Items.Add(zapis);
            }
        }

        public string ScalarCommand(string query)
        {
            OleDbCommand command = new OleDbCommand(query, myConnection);
            string text = command.ExecuteScalar().ToString();
            return text;
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5(true);
            f5.Width = 900;
            f5.ShowDialog();
        }

        private void паролиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form16 f16 = new Form16();
            f16.ShowDialog();
        }

        private void войтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form13 f13 = new Form13();
            f13.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }
    }
}
