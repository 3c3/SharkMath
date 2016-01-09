namespace TestGUI
{
    partial class Form1
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
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dirTb = new System.Windows.Forms.TextBox();
            this.fileNameTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.letterTb = new System.Windows.Forms.TextBox();
            this.powerTb = new System.Windows.Forms.TextBox();
            this.fracTb = new System.Windows.Forms.TextBox();
            this.pIrrTb = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.transMinTb = new System.Windows.Forms.TextBox();
            this.transMaxTb = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nProblemsTb = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.maxPowerTb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(242, 211);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Browse folder";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Directory:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "File name:";
            // 
            // dirTb
            // 
            this.dirTb.Location = new System.Drawing.Point(73, 213);
            this.dirTb.Name = "dirTb";
            this.dirTb.Size = new System.Drawing.Size(163, 20);
            this.dirTb.TabIndex = 4;
            // 
            // fileNameTb
            // 
            this.fileNameTb.Location = new System.Drawing.Point(73, 242);
            this.fileNameTb.Name = "fileNameTb";
            this.fileNameTb.Size = new System.Drawing.Size(163, 20);
            this.fileNameTb.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Буква:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Степен:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Дробни числа от ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Ирационални числа:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Трансформации:";
            // 
            // letterTb
            // 
            this.letterTb.Location = new System.Drawing.Point(128, 12);
            this.letterTb.Name = "letterTb";
            this.letterTb.Size = new System.Drawing.Size(30, 20);
            this.letterTb.TabIndex = 11;
            // 
            // powerTb
            // 
            this.powerTb.Location = new System.Drawing.Point(128, 37);
            this.powerTb.Name = "powerTb";
            this.powerTb.Size = new System.Drawing.Size(30, 20);
            this.powerTb.TabIndex = 12;
            // 
            // fracTb
            // 
            this.fracTb.Location = new System.Drawing.Point(128, 60);
            this.fracTb.Name = "fracTb";
            this.fracTb.Size = new System.Drawing.Size(30, 20);
            this.fracTb.TabIndex = 13;
            // 
            // pIrrTb
            // 
            this.pIrrTb.Location = new System.Drawing.Point(128, 84);
            this.pIrrTb.Name = "pIrrTb";
            this.pIrrTb.Size = new System.Drawing.Size(30, 20);
            this.pIrrTb.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(164, 110);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(19, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "до";
            // 
            // transMinTb
            // 
            this.transMinTb.Location = new System.Drawing.Point(128, 107);
            this.transMinTb.Name = "transMinTb";
            this.transMinTb.Size = new System.Drawing.Size(30, 20);
            this.transMinTb.TabIndex = 21;
            // 
            // transMaxTb
            // 
            this.transMaxTb.Location = new System.Drawing.Point(189, 107);
            this.transMaxTb.Name = "transMaxTb";
            this.transMaxTb.Size = new System.Drawing.Size(30, 20);
            this.transMaxTb.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Брой задачи:";
            // 
            // nProblemsTb
            // 
            this.nProblemsTb.Location = new System.Drawing.Point(128, 129);
            this.nProblemsTb.Name = "nProblemsTb";
            this.nProblemsTb.Size = new System.Drawing.Size(30, 20);
            this.nProblemsTb.TabIndex = 25;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(242, 240);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 23);
            this.button3.TabIndex = 26;
            this.button3.Text = "Генерирай";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // maxPowerTb
            // 
            this.maxPowerTb.Location = new System.Drawing.Point(257, 37);
            this.maxPowerTb.Name = "maxPowerTb";
            this.maxPowerTb.Size = new System.Drawing.Size(30, 20);
            this.maxPowerTb.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(164, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Макс визуална:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Само задачи",
            "Само отговори",
            "Задачи и отговори"});
            this.comboBox1.Location = new System.Drawing.Point(73, 174);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(163, 21);
            this.comboBox1.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Направи:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 283);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.maxPowerTb);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.nProblemsTb);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.transMaxTb);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.transMinTb);
            this.Controls.Add(this.pIrrTb);
            this.Controls.Add(this.fracTb);
            this.Controls.Add(this.powerTb);
            this.Controls.Add(this.letterTb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fileNameTb);
            this.Controls.Add(this.dirTb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dirTb;
        private System.Windows.Forms.TextBox fileNameTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox letterTb;
        private System.Windows.Forms.TextBox powerTb;
        private System.Windows.Forms.TextBox fracTb;
        private System.Windows.Forms.TextBox pIrrTb;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox transMinTb;
        private System.Windows.Forms.TextBox transMaxTb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox nProblemsTb;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox maxPowerTb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label10;
    }
}

