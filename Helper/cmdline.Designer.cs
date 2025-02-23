namespace Helper
{
    partial class cmdline
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
            btncmd1 = new Button();
            btncmd2 = new Button();
            btncmd4 = new Button();
            btncmd3 = new Button();
            btncmd6 = new Button();
            btncmd5 = new Button();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            SuspendLayout();
            // 
            // btncmd1
            // 
            btncmd1.Location = new Point(12, 30);
            btncmd1.Name = "btncmd1";
            btncmd1.Size = new Size(260, 23);
            btncmd1.TabIndex = 7;
            btncmd1.Text = "Очистка кэша DNS";
            btncmd1.UseVisualStyleBackColor = true;
            btncmd1.Click += btncmd1_Click;
            // 
            // btncmd2
            // 
            btncmd2.Location = new Point(12, 59);
            btncmd2.Name = "btncmd2";
            btncmd2.Size = new Size(260, 23);
            btncmd2.TabIndex = 8;
            btncmd2.Text = "Очистка кэша хранилища Windows";
            btncmd2.UseVisualStyleBackColor = true;
            btncmd2.Click += btncmd2_Click;
            // 
            // btncmd4
            // 
            btncmd4.Location = new Point(12, 195);
            btncmd4.Name = "btncmd4";
            btncmd4.Size = new Size(260, 23);
            btncmd4.TabIndex = 10;
            btncmd4.Text = "Комплексное обслуживание";
            btncmd4.UseVisualStyleBackColor = true;
            // 
            // btncmd3
            // 
            btncmd3.Location = new Point(12, 166);
            btncmd3.Name = "btncmd3";
            btncmd3.Size = new Size(260, 23);
            btncmd3.TabIndex = 9;
            btncmd3.Text = "Удаление временных файлов";
            btncmd3.UseVisualStyleBackColor = true;
            btncmd3.Click += btncmd3_Click;
            // 
            // btncmd6
            // 
            btncmd6.Location = new Point(12, 253);
            btncmd6.Name = "btncmd6";
            btncmd6.Size = new Size(260, 23);
            btncmd6.TabIndex = 12;
            btncmd6.Text = "Комплексное обслуживание";
            btncmd6.UseVisualStyleBackColor = true;
            // 
            // btncmd5
            // 
            btncmd5.Location = new Point(12, 224);
            btncmd5.Name = "btncmd5";
            btncmd5.Size = new Size(260, 23);
            btncmd5.TabIndex = 11;
            btncmd5.Text = "Комплексное обслуживание";
            btncmd5.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(12, 88);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(132, 19);
            checkBox1.TabIndex = 13;
            checkBox1.Text = "Чистка папок Temp";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(12, 113);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(147, 19);
            checkBox2.TabIndex = 14;
            checkBox2.Text = "Чистка папки Prefetch";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(12, 138);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(176, 19);
            checkBox3.TabIndex = 15;
            checkBox3.Text = "Чистка бортового журнала";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // cmdline
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 500);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(btncmd6);
            Controls.Add(btncmd5);
            Controls.Add(btncmd4);
            Controls.Add(btncmd3);
            Controls.Add(btncmd2);
            Controls.Add(btncmd1);
            Name = "cmdline";
            Text = "Команды в CMD";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btncmd1;
        private Button btncmd2;
        private Button btncmd4;
        private Button btncmd3;
        private Button btncmd6;
        private Button btncmd5;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
    }
}