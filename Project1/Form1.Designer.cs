namespace Project1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bNew = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.jhgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кодуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фамилииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.имениToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчествуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.датеРожденияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.п1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.паролиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.войтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bChildren = new System.Windows.Forms.Button();
            this.bParents = new System.Windows.Forms.Button();
            this.bWorkers = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bMore = new System.Windows.Forms.Button();
            this.bGroup = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bNew
            // 
            this.bNew.Location = new System.Drawing.Point(0, 291);
            this.bNew.Margin = new System.Windows.Forms.Padding(4);
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(208, 29);
            this.bNew.TabIndex = 3;
            this.bNew.Text = "Добавить";
            this.bNew.UseVisualStyleBackColor = true;
            this.bNew.Click += new System.EventHandler(this.bNew_Click);
            // 
            // bDelete
            // 
            this.bDelete.Location = new System.Drawing.Point(0, 342);
            this.bDelete.Margin = new System.Windows.Forms.Padding(4);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(208, 29);
            this.bDelete.TabIndex = 6;
            this.bDelete.Text = "Удалить";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jhgToolStripMenuItem,
            this.поискToolStripMenuItem,
            this.помощьToolStripMenuItem,
            this.паролиToolStripMenuItem,
            this.войтиToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1089, 28);
            this.menuStrip2.TabIndex = 8;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // jhgToolStripMenuItem
            // 
            this.jhgToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.кодуToolStripMenuItem,
            this.фамилииToolStripMenuItem,
            this.имениToolStripMenuItem,
            this.отчествуToolStripMenuItem,
            this.датеРожденияToolStripMenuItem,
            this.п1ToolStripMenuItem});
            this.jhgToolStripMenuItem.Name = "jhgToolStripMenuItem";
            this.jhgToolStripMenuItem.Size = new System.Drawing.Size(135, 24);
            this.jhgToolStripMenuItem.Text = "Сортировать по";
            // 
            // кодуToolStripMenuItem
            // 
            this.кодуToolStripMenuItem.Name = "кодуToolStripMenuItem";
            this.кодуToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.кодуToolStripMenuItem.Text = "Коду";
            this.кодуToolStripMenuItem.Click += new System.EventHandler(this.кодуToolStripMenuItem_Click);
            // 
            // фамилииToolStripMenuItem
            // 
            this.фамилииToolStripMenuItem.Name = "фамилииToolStripMenuItem";
            this.фамилииToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.фамилииToolStripMenuItem.Text = "Фамилии";
            this.фамилииToolStripMenuItem.Click += new System.EventHandler(this.фамилииToolStripMenuItem_Click);
            // 
            // имениToolStripMenuItem
            // 
            this.имениToolStripMenuItem.Name = "имениToolStripMenuItem";
            this.имениToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.имениToolStripMenuItem.Text = "Имени";
            this.имениToolStripMenuItem.Click += new System.EventHandler(this.имениToolStripMenuItem_Click);
            // 
            // отчествуToolStripMenuItem
            // 
            this.отчествуToolStripMenuItem.Name = "отчествуToolStripMenuItem";
            this.отчествуToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.отчествуToolStripMenuItem.Text = "Отчеству";
            this.отчествуToolStripMenuItem.Click += new System.EventHandler(this.отчествуToolStripMenuItem_Click);
            // 
            // датеРожденияToolStripMenuItem
            // 
            this.датеРожденияToolStripMenuItem.Name = "датеРожденияToolStripMenuItem";
            this.датеРожденияToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.датеРожденияToolStripMenuItem.Text = "Дате рождения";
            this.датеРожденияToolStripMenuItem.Click += new System.EventHandler(this.датеРожденияToolStripMenuItem_Click);
            // 
            // п1ToolStripMenuItem
            // 
            this.п1ToolStripMenuItem.Name = "п1ToolStripMenuItem";
            this.п1ToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.п1ToolStripMenuItem.Text = "п1";
            this.п1ToolStripMenuItem.Click += new System.EventHandler(this.п1ToolStripMenuItem_Click);
            // 
            // поискToolStripMenuItem
            // 
            this.поискToolStripMenuItem.Name = "поискToolStripMenuItem";
            this.поискToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.поискToolStripMenuItem.Text = "Поиск";
            this.поискToolStripMenuItem.Click += new System.EventHandler(this.поискToolStripMenuItem_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.помощьToolStripMenuItem.Text = "Помощь";
            this.помощьToolStripMenuItem.Click += new System.EventHandler(this.помощьToolStripMenuItem_Click);
            // 
            // паролиToolStripMenuItem
            // 
            this.паролиToolStripMenuItem.Name = "паролиToolStripMenuItem";
            this.паролиToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.паролиToolStripMenuItem.Text = "Пароли";
            this.паролиToolStripMenuItem.Visible = false;
            this.паролиToolStripMenuItem.Click += new System.EventHandler(this.паролиToolStripMenuItem_Click);
            // 
            // войтиToolStripMenuItem
            // 
            this.войтиToolStripMenuItem.Name = "войтиToolStripMenuItem";
            this.войтиToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.войтиToolStripMenuItem.Text = "Войти";
            this.войтиToolStripMenuItem.Visible = false;
            this.войтиToolStripMenuItem.Click += new System.EventHandler(this.войтиToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // bChildren
            // 
            this.bChildren.Location = new System.Drawing.Point(0, 31);
            this.bChildren.Name = "bChildren";
            this.bChildren.Size = new System.Drawing.Size(208, 32);
            this.bChildren.TabIndex = 9;
            this.bChildren.Text = "Воспитанники";
            this.bChildren.UseVisualStyleBackColor = true;
            this.bChildren.Click += new System.EventHandler(this.bChildren_Click);
            // 
            // bParents
            // 
            this.bParents.Location = new System.Drawing.Point(0, 60);
            this.bParents.Name = "bParents";
            this.bParents.Size = new System.Drawing.Size(208, 32);
            this.bParents.TabIndex = 10;
            this.bParents.Text = "Родители";
            this.bParents.UseVisualStyleBackColor = true;
            this.bParents.Click += new System.EventHandler(this.bParents_Click);
            // 
            // bWorkers
            // 
            this.bWorkers.Location = new System.Drawing.Point(0, 89);
            this.bWorkers.Name = "bWorkers";
            this.bWorkers.Size = new System.Drawing.Size(208, 33);
            this.bWorkers.TabIndex = 11;
            this.bWorkers.Text = "Сотрудники";
            this.bWorkers.UseVisualStyleBackColor = true;
            this.bWorkers.Click += new System.EventHandler(this.bWorkers_Click);
            // 
            // Search
            // 
            this.Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Search.Location = new System.Drawing.Point(0, 171);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(208, 51);
            this.Search.TabIndex = 12;
            this.Search.Text = "Журнал";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(215, 31);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(867, 379);
            this.listView1.TabIndex = 13;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 386);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Всего записей:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 386);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 15;
            // 
            // bMore
            // 
            this.bMore.Location = new System.Drawing.Point(0, 317);
            this.bMore.Name = "bMore";
            this.bMore.Size = new System.Drawing.Size(208, 28);
            this.bMore.TabIndex = 16;
            this.bMore.Text = "Подробнее";
            this.bMore.UseVisualStyleBackColor = true;
            this.bMore.Click += new System.EventHandler(this.bMore_Click);
            // 
            // bGroup
            // 
            this.bGroup.Location = new System.Drawing.Point(0, 118);
            this.bGroup.Name = "bGroup";
            this.bGroup.Size = new System.Drawing.Size(208, 33);
            this.bGroup.TabIndex = 17;
            this.bGroup.Text = "Группы";
            this.bGroup.UseVisualStyleBackColor = true;
            this.bGroup.Click += new System.EventHandler(this.bGroup_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(0, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 51);
            this.button1.TabIndex = 18;
            this.button1.Text = "Статистика";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 422);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bGroup);
            this.Controls.Add(this.bMore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.bWorkers);
            this.Controls.Add(this.bParents);
            this.Controls.Add(this.bChildren);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.bNew);
            this.Controls.Add(this.menuStrip2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Картотека";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bNew;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem jhgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Button bChildren;
        private System.Windows.Forms.Button bParents;
        private System.Windows.Forms.Button bWorkers;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bMore;
        private System.Windows.Forms.ToolStripMenuItem кодуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фамилииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem имениToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчествуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem датеРожденияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem п1ToolStripMenuItem;
        private System.Windows.Forms.Button bGroup;
        private System.Windows.Forms.ToolStripMenuItem поискToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem паролиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem войтиToolStripMenuItem;
    }
}

