namespace Project1
{
    partial class Form10
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form10));
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.button2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.открытьЖурналToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu3 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu4 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu5 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu6 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu7 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu8 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu9 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu10 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu11 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu12 = new System.Windows.Forms.ToolStripMenuItem();
            this.label11 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 63);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1109, 238);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(68, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Сегодня";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(152, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1238, 436);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 24);
            this.textBox1.TabIndex = 3;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 382);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Я - явка";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 400);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "О - отпуск";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 420);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "Д - домашние причины";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 438);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 18);
            this.label6.TabIndex = 7;
            this.label6.Text = "Б - больничный";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(226, 402);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 18);
            this.label7.TabIndex = 8;
            this.label7.Text = "Стереть - Backspace";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(226, 420);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 18);
            this.label8.TabIndex = 9;
            this.label8.Text = "Сохранить - Enter";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(226, 440);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 18);
            this.label9.TabIndex = 10;
            this.label9.Text = "Отмена - Esc ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(707, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 27);
            this.button1.TabIndex = 11;
            this.button1.Text = "Отметить выходные";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView2
            // 
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(12, 298);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(1109, 81);
            this.listView2.TabIndex = 12;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(879, 31);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(196, 27);
            this.button2.TabIndex = 13;
            this.button2.Text = "Рассчитать показатели";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(226, 382);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(186, 18);
            this.label10.TabIndex = 14;
            this.label10.Text = "Изменить - двойной клик";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьЖурналToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1156, 28);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // открытьЖурналToolStripMenuItem
            // 
            this.открытьЖурналToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu1,
            this.Menu2,
            this.Menu3,
            this.Menu4,
            this.Menu5,
            this.Menu6,
            this.Menu7,
            this.Menu8,
            this.Menu9,
            this.Menu10,
            this.Menu11,
            this.Menu12});
            this.открытьЖурналToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.открытьЖурналToolStripMenuItem.Name = "открытьЖурналToolStripMenuItem";
            this.открытьЖурналToolStripMenuItem.Size = new System.Drawing.Size(137, 24);
            this.открытьЖурналToolStripMenuItem.Text = "Открыть журнал";
            // 
            // Menu1
            // 
            this.Menu1.Name = "Menu1";
            this.Menu1.Size = new System.Drawing.Size(158, 26);
            this.Menu1.Text = "Январь";
            this.Menu1.Click += new System.EventHandler(this.Menu1_Click);
            // 
            // Menu2
            // 
            this.Menu2.Name = "Menu2";
            this.Menu2.Size = new System.Drawing.Size(158, 26);
            this.Menu2.Text = "Февраль";
            this.Menu2.Click += new System.EventHandler(this.Menu2_Click);
            // 
            // Menu3
            // 
            this.Menu3.Name = "Menu3";
            this.Menu3.Size = new System.Drawing.Size(158, 26);
            this.Menu3.Text = "Март";
            this.Menu3.Click += new System.EventHandler(this.Menu3_Click);
            // 
            // Menu4
            // 
            this.Menu4.Name = "Menu4";
            this.Menu4.Size = new System.Drawing.Size(158, 26);
            this.Menu4.Text = "Апрель";
            this.Menu4.Click += new System.EventHandler(this.Menu4_Click);
            // 
            // Menu5
            // 
            this.Menu5.Name = "Menu5";
            this.Menu5.Size = new System.Drawing.Size(158, 26);
            this.Menu5.Text = "Май";
            this.Menu5.Click += new System.EventHandler(this.Menu5_Click);
            // 
            // Menu6
            // 
            this.Menu6.Name = "Menu6";
            this.Menu6.Size = new System.Drawing.Size(158, 26);
            this.Menu6.Text = "Июнь";
            this.Menu6.Click += new System.EventHandler(this.Menu6_Click);
            // 
            // Menu7
            // 
            this.Menu7.Name = "Menu7";
            this.Menu7.Size = new System.Drawing.Size(158, 26);
            this.Menu7.Text = "Июль";
            this.Menu7.Click += new System.EventHandler(this.Menu7_Click);
            // 
            // Menu8
            // 
            this.Menu8.Name = "Menu8";
            this.Menu8.Size = new System.Drawing.Size(158, 26);
            this.Menu8.Text = "Август";
            this.Menu8.Click += new System.EventHandler(this.Menu8_Click);
            // 
            // Menu9
            // 
            this.Menu9.Name = "Menu9";
            this.Menu9.Size = new System.Drawing.Size(158, 26);
            this.Menu9.Text = "Сентябрь";
            this.Menu9.Click += new System.EventHandler(this.Menu9_Click);
            // 
            // Menu10
            // 
            this.Menu10.Name = "Menu10";
            this.Menu10.Size = new System.Drawing.Size(158, 26);
            this.Menu10.Text = "Октябрь";
            this.Menu10.Click += new System.EventHandler(this.Menu10_Click);
            // 
            // Menu11
            // 
            this.Menu11.Name = "Menu11";
            this.Menu11.Size = new System.Drawing.Size(158, 26);
            this.Menu11.Text = "Ноябрь";
            this.Menu11.Click += new System.EventHandler(this.Menu11_Click);
            // 
            // Menu12
            // 
            this.Menu12.Name = "Menu12";
            this.Menu12.Size = new System.Drawing.Size(158, 26);
            this.Menu12.Text = "Декабрь";
            this.Menu12.Click += new System.EventHandler(this.Menu12_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(428, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(273, 20);
            this.label11.TabIndex = 16;
            this.label11.Text = "Редактирование запрещено";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(852, 400);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(171, 38);
            this.button3.TabIndex = 17;
            this.button3.Text = "Очистить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 463);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form10";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Журнал";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem открытьЖурналToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Menu1;
        private System.Windows.Forms.ToolStripMenuItem Menu2;
        private System.Windows.Forms.ToolStripMenuItem Menu3;
        private System.Windows.Forms.ToolStripMenuItem Menu4;
        private System.Windows.Forms.ToolStripMenuItem Menu5;
        private System.Windows.Forms.ToolStripMenuItem Menu6;
        private System.Windows.Forms.ToolStripMenuItem Menu7;
        private System.Windows.Forms.ToolStripMenuItem Menu8;
        private System.Windows.Forms.ToolStripMenuItem Menu9;
        private System.Windows.Forms.ToolStripMenuItem Menu10;
        private System.Windows.Forms.ToolStripMenuItem Menu11;
        private System.Windows.Forms.ToolStripMenuItem Menu12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button3;
    }
}