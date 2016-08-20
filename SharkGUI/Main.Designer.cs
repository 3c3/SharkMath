namespace SharkGUI
{
    partial class Main
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
            this.menu_panel = new System.Windows.Forms.Panel();
            this.BrowserDock = new System.Windows.Forms.Panel();
            this.close_button = new System.Windows.Forms.Button();
            this.minimiza_button = new System.Windows.Forms.Button();
            this.menu_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu_panel
            // 
            this.menu_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(128)))), ((int)(((byte)(227)))));
            this.menu_panel.Controls.Add(this.minimiza_button);
            this.menu_panel.Controls.Add(this.close_button);
            this.menu_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.menu_panel.Location = new System.Drawing.Point(0, 0);
            this.menu_panel.Name = "menu_panel";
            this.menu_panel.Size = new System.Drawing.Size(920, 23);
            this.menu_panel.TabIndex = 0;
            this.menu_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // BrowserDock
            // 
            this.BrowserDock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowserDock.Location = new System.Drawing.Point(0, 23);
            this.BrowserDock.Name = "BrowserDock";
            this.BrowserDock.Size = new System.Drawing.Size(920, 539);
            this.BrowserDock.TabIndex = 1;
            // 
            // close_button
            // 
            this.close_button.Location = new System.Drawing.Point(891, 0);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(26, 23);
            this.close_button.TabIndex = 0;
            this.close_button.Text = "X";
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // minimiza_button
            // 
            this.minimiza_button.Location = new System.Drawing.Point(858, 0);
            this.minimiza_button.Name = "minimiza_button";
            this.minimiza_button.Size = new System.Drawing.Size(27, 23);
            this.minimiza_button.TabIndex = 1;
            this.minimiza_button.Text = "-";
            this.minimiza_button.UseVisualStyleBackColor = true;
            this.minimiza_button.Click += new System.EventHandler(this.minimiza_button_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 562);
            this.Controls.Add(this.BrowserDock);
            this.Controls.Add(this.menu_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(920, 400);
            this.Name = "Main";
            this.Text = "Main";
            this.menu_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menu_panel;
        private System.Windows.Forms.Panel BrowserDock;
        private System.Windows.Forms.Button minimiza_button;
        private System.Windows.Forms.Button close_button;


    }
}