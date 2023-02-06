using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class Form12 : Form
    {
        internal static List<string> weekand = new List<string>();
        internal static int Wc=0;
        internal static bool done = false;

        public Form12(int days)
        {
            InitializeComponent();
            done = false;
            if (days < 31)
            {
                checkBox31.Visible = false;
                if (days < 30)
                {
                    checkBox30.Visible = false;
                    if (days < 29)
                        checkBox29.Visible = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            { weekand.Add("1"); Wc++; }
            if (checkBox2.Checked == true)
            { weekand.Add("2"); Wc++; }
            if (checkBox3.Checked == true)
            { weekand.Add("3"); Wc++; }
            if (checkBox4.Checked == true)
            { weekand.Add("4"); Wc++; }
            if (checkBox5.Checked == true)
            { weekand.Add("5"); Wc++; }
            if (checkBox6.Checked == true)
            { weekand.Add("6"); Wc++; }
            if (checkBox7.Checked == true)
            { weekand.Add("7"); Wc++; }
            if (checkBox8.Checked == true)
            { weekand.Add("8"); Wc++; }
            if (checkBox9.Checked == true)
            { weekand.Add("9"); Wc++; }
            if (checkBox10.Checked == true)
            { weekand.Add("10"); Wc++; }
            if (checkBox11.Checked == true)
            { weekand.Add("11"); Wc++; }
            if (checkBox12.Checked == true)
            { weekand.Add("12"); Wc++; }
            if (checkBox13.Checked == true)
            { weekand.Add("13"); Wc++; }
            if (checkBox14.Checked == true)
            { weekand.Add("14"); Wc++; }
            if (checkBox15.Checked == true)
            { weekand.Add("15"); Wc++; }
            if (checkBox16.Checked == true)
            { weekand.Add("16"); Wc++; }
            if (checkBox17.Checked == true)
            { weekand.Add("17"); Wc++; }
            if (checkBox18.Checked == true)
            { weekand.Add("18"); Wc++; }
            if (checkBox19.Checked == true)
            { weekand.Add("19"); Wc++; }
            if (checkBox20.Checked == true)
            { weekand.Add("20"); Wc++; }
            if (checkBox21.Checked == true)
            { weekand.Add("21"); Wc++; }
            if (checkBox22.Checked == true)
            { weekand.Add("22"); Wc++; }
            if (checkBox23.Checked == true)
            { weekand.Add("23"); Wc++; }
            if (checkBox24.Checked == true)
            { weekand.Add("24"); Wc++; }
            if (checkBox25.Checked == true)
            { weekand.Add("25"); Wc++; }
            if (checkBox26.Checked == true)
            { weekand.Add("26"); Wc++; }
            if (checkBox27.Checked == true)
            { weekand.Add("27"); Wc++; }
            if (checkBox28.Checked == true)
            { weekand.Add("28"); Wc++; }
            if (checkBox29.Checked == true)
            { weekand.Add("29"); Wc++; }
            if (checkBox30.Checked == true)
            { weekand.Add("30"); Wc++; }
            if (checkBox31.Checked == true)
            { weekand.Add("31"); Wc++; }
            done = true;
            Close();
        }
    }
}
