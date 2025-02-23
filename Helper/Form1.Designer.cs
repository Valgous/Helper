namespace Helper
{
    partial class Helper
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnshell = new Button();
            btndriver = new Button();
            tbdriver = new TextBox();
            btncomplex = new Button();
            btnsafe = new Button();
            btnanydesk = new Button();
            btncmdmenu = new Button();
            tbcore = new TextBox();
            btncore = new Button();
            SuspendLayout();
            // 
            // btnshell
            // 
            btnshell.Location = new Point(31, 415);
            btnshell.Name = "btnshell";
            btnshell.Size = new Size(140, 23);
            btnshell.TabIndex = 0;
            btnshell.Text = "Активация PowerShell";
            btnshell.UseVisualStyleBackColor = true;
            btnshell.Click += btnshell_Click;
            // 
            // btndriver
            // 
            btndriver.Location = new Point(31, 357);
            btndriver.Name = "btndriver";
            btndriver.Size = new Size(140, 23);
            btndriver.TabIndex = 1;
            btndriver.Text = "Драйвер из DriverPack";
            btndriver.UseVisualStyleBackColor = true;
            btndriver.Click += btndriver_Click;
            // 
            // tbdriver
            // 
            tbdriver.Location = new Point(31, 386);
            tbdriver.Name = "tbdriver";
            tbdriver.Size = new Size(202, 23);
            tbdriver.TabIndex = 2;
            tbdriver.Text = "Введите сюда ИД оборудования....";
            tbdriver.DoubleClick += tbdriver_Click;
            // 
            // btncomplex
            // 
            btncomplex.Location = new Point(573, 42);
            btncomplex.Name = "btncomplex";
            btncomplex.Size = new Size(215, 23);
            btncomplex.TabIndex = 3;
            btncomplex.Text = "Комплексное обслуживание";
            btncomplex.UseVisualStyleBackColor = true;
            btncomplex.Click += btncomplex_Click;
            // 
            // btnsafe
            // 
            btnsafe.Location = new Point(31, 328);
            btnsafe.Name = "btnsafe";
            btnsafe.Size = new Size(140, 23);
            btnsafe.TabIndex = 4;
            btnsafe.Text = "Безопасный режим";
            btnsafe.UseVisualStyleBackColor = true;
            btnsafe.Click += btnsafe_Click;
            // 
            // btnanydesk
            // 
            btnanydesk.Location = new Point(31, 299);
            btnanydesk.Name = "btnanydesk";
            btnanydesk.Size = new Size(140, 23);
            btnanydesk.TabIndex = 5;
            btnanydesk.Text = "Установить AnyDesk";
            btnanydesk.UseVisualStyleBackColor = true;
            btnanydesk.Click += btnanydesk_Click;
            // 
            // btncmdmenu
            // 
            btncmdmenu.Location = new Point(12, 42);
            btncmdmenu.Name = "btncmdmenu";
            btncmdmenu.Size = new Size(215, 23);
            btncmdmenu.TabIndex = 6;
            btncmdmenu.Text = "Меню CMD";
            btncmdmenu.UseVisualStyleBackColor = true;
            btncmdmenu.Click += button1_Click;
            // 
            // tbcore
            // 
            tbcore.Location = new Point(615, 415);
            tbcore.Name = "tbcore";
            tbcore.Size = new Size(173, 23);
            tbcore.TabIndex = 8;
            // 
            // btncore
            // 
            btncore.Location = new Point(615, 386);
            btncore.Name = "btncore";
            btncore.Size = new Size(173, 23);
            btncore.TabIndex = 7;
            btncore.Text = "Установить кол-во потоков";
            btncore.UseVisualStyleBackColor = true;
            btncore.Click += btncore_Click;
            // 
            // Helper
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbcore);
            Controls.Add(btncore);
            Controls.Add(btncmdmenu);
            Controls.Add(btnanydesk);
            Controls.Add(btnsafe);
            Controls.Add(btncomplex);
            Controls.Add(tbdriver);
            Controls.Add(btndriver);
            Controls.Add(btnshell);
            Name = "Helper";
            Text = "Helper";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnshell;
        private Button btndriver;
        private TextBox tbdriver;
        private Button btncomplex;
        private Button btnsafe;
        private Button btnanydesk;
        private Button btncmdmenu;
        private TextBox tbcore;
        private Button btncore;
    }
}
