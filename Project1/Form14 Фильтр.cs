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
    public partial class Form14 : Form
    {
        
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Base.mdb;";
        private OleDbConnection myConnection;

        public Form14()
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            InitializeComponent();

            testG();
            chekingM();
            chekingY();
            chekingG();

        }



        public void testG()
        {
            string[] gr = new string[6];
            int c= 0;

            string query = "SELECT Код, Название FROM Группы ORDER BY Код";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                gr[c] = reader[1].ToString();
                c++;   
            }
            if (c > 0)
            {
                checkBox15.Text = gr[0];
                checkBox16.Text = gr[1];
                
                if (c > 2)
                {
                    checkBox17.Text = gr[2];
                    if (c > 3)
                    {
                        checkBox18.Text = gr[3];
                        if (c > 4)
                        {
                            checkBox19.Text = gr[4];
                            if (c > 5)
                                checkBox20.Text = gr[5];
                        }
                    }
                }
            }
            if (c < 6)
            {
                checkBox20.Visible = false;
                if (c < 5)
                {
                    checkBox19.Visible = false;
                    if (c < 4)
                    {
                        checkBox18.Visible = false;
                        if (c < 3)
                            checkBox17.Visible = false;
                    }
                }
            }
        }

        public void chekingM() {
            if (Form13.listM.Find(x => x == "01") == "01")
                checkBox1.Checked = true;
            else checkBox1.Checked = false;
            if (Form13.listM.Find(x => x == "02") == "02")
                checkBox2.Checked = true;
            else checkBox2.Checked = false;
            if (Form13.listM.Find(x => x == "03") == "03")
                checkBox3.Checked = true;
            else checkBox3.Checked = false;
            if (Form13.listM.Find(x => x == "04") == "04")
                checkBox4.Checked = true;
            else checkBox4.Checked = false;
            if (Form13.listM.Find(x => x == "05") == "05")
                checkBox5.Checked = true;
            else checkBox5.Checked = false;
            if (Form13.listM.Find(x => x == "06") == "06")
                checkBox6.Checked = true;
            else checkBox6.Checked = false;
            if (Form13.listM.Find(x => x == "07") == "07")
                checkBox7.Checked = true;
            else checkBox7.Checked = false;
            if (Form13.listM.Find(x => x == "08") == "08")
                checkBox8.Checked = true;
            else checkBox8.Checked = false;
            if (Form13.listM.Find(x => x == "09") == "09")
                checkBox9.Checked = true;
            else checkBox9.Checked = false;
            if (Form13.listM.Find(x => x == "10") == "10")
                checkBox10.Checked = true;
            else checkBox10.Checked = false;
            if (Form13.listM.Find(x => x == "11") == "11")
                checkBox11.Checked = true;
            else checkBox11.Checked = false;
            if (Form13.listM.Find(x => x == "12") == "12")
                checkBox12.Checked = true;
            else checkBox12.Checked = false;

        }
        public void chekingY()
        {
            if (Form13.listY.Find(x => x == "2019") == "2019")
                checkBox13.Checked = true;
            else checkBox13.Checked = false;
            if (Form13.listY.Find(x => x == "2020") == "2020")
                checkBox14.Checked = true;
            else checkBox14.Checked = false; 
        }
        public void chekingG()
        {
            if (Form13.listG.Find(x => x == "1") == "1")
                checkBox15.Checked = true;
            else checkBox15.Checked = false;
            if (Form13.listG.Find(x => x == "2") == "2")
                checkBox16.Checked = true;
            else checkBox16.Checked = false;
            if (Form13.listG.Find(x => x == "3") == "3")
                checkBox17.Checked = true;
            else checkBox17.Checked = false;
            if (Form13.listG.Find(x => x == "4") == "4")
                checkBox18.Checked = true;
            else checkBox18.Checked = false;
            if (Form13.listG.Find(x => x == "5") == "5")
                checkBox19.Checked = true;
            else checkBox19.Checked = false;
            if (Form13.listG.Find(x => x == "6") == "6")
                checkBox20.Checked = true;
            else checkBox20.Checked = false;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form13.countM = 0;
            Form13.countY = 0;
            Form13.countG = 0;
            Form13.listM.Clear();
            Form13.listY.Clear();
            Form13.listG.Clear();

            if (checkBox1.Checked == true)
            {
                Form13.countM++;
                Form13.listM.Add("01");
            }
            if (checkBox2.Checked == true)
            {
                Form13.countM++;
                Form13.listM.Add("02");
            }

            if (checkBox3.Checked == true)
            {
                Form13.countM++;
                Form13.listM.Add("03");
            }
            if (checkBox4.Checked == true)
            {
                Form13.countM++;
                Form13.listM.Add("04");
            }
            if (checkBox5.Checked == true)
            {
                Form13.countM++;
                Form13.listM.Add("05");
            }
            if (checkBox6.Checked == true)
            {
                Form13.countM++;
                Form13.listM.Add("06");
            }
            if (checkBox7.Checked == true)
            {
                Form13.countM++;
                Form13.listM.Add("07");
            }
            if (checkBox8.Checked == true)
            {
                Form13.countM++;
                Form13.listM.Add("08");
            }
            if (checkBox9.Checked == true)
            {
                Form13.countM++;
                Form13.listM.Add("09");
            }
            if (checkBox10.Checked == true)
            {
                Form13.countM++;
                Form13.listM.Add("10");
            }
            if (checkBox11.Checked == true)
            {
                Form13.countM++;
                Form13.listM.Add("11");
            }
            if (checkBox12.Checked == true)
            {
                Form13.countM++;
                Form13.listM.Add("12");
            }

            if (checkBox13.Checked == true)
            {
                Form13.countY++;
                Form13.listY.Add("2020");
            }
            if (checkBox14.Checked == true)
            {
                Form13.countY++;
                Form13.listY.Add("2021");
            }
            if (checkBox21.Checked == true)
            {
                Form13.countY++;
                Form13.listY.Add("2022");
            }
            if (checkBox22.Checked == true)
            {
                Form13.countY++;
                Form13.listY.Add("2023");
            }

            if (checkBox15.Checked == true)
            {
                Form13.countG++;
                Form13.listG.Add("1");
            }
            if (checkBox16.Checked == true)
            {
                Form13.countG++;
                Form13.listG.Add("2");
            }
            if (checkBox17.Checked == true)
            {
                Form13.countG++;
                Form13.listG.Add("3");
            }
            if (checkBox18.Checked == true)
            {
                Form13.countG++;
                Form13.listG.Add("4");
            }
            if (checkBox19.Checked == true)
            {
                Form13.countG++;
                Form13.listG.Add("5");
            }
            if (checkBox20.Checked == true)
            {
                Form13.countG++;
                Form13.listG.Add("6");
            }

            Close();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = checkBox2.Checked = checkBox3.Checked = checkBox4.Checked = checkBox5.Checked = checkBox6.Checked = checkBox7.Checked = checkBox8.Checked = checkBox9.Checked = checkBox10.Checked = false;
            checkBox11.Checked = checkBox12.Checked = checkBox13.Checked = checkBox14.Checked = checkBox15.Checked = checkBox16.Checked = checkBox17.Checked = checkBox18.Checked = checkBox19.Checked = checkBox20.Checked = false;
            Form13.countM=0;
            Form13.countY = 0;
            Form13.countG = 0;
            Form13.listM.Clear();
            Form13.listY.Clear();
            Form13.listG.Clear();
        }




        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Form13.countM++;
                Form13.listM.Add("01");
            }
            else
            {
                Form13.listM.Remove("01");
                Form13.countM--;
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                Form13.countM++;
                Form13.listM.Add("02");
            }
            else
            {
                Form13.listM.Remove("02");
                Form13.countM--;
            }
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                Form13.countM++;
                Form13.listM.Add("03");
            }
            else
            {
                Form13.listM.Remove("03");
                Form13.countM--;
            }
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                Form13.countM++;
                Form13.listM.Add("04");
            }
            else
            {
                Form13.listM.Remove("04");
                Form13.countM--;
            }
        }
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                Form13.countM++;
                Form13.listM.Add("05");
            }
            else
            {
                Form13.listM.Remove("05");
                Form13.countM--;
            }
        }
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                Form13.countM++;
                Form13.listM.Add("06");
            }
            else
            {
                Form13.listM.Remove("06");
                Form13.countM--;
            }
        }
        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                Form13.countM++;
                Form13.listM.Add("07");
            }
            else
            {
                Form13.listM.Remove("07");
                Form13.countM--;
            }
        }
        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                Form13.countM++;
                Form13.listM.Add("08");
            }
            else
            {
                Form13.listM.Remove("08");
                Form13.countM--;
            }
        }
        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                Form13.countM++;
                Form13.listM.Add("09");
            }
            else
            {
                Form13.listM.Remove("09");
                Form13.countM--;
            }
        }
        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == true)
            {
                Form13.countM++;
                Form13.listM.Add("10");
            }
            else
            {
                Form13.listM.Remove("10");
                Form13.countM--;
            }
        }
        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked == true)
            {
                Form13.countM++;
                Form13.listM.Add("11");
            }
            else
            {
                Form13.listM.Remove("11");
                Form13.countM--;
            }
        }
        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked == true)
            {
                Form13.countM++;
                Form13.listM.Add("12");
            }
            else
            {
                Form13.listM.Remove("12");
                Form13.countM--;
            }
        }


        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox13.Checked == true)
            {
                Form13.countY++;
                Form13.listY.Add("2019");
            }
            else
            {
                Form13.listY.Remove("2019");
                Form13.countY--;
            }
        }
        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked == true)
            {
                Form13.countY++;
                Form13.listY.Add("2020");
            }
            else
            {
                Form13.listY.Remove("2020");
                Form13.countY--;
            }
        }


        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked == true)
            {
                Form13.countG++;
                Form13.listG.Add("1");
            }
            else
            {
                Form13.listG.Remove("1");
                Form13.countG--;
            }
        }
        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox16.Checked == true)
            {
                Form13.countG++;
                Form13.listG.Add("2");
            }
            else
            {
                Form13.listG.Remove("2");
                Form13.countG--;
            }
        }
        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked == true)
            {
                Form13.countG++;
                Form13.listG.Add("3");
            }
            else
            {
                Form13.listG.Remove("3");
                Form13.countG--;
            }
        }
        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox18.Checked == true)
            {
                Form13.countG++;
                Form13.listG.Add("4");
            }
            else
            {
                Form13.listG.Remove("4");
                Form13.countG--;
            }
        }
        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox19.Checked == true)
            {
                Form13.countG++;
                Form13.listG.Add("5");
            }
            else
            {
                Form13.listG.Remove("5");
                Form13.countG--;
            }
        }
        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox20.Checked == true)
            {
                Form13.countG++;
                Form13.listG.Add("6");
            }
            else
            {
                Form13.listG.Remove("6");
                Form13.countG--;
            }
        }
    }
}
