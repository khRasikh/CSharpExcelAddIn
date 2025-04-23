using System;

namespace TestAddIn
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
            this.components = new System.ComponentModel.Container();
            this.search = new System.Windows.Forms.TextBox();
            this.bannerPanel = new System.Windows.Forms.Panel();
            this.bannerLabel = new System.Windows.Forms.Label();
            this.menuButton = new System.Windows.Forms.Button();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.personalInfoPanel = new System.Windows.Forms.Panel();
            this.labelKNR = new System.Windows.Forms.Label();
            this.knr = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.phone = new System.Windows.Forms.TextBox();
            this.labelStr = new System.Windows.Forms.Label();
            this.str = new System.Windows.Forms.TextBox();
            this.labelOrt = new System.Windows.Forms.Label();
            this.ort = new System.Windows.Forms.TextBox();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.footerLabel1 = new System.Windows.Forms.Label();
            this.footerLabel2 = new System.Windows.Forms.Label();
            this.footerLabel3 = new System.Windows.Forms.Label();
            this.footerLabel4 = new System.Windows.Forms.Label();
            this.footerLabel5 = new System.Windows.Forms.Label();
            this.footerLabel6 = new System.Windows.Forms.Label();
            this.footerLabel7 = new System.Windows.Forms.Label();
            this.footerLabel8 = new System.Windows.Forms.Label();
            this.footerLabel9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bannerPanel.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.personalInfoPanel.SuspendLayout();
            this.footerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // search
            // 
            this.search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.search.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.25F, System.Drawing.FontStyle.Bold);
            this.search.ForeColor = System.Drawing.SystemColors.WindowText;
            this.search.Location = new System.Drawing.Point(1599, 92);
            this.search.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(277, 58);
            this.search.TabIndex = 0;
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            this.search.GotFocus += new System.EventHandler(this.search_GotFocus);
            this.search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_KeyDown);
            // 
            // bannerPanel
            // 
            this.bannerPanel.BackColor = System.Drawing.Color.Navy;
            this.bannerPanel.Controls.Add(this.bannerLabel);
            this.bannerPanel.Controls.Add(this.menuButton);
            this.bannerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.bannerPanel.Location = new System.Drawing.Point(0, 0);
            this.bannerPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bannerPanel.Name = "bannerPanel";
            this.bannerPanel.Size = new System.Drawing.Size(1924, 77);
            this.bannerPanel.TabIndex = 1;
            // 
            // bannerLabel
            // 
            this.bannerLabel.AutoSize = true;
            this.bannerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bannerLabel.ForeColor = System.Drawing.Color.White;
            this.bannerLabel.Location = new System.Drawing.Point(18, 20);
            this.bannerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bannerLabel.Name = "bannerLabel";
            this.bannerLabel.Size = new System.Drawing.Size(119, 33);
            this.bannerLabel.TabIndex = 0;
            this.bannerLabel.Text = "My App";
            // 
            // menuButton
            // 
            this.menuButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuButton.ForeColor = System.Drawing.Color.White;
            this.menuButton.Location = new System.Drawing.Point(1634, 24);
            this.menuButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(62, 35);
            this.menuButton.TabIndex = 1;
            this.menuButton.Text = "☰";
            this.menuButton.UseVisualStyleBackColor = true;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // contextMenu
            // 
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem3});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(156, 100);
            // 
            // menuItem1
            // 
            this.menuItem1.Name = "menuItem1";
            this.menuItem1.Size = new System.Drawing.Size(155, 32);
            this.menuItem1.Text = "Option 1";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Name = "menuItem2";
            this.menuItem2.Size = new System.Drawing.Size(155, 32);
            this.menuItem2.Text = "Option 2";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Name = "menuItem3";
            this.menuItem3.Size = new System.Drawing.Size(155, 32);
            this.menuItem3.Text = "Option 3";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // personalInfoPanel
            // 
            this.personalInfoPanel.Controls.Add(this.labelKNR);
            this.personalInfoPanel.Controls.Add(this.knr);
            this.personalInfoPanel.Controls.Add(this.labelName);
            this.personalInfoPanel.Controls.Add(this.name);
            this.personalInfoPanel.Controls.Add(this.labelPhone);
            this.personalInfoPanel.Controls.Add(this.phone);
            this.personalInfoPanel.Controls.Add(this.labelStr);
            this.personalInfoPanel.Controls.Add(this.str);
            this.personalInfoPanel.Controls.Add(this.labelOrt);
            this.personalInfoPanel.Controls.Add(this.ort);
            this.personalInfoPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personalInfoPanel.ForeColor = System.Drawing.Color.Yellow;
            this.personalInfoPanel.Location = new System.Drawing.Point(18, 92);
            this.personalInfoPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.personalInfoPanel.Name = "personalInfoPanel";
            this.personalInfoPanel.Size = new System.Drawing.Size(1552, 212);
            this.personalInfoPanel.TabIndex = 2;
            // 
            // labelKNR
            // 
            this.labelKNR.AutoSize = true;
            this.labelKNR.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.labelKNR.ForeColor = System.Drawing.Color.Yellow;
            this.labelKNR.Location = new System.Drawing.Point(10, 0);
            this.labelKNR.Name = "labelKNR";
            this.labelKNR.Size = new System.Drawing.Size(97, 37);
            this.labelKNR.TabIndex = 0;
            this.labelKNR.Text = "KNR:";
            // 
            // knr
            // 
            this.knr.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.knr.Location = new System.Drawing.Point(120, 0);
            this.knr.Name = "knr";
            this.knr.Size = new System.Drawing.Size(350, 44);
            this.knr.TabIndex = 1;
            this.knr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.labelName.ForeColor = System.Drawing.Color.Yellow;
            this.labelName.Location = new System.Drawing.Point(495, 3);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(117, 37);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Name:";
            // 
            // name
            // 
            this.name.BackColor = System.Drawing.Color.MediumBlue;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.name.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.name.Location = new System.Drawing.Point(629, 0);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(362, 44);
            this.name.TabIndex = 3;
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.labelPhone.ForeColor = System.Drawing.Color.Yellow;
            this.labelPhone.Location = new System.Drawing.Point(1054, 0);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(124, 37);
            this.labelPhone.TabIndex = 4;
            this.labelPhone.Text = "Phone:";
            // 
            // phone
            // 
            this.phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.phone.Location = new System.Drawing.Point(1211, -4);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(309, 44);
            this.phone.TabIndex = 5;
            // 
            // labelStr
            // 
            this.labelStr.AutoSize = true;
            this.labelStr.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.labelStr.ForeColor = System.Drawing.Color.Yellow;
            this.labelStr.Location = new System.Drawing.Point(10, 60);
            this.labelStr.Name = "labelStr";
            this.labelStr.Size = new System.Drawing.Size(117, 37);
            this.labelStr.TabIndex = 6;
            this.labelStr.Text = "Street:";
            // 
            // str
            // 
            this.str.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.str.Location = new System.Drawing.Point(133, 60);
            this.str.Name = "str";
            this.str.Size = new System.Drawing.Size(371, 44);
            this.str.TabIndex = 7;
            // 
            // labelOrt
            // 
            this.labelOrt.AutoSize = true;
            this.labelOrt.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.labelOrt.ForeColor = System.Drawing.Color.Yellow;
            this.labelOrt.Location = new System.Drawing.Point(510, 60);
            this.labelOrt.Name = "labelOrt";
            this.labelOrt.Size = new System.Drawing.Size(85, 37);
            this.labelOrt.TabIndex = 8;
            this.labelOrt.Text = "City:";
            // 
            // ort
            // 
            this.ort.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.ort.Location = new System.Drawing.Point(600, 60);
            this.ort.Name = "ort";
            this.ort.Size = new System.Drawing.Size(401, 44);
            this.ort.TabIndex = 9;
            // 
            // footerPanel
            // 
            this.footerPanel.BackColor = System.Drawing.Color.Navy;
            this.footerPanel.Controls.Add(this.label2);
            this.footerPanel.Controls.Add(this.footerLabel1);
            this.footerPanel.Controls.Add(this.footerLabel2);
            this.footerPanel.Controls.Add(this.footerLabel3);
            this.footerPanel.Controls.Add(this.footerLabel4);
            this.footerPanel.Controls.Add(this.footerLabel5);
            this.footerPanel.Controls.Add(this.footerLabel6);
            this.footerPanel.Controls.Add(this.footerLabel7);
            this.footerPanel.Controls.Add(this.footerLabel8);
            this.footerPanel.Controls.Add(this.footerLabel9);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 1093);
            this.footerPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(1924, 77);
            this.footerPanel.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(1801, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 37);
            this.label2.TabIndex = 9;
            this.label2.Text = "R.OK";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // footerLabel1
            // 
            this.footerLabel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.footerLabel1.AutoSize = true;
            this.footerLabel1.BackColor = System.Drawing.Color.Red;
            this.footerLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.footerLabel1.ForeColor = System.Drawing.Color.LightYellow;
            this.footerLabel1.Location = new System.Drawing.Point(100, 0);
            this.footerLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.footerLabel1.Name = "footerLabel1";
            this.footerLabel1.Size = new System.Drawing.Size(65, 37);
            this.footerLabel1.TabIndex = 0;
            this.footerLabel1.Text = "F1:";
            // 
            // footerLabel2
            // 
            this.footerLabel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.footerLabel2.AutoSize = true;
            this.footerLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.footerLabel2.ForeColor = System.Drawing.Color.Green;
            this.footerLabel2.Location = new System.Drawing.Point(190, 0);
            this.footerLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.footerLabel2.Name = "footerLabel2";
            this.footerLabel2.Size = new System.Drawing.Size(111, 37);
            this.footerLabel2.TabIndex = 1;
            this.footerLabel2.Text = "B.Neu";
            // 
            // footerLabel3
            // 
            this.footerLabel3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.footerLabel3.AutoSize = true;
            this.footerLabel3.BackColor = System.Drawing.Color.Red;
            this.footerLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.footerLabel3.ForeColor = System.Drawing.Color.LightYellow;
            this.footerLabel3.Location = new System.Drawing.Point(502, 0);
            this.footerLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.footerLabel3.Name = "footerLabel3";
            this.footerLabel3.Size = new System.Drawing.Size(67, 37);
            this.footerLabel3.TabIndex = 2;
            this.footerLabel3.Text = "F2:";
            // 
            // footerLabel4
            // 
            this.footerLabel4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.footerLabel4.AutoSize = true;
            this.footerLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.footerLabel4.ForeColor = System.Drawing.Color.Green;
            this.footerLabel4.Location = new System.Drawing.Point(592, 0);
            this.footerLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.footerLabel4.Name = "footerLabel4";
            this.footerLabel4.Size = new System.Drawing.Size(112, 37);
            this.footerLabel4.TabIndex = 3;
            this.footerLabel4.Text = "Suche";
            // 
            // footerLabel5
            // 
            this.footerLabel5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.footerLabel5.AutoSize = true;
            this.footerLabel5.BackColor = System.Drawing.Color.Red;
            this.footerLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.footerLabel5.ForeColor = System.Drawing.Color.LightYellow;
            this.footerLabel5.Location = new System.Drawing.Point(904, 0);
            this.footerLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.footerLabel5.Name = "footerLabel5";
            this.footerLabel5.Size = new System.Drawing.Size(67, 37);
            this.footerLabel5.TabIndex = 4;
            this.footerLabel5.Text = "F3:";
            // 
            // footerLabel6
            // 
            this.footerLabel6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.footerLabel6.AutoSize = true;
            this.footerLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.footerLabel6.ForeColor = System.Drawing.Color.Green;
            this.footerLabel6.Location = new System.Drawing.Point(994, 0);
            this.footerLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.footerLabel6.Name = "footerLabel6";
            this.footerLabel6.Size = new System.Drawing.Size(145, 37);
            this.footerLabel6.TabIndex = 5;
            this.footerLabel6.Text = "Anderen";
            // 
            // footerLabel7
            // 
            this.footerLabel7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.footerLabel7.AutoSize = true;
            this.footerLabel7.BackColor = System.Drawing.Color.Red;
            this.footerLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.footerLabel7.ForeColor = System.Drawing.Color.LightYellow;
            this.footerLabel7.Location = new System.Drawing.Point(1306, 0);
            this.footerLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.footerLabel7.Name = "footerLabel7";
            this.footerLabel7.Size = new System.Drawing.Size(67, 37);
            this.footerLabel7.TabIndex = 6;
            this.footerLabel7.Text = "F4:";
            // 
            // footerLabel8
            // 
            this.footerLabel8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.footerLabel8.AutoSize = true;
            this.footerLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.footerLabel8.ForeColor = System.Drawing.Color.Green;
            this.footerLabel8.Location = new System.Drawing.Point(1396, 0);
            this.footerLabel8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.footerLabel8.Name = "footerLabel8";
            this.footerLabel8.Size = new System.Drawing.Size(98, 37);
            this.footerLabel8.TabIndex = 7;
            this.footerLabel8.Text = "R.OK";
            // 
            // footerLabel9
            // 
            this.footerLabel9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.footerLabel9.AutoSize = true;
            this.footerLabel9.BackColor = System.Drawing.Color.Red;
            this.footerLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.footerLabel9.ForeColor = System.Drawing.Color.LightYellow;
            this.footerLabel9.Location = new System.Drawing.Point(1708, 0);
            this.footerLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.footerLabel9.Name = "footerLabel9";
            this.footerLabel9.Size = new System.Drawing.Size(67, 37);
            this.footerLabel9.TabIndex = 8;
            this.footerLabel9.Text = "F5:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(734, 555);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 37);
            this.label3.TabIndex = 10;
            this.label3.Text = "GET:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(851, 555);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 37);
            this.label4.TabIndex = 11;
            this.label4.Text = "loading";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumBlue;
            this.ClientSize = new System.Drawing.Size(1924, 1170);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.personalInfoPanel);
            this.Controls.Add(this.bannerPanel);
            this.Controls.Add(this.search);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "My App";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.bannerPanel.ResumeLayout(false);
            this.bannerPanel.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.personalInfoPanel.ResumeLayout(false);
            this.personalInfoPanel.PerformLayout();
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.Panel bannerPanel;
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuItem3;
        private System.Windows.Forms.Label bannerLabel;
        private System.Windows.Forms.Panel personalInfoPanel;
        private System.Windows.Forms.Label labelKNR;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelStr;
        private System.Windows.Forms.Label labelOrt;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Label footerLabel1;
        private System.Windows.Forms.Label footerLabel2;
        private System.Windows.Forms.Label footerLabel3;
        private System.Windows.Forms.Label footerLabel4;
        private System.Windows.Forms.Label footerLabel5;
        private System.Windows.Forms.Label footerLabel6;
        private System.Windows.Forms.Label footerLabel7;
        private System.Windows.Forms.Label footerLabel8;
        private System.Windows.Forms.Label footerLabel9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox knr;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.TextBox str;
        private System.Windows.Forms.TextBox ort;
    }
}

