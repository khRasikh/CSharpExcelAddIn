
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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

        // create order form step 1: define it
        private CreateOrderForm createOrderForm;

        // initialize component
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.createOrderForm = new TestAddIn.CreateOrderForm();
            this.bannerPanel.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.personalInfoPanel.SuspendLayout();
            this.footerPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // search
            // 
            this.search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.search.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.25F, System.Drawing.FontStyle.Bold);
            this.search.ForeColor = System.Drawing.SystemColors.WindowText;
            this.search.Location = new System.Drawing.Point(1102, 3);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(214, 41);
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
            this.bannerPanel.Name = "bannerPanel";
            this.bannerPanel.Size = new System.Drawing.Size(1370, 50);
            this.bannerPanel.TabIndex = 1;
            // 
            // bannerLabel
            // 
            this.bannerLabel.AutoSize = true;
            this.bannerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bannerLabel.ForeColor = System.Drawing.Color.White;
            this.bannerLabel.Location = new System.Drawing.Point(12, 13);
            this.bannerLabel.Name = "bannerLabel";
            this.bannerLabel.Size = new System.Drawing.Size(81, 24);
            this.bannerLabel.TabIndex = 0;
            this.bannerLabel.Text = "My App";
            // 
            // menuButton
            // 
            this.menuButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuButton.ForeColor = System.Drawing.Color.White;
            this.menuButton.Location = new System.Drawing.Point(2326, 16);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(41, 23);
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
            this.contextMenu.Size = new System.Drawing.Size(121, 70);
            // 
            // menuItem1
            // 
            this.menuItem1.Name = "menuItem1";
            this.menuItem1.Size = new System.Drawing.Size(120, 22);
            this.menuItem1.Text = "Option 1";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Name = "menuItem2";
            this.menuItem2.Size = new System.Drawing.Size(120, 22);
            this.menuItem2.Text = "Option 2";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Name = "menuItem3";
            this.menuItem3.Size = new System.Drawing.Size(120, 22);
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
            this.personalInfoPanel.Controls.Add(this.search);
            this.personalInfoPanel.Controls.Add(this.phone);
            this.personalInfoPanel.Controls.Add(this.labelStr);
            this.personalInfoPanel.Controls.Add(this.str);
            this.personalInfoPanel.Controls.Add(this.labelOrt);
            this.personalInfoPanel.Controls.Add(this.ort);
            this.personalInfoPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personalInfoPanel.ForeColor = System.Drawing.Color.Yellow;
            this.personalInfoPanel.Location = new System.Drawing.Point(12, 60);
            this.personalInfoPanel.Name = "personalInfoPanel";
            this.personalInfoPanel.Size = new System.Drawing.Size(1346, 92);
            this.personalInfoPanel.TabIndex = 2;
            // 
            // labelKNR
            // 
            this.labelKNR.AutoSize = true;
            this.labelKNR.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.labelKNR.ForeColor = System.Drawing.Color.Yellow;
            this.labelKNR.Location = new System.Drawing.Point(7, 0);
            this.labelKNR.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelKNR.Name = "labelKNR";
            this.labelKNR.Size = new System.Drawing.Size(69, 26);
            this.labelKNR.TabIndex = 0;
            this.labelKNR.Text = "KNR:";
            // 
            // knr
            // 
            this.knr.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.knr.Location = new System.Drawing.Point(80, 0);
            this.knr.Margin = new System.Windows.Forms.Padding(2);
            this.knr.Name = "knr";
            this.knr.Size = new System.Drawing.Size(235, 32);
            this.knr.TabIndex = 1;
            this.knr.TextChanged += new System.EventHandler(this.knr_TextChanged);
            this.knr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.labelName.ForeColor = System.Drawing.Color.Yellow;
            this.labelName.Location = new System.Drawing.Point(330, 2);
            this.labelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(82, 26);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Name:";
            // 
            // name
            // 
            this.name.BackColor = System.Drawing.Color.MediumBlue;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.name.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.name.Location = new System.Drawing.Point(419, 0);
            this.name.Margin = new System.Windows.Forms.Padding(2);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(243, 32);
            this.name.TabIndex = 3;
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.labelPhone.ForeColor = System.Drawing.Color.Yellow;
            this.labelPhone.Location = new System.Drawing.Point(703, 0);
            this.labelPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(87, 26);
            this.labelPhone.TabIndex = 4;
            this.labelPhone.Text = "Phone:";
            // 
            // phone
            // 
            this.phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.phone.Location = new System.Drawing.Point(807, -3);
            this.phone.Margin = new System.Windows.Forms.Padding(2);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(207, 32);
            this.phone.TabIndex = 5;
            this.phone.TextChanged += new System.EventHandler(this.phone_TextChanged);
            // 
            // labelStr
            // 
            this.labelStr.AutoSize = true;
            this.labelStr.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.labelStr.ForeColor = System.Drawing.Color.Yellow;
            this.labelStr.Location = new System.Drawing.Point(7, 39);
            this.labelStr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStr.Name = "labelStr";
            this.labelStr.Size = new System.Drawing.Size(83, 26);
            this.labelStr.TabIndex = 6;
            this.labelStr.Text = "Street:";
            // 
            // str
            // 
            this.str.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.str.Location = new System.Drawing.Point(89, 39);
            this.str.Margin = new System.Windows.Forms.Padding(2);
            this.str.Name = "str";
            this.str.Size = new System.Drawing.Size(464, 32);
            this.str.TabIndex = 7;
            this.str.TextChanged += new System.EventHandler(this.str_TextChanged);
            // 
            // labelOrt
            // 
            this.labelOrt.AutoSize = true;
            this.labelOrt.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.labelOrt.ForeColor = System.Drawing.Color.Yellow;
            this.labelOrt.Location = new System.Drawing.Point(557, 39);
            this.labelOrt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOrt.Name = "labelOrt";
            this.labelOrt.Size = new System.Drawing.Size(61, 26);
            this.labelOrt.TabIndex = 8;
            this.labelOrt.Text = "City:";
            // 
            // ort
            // 
            this.ort.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.ort.Location = new System.Drawing.Point(617, 39);
            this.ort.Margin = new System.Windows.Forms.Padding(2);
            this.ort.Name = "ort";
            this.ort.Size = new System.Drawing.Size(269, 32);
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
            this.footerPanel.Location = new System.Drawing.Point(0, 635);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(1370, 80);
            this.footerPanel.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(1201, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 26);
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
            this.footerLabel1.Location = new System.Drawing.Point(67, 33);
            this.footerLabel1.Name = "footerLabel1";
            this.footerLabel1.Size = new System.Drawing.Size(46, 26);
            this.footerLabel1.TabIndex = 0;
            this.footerLabel1.Text = "F1:";
            // 
            // footerLabel2
            // 
            this.footerLabel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.footerLabel2.AutoSize = true;
            this.footerLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.footerLabel2.ForeColor = System.Drawing.Color.Green;
            this.footerLabel2.Location = new System.Drawing.Point(127, 33);
            this.footerLabel2.Name = "footerLabel2";
            this.footerLabel2.Size = new System.Drawing.Size(78, 26);
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
            this.footerLabel3.Location = new System.Drawing.Point(335, 33);
            this.footerLabel3.Name = "footerLabel3";
            this.footerLabel3.Size = new System.Drawing.Size(46, 26);
            this.footerLabel3.TabIndex = 2;
            this.footerLabel3.Text = "F2:";
            // 
            // footerLabel4
            // 
            this.footerLabel4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.footerLabel4.AutoSize = true;
            this.footerLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.footerLabel4.ForeColor = System.Drawing.Color.Green;
            this.footerLabel4.Location = new System.Drawing.Point(395, 33);
            this.footerLabel4.Name = "footerLabel4";
            this.footerLabel4.Size = new System.Drawing.Size(79, 26);
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
            this.footerLabel5.Location = new System.Drawing.Point(603, 33);
            this.footerLabel5.Name = "footerLabel5";
            this.footerLabel5.Size = new System.Drawing.Size(46, 26);
            this.footerLabel5.TabIndex = 4;
            this.footerLabel5.Text = "F3:";
            // 
            // footerLabel6
            // 
            this.footerLabel6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.footerLabel6.AutoSize = true;
            this.footerLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.footerLabel6.ForeColor = System.Drawing.Color.Green;
            this.footerLabel6.Location = new System.Drawing.Point(663, 33);
            this.footerLabel6.Name = "footerLabel6";
            this.footerLabel6.Size = new System.Drawing.Size(101, 26);
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
            this.footerLabel7.Location = new System.Drawing.Point(871, 33);
            this.footerLabel7.Name = "footerLabel7";
            this.footerLabel7.Size = new System.Drawing.Size(46, 26);
            this.footerLabel7.TabIndex = 6;
            this.footerLabel7.Text = "F4:";
            // 
            // footerLabel8
            // 
            this.footerLabel8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.footerLabel8.AutoSize = true;
            this.footerLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.footerLabel8.ForeColor = System.Drawing.Color.Green;
            this.footerLabel8.Location = new System.Drawing.Point(931, 33);
            this.footerLabel8.Name = "footerLabel8";
            this.footerLabel8.Size = new System.Drawing.Size(70, 26);
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
            this.footerLabel9.Location = new System.Drawing.Point(1139, 33);
            this.footerLabel9.Name = "footerLabel9";
            this.footerLabel9.Size = new System.Drawing.Size(46, 26);
            this.footerLabel9.TabIndex = 8;
            this.footerLabel9.Text = "F5:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.createOrderForm);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(16, 170);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1346, 459);
            this.panel1.TabIndex = 10;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // createOrderForm
            // 
            this.createOrderForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.createOrderForm.AutoScroll = true;
            this.createOrderForm.AutoScrollMargin = new System.Drawing.Size(0, 2);
            this.createOrderForm.AutoSize = true;
            this.createOrderForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createOrderForm.Location = new System.Drawing.Point(103, 0);
            this.createOrderForm.MinimumSize = new System.Drawing.Size(1066, 408);
            this.createOrderForm.Name = "createOrderForm";
            this.createOrderForm.Padding = new System.Windows.Forms.Padding(3);
            this.createOrderForm.Size = new System.Drawing.Size(1066, 408);
            this.createOrderForm.TabIndex = 1;
            this.createOrderForm.Load += new System.EventHandler(this.createOrderForm_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.MediumBlue;
            this.ClientSize = new System.Drawing.Size(1370, 715);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.personalInfoPanel);
            this.Controls.Add(this.bannerPanel);
            this.Name = "Form1";
            this.Text = "Test AddIn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.bannerPanel.ResumeLayout(false);
            this.bannerPanel.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.personalInfoPanel.ResumeLayout(false);
            this.personalInfoPanel.PerformLayout();
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TextBox knr;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.TextBox str;
        private System.Windows.Forms.TextBox ort;
        private Panel panel1;
    }

    public class CreateOrderForm : UserControl
    {
        private readonly DataGridView dataGridView;
        private readonly Panel panelLastOrdersTable;
        private readonly TextBox textBoxCount;
        private readonly TextBox textBoxArticleNumber;
        private readonly TextBox textBoxCategory;
        private readonly TextBox textBoxExtra;
        private readonly TextBox textBoxPrice;
        private readonly Label lblRabbat;
        private readonly TextBox textRabbatValue;
        private readonly Label lblCount;
        private readonly Label lblTotal;
        private readonly Label lblCountValue;
        private readonly Label lblTotalValue;

        public bool KeyPreview { get; }

        private List<string[]> tempOrders; // Temporary storage for new orders

        // Centralized constants
        private static readonly Font DefaultTextBoxFont = new Font("Microsoft Sans Serif", 16F);
        private static readonly Font DefaultLabelFont = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
        private static readonly Font PanelFont = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
        private const int TextBoxHeight = 32;
        private const int ControlWidth = 1035;
        private const int PanelHeight = 112;
        private const int DataGridViewHeight = 100;
        private const int FormHeight = 300;

        

        public CreateOrderForm()
        {
            tempOrders = new List<string[]>();

            // Initialize controls
            dataGridView = new DataGridView();
            panelLastOrdersTable = new Panel();
            textBoxCount = new TextBox();
            textBoxArticleNumber = new TextBox();
            textBoxCategory = new TextBox();
            textBoxExtra = new TextBox();
            textBoxPrice = new TextBox();
            lblRabbat = new Label();
            textRabbatValue = new TextBox();
            lblCount = new Label();
            lblTotal = new Label();
            lblCountValue = new Label();
            lblTotalValue = new Label();

            // Set KeyPreview and attach KeyDown early
            KeyPreview = true;
            KeyDown += CreateOrderForm_KeyDown;
            System.Diagnostics.Debug.WriteLine("CreateOrderForm constructor: Attached CreateOrderForm_KeyDown at " + DateTime.Now);

            if (IsHandleCreated)
            {
                InitializeComponents();
            }
            else
            {
                HandleCreated += (s, e) => InitializeComponents();
            }
            if (!DesignMode)
            {
                MinimumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            }
            System.Diagnostics.Debug.WriteLine("CreateOrderForm constructor called at " + DateTime.Now);
        }

        private void InitializeComponents()
        {
            // Initialize DataGridView
            ConfigureDataGridView(dataGridView, new Point(0, 0), new Size(ControlWidth, DataGridViewHeight));
            dataGridView.Columns.Add("KundeName", "Kunde Name");
            dataGridView.Columns.Add("KundeNr", "Kunde Nr.");
            dataGridView.Columns.Add("Anz", "Anz");
            dataGridView.Columns.Add("Nr", "Nr");
            dataGridView.Columns.Add("Bez", "Bez");
            dataGridView.Columns.Add("SJ1", "S/J");
            dataGridView.Columns.Add("Extra", "Extra");
            dataGridView.Columns.Add("Preis", "Preis");
            dataGridView.Columns.Add("Rabatt", "Rabatt");

            // Initialize panel
            ConfigurePanel(panelLastOrdersTable, new Point(0, 120), new Size(ControlWidth, PanelHeight));

            // Initialize TextBoxes with KeyDown events
            ConfigureTextBox(textBoxCount, "textBoxCount", new Point(2, 1), new Size(235, TextBoxHeight), 1, textBox1_TextChanged, TextBox_KeyDown);
            ConfigureTextBox(textBoxArticleNumber, "textBoxArticleNumber", new Point(260, 2), new Size(249, TextBoxHeight), 7, textBox4_TextChanged, TextBox_KeyDown);
            ConfigureTextBox(textBoxCategory, "textBoxCategory", new Point(536, 2), new Size(83, TextBoxHeight), 9, textBox5_TextChanged, TextBox_KeyDown);
            ConfigureTextBox(textBoxExtra, "textBoxExtra", new Point(652, 2), new Size(83, TextBoxHeight), 10, null, TextBox_KeyDown);
            ConfigureTextBox(textBoxPrice, "textBoxPrice", new Point(877, 2), new Size(83, TextBoxHeight), 11, null, TextBox_KeyDown);
            ConfigureTextBox(textRabbatValue, "textBoxRabbat", new Point(220, 240), new Size(83, TextBoxHeight), 12, null, TextBox_KeyDown);

            // Add TextBoxes to panel
            panelLastOrdersTable.Controls.AddRange(new Control[] { textBoxCount, textBoxArticleNumber, textBoxCategory, textBoxExtra, textBoxPrice });

            // Initialize Labels
            ConfigureLabel(lblRabbat, "Rabbat:", new Point(0, 240), Color.Yellow);
            ConfigureLabel(lblCount, "Count:", new Point(360, 240), Color.Yellow);
            ConfigureLabel(lblCountValue, "0", new Point(560, 240), Color.LightGreen);
            ConfigureLabel(lblTotal, "Sum:", new Point(720, 240), Color.Yellow);
            ConfigureLabel(lblTotalValue, "€0.00", new Point(920, 240), Color.LightGreen);

            // Add controls to UserControl
            Controls.AddRange(new Control[] { dataGridView, panelLastOrdersTable, lblRabbat, textRabbatValue, lblCount, lblCountValue, lblTotal, lblTotalValue });

            System.Diagnostics.Debug.WriteLine("InitializeComponents started at " + DateTime.Now);
            textBoxCount.Focus();
            System.Diagnostics.Debug.WriteLine("InitializeComponents: Initial focus set to textBoxCount at " + DateTime.Now);

            // Set UserControl size
            Size = new Size(ControlWidth, FormHeight);
            System.Diagnostics.Debug.WriteLine("InitializeComponents completed at " + DateTime.Now);

        }

        private void ConfigureDataGridView(DataGridView grid, Point location, Size size)
        {
            grid.Location = location;
            grid.Size = size;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
        }

        private void ConfigurePanel(Panel panel, Point location, Size size)
        {
            panel.Font = PanelFont;
            panel.ForeColor = Color.Yellow;
            panel.Location = location;
            panel.Name = "panelLastOrders";
            panel.Size = size;
            panel.TabIndex = 10;
        }

        private void ConfigureTextBox(TextBox textBox, string name, Point location, Size size, int tabIndex, EventHandler textChangedHandler, KeyEventHandler keyDownHandler)
        {
            textBox.Font = DefaultTextBoxFont;
            textBox.Location = location;
            textBox.Margin = new Padding(2);
            textBox.Name = name;
            textBox.Size = size;
            textBox.TabIndex = tabIndex;
            if (textChangedHandler != null)
            {
                textBox.TextChanged += textChangedHandler;
            }
            if (keyDownHandler != null)
            {
                textBox.KeyDown += keyDownHandler;
            }
        }

        private void ConfigureLabel(Label label, string text, Point location, Color foreColor)
        {
            label.Text = text;
            label.Location = location;
            label.ForeColor = foreColor;
            label.Font = DefaultLabelFont;
            label.AutoSize = true;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox current = sender as TextBox;
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent beep
                if (current == textRabbatValue)
                {
                    SubmitForm();
                }
                else
                {
                    SelectNextControl(current, true, true, true, true);
                }
            }
            else if (e.KeyCode == Keys.Back && string.IsNullOrEmpty(current.Text))
            {
                e.SuppressKeyPress = true; // Navigate only if textbox is empty
                SelectNextControl(current, false, true, true, true);
            }
        }

        private void CreateOrderForm_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("test " + e.KeyCode, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (e.KeyCode == Keys.F2 && ActiveControl == textRabbatValue)
            {
                e.SuppressKeyPress = true;
                SaveOrders();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            System.Diagnostics.Debug.WriteLine($"ProcessCmdKey: Key {keyData} pressed at {DateTime.Now}");
            if (keyData == Keys.F3 && tempOrders.Count > 0)
            {
                System.Diagnostics.Debug.WriteLine($"ProcessCmdKey: Calling SaveOrders for F3 at {DateTime.Now}");
                SaveOrders();
                return true; // Indicate key was handled
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void SubmitForm()
        {
            // Store form data in tempOrders
            string[] order = new string[]
            {
            "Customer", // KundeName (placeholder)
            "0",     // KundeNr
            textBoxCount.Text,
            textBoxArticleNumber.Text,
            textBoxCategory.Text,
            "",        // SJ1 (placeholder)
            textBoxExtra.Text,
            textBoxPrice.Text,
            textRabbatValue.Text
            };
            tempOrders.Add(order);

            // Update DataGridView
            dataGridView.Rows.Clear();
            foreach (var ord in tempOrders)
            {
                dataGridView.Rows.Add(ord);
            }

            // Update count and total
            lblCountValue.Text = tempOrders.Count.ToString();
            decimal total = 0;
            foreach (var ord in tempOrders)
            {
                if (decimal.TryParse(ord[7], out decimal price) && decimal.TryParse(ord[2], out decimal count))
                {
                    decimal discount = decimal.TryParse(ord[8], out decimal rabatt) ? rabatt : 0;
                    total += (price * count) * (1 - discount / 100);
                }
            }
            lblTotalValue.Text = $"€{total:F2}";

            // Reset form and focus on first field
            textBoxCount.Text = "";
            textBoxArticleNumber.Text = "";
            textBoxCategory.Text = "";
            textBoxExtra.Text = "";
            textBoxPrice.Text = "";
            textRabbatValue.Text = "";
            textBoxCount.Focus();
        }

        private void SaveOrders()
        {
            try
            {
                string filePath = Path.Combine(Application.StartupPath, "orders.txt");
                List<string> lines = File.Exists(filePath) ? new List<string>(File.ReadAllLines(filePath)) : new List<string>();

                // Add header if file is empty
                if (lines.Count == 0)
                {
                    lines.Add("Kunde Name\tKunde Nr.\tAnz\tNr\tBez\tS/J\tExtra\tPreis\tRabatt");
                }

                // Append new orders
                foreach (var order in tempOrders)
                {
                    lines.Add(string.Join("\t", order));
                }

                File.WriteAllLines(filePath, lines);
                MessageBox.Show("Orders saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear temporary storage and reset form
                tempOrders.Clear();
                dataGridView.Rows.Clear();
                LoadSampleData();
                textBoxCount.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Orders not saved!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show($"Error saving orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSampleData()
        {
            if (!DesignMode)
            {
                if (dataGridView.IsHandleCreated)
                {
                    AddSampleRows();
                }
                else
                {
                    dataGridView.HandleCreated += (s, e) => AddSampleRows();
                }
            }
        }

        private void AddSampleRows()
        {
            string filePath = Path.Combine(Application.StartupPath, "orders.txt");

            if (!File.Exists(filePath))
            {
                MessageBox.Show("orders.txt not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                dataGridView.Rows.Clear();
                string[] lines = File.ReadAllLines(filePath);
                string getCustomerNumber = "812";

                int startLine = lines.Length > 0 && lines[0].Contains("Kunde Name") ? 1 : 0;

                for (int i = startLine; i < lines.Length; i++)
                {
                    string[] columns = Regex.Split(lines[i].Trim(), @"\t|\s{2,}");
                    if (columns.Length >= 9 && columns[1].Trim() == getCustomerNumber)
                    {
                        string bez = string.Join(" ", columns.Skip(4).Take(columns.Length - 8));
                        dataGridView.Rows.Add(
                            columns[0].Trim(),
                            columns[1].Trim(),
                            columns[2].Trim(),
                            columns[3].Trim(),
                            bez,
                            columns[columns.Length - 4].Trim(),
                            columns[columns.Length - 3].Trim(),
                            columns[columns.Length - 2].Trim(),
                            columns[columns.Length - 1].Trim()
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                LoadSampleData();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DefaultTextBoxFont?.Dispose();
                DefaultLabelFont?.Dispose();
                PanelFont?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Add logic for textBoxCount TextChanged event if needed
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Add logic for textBoxArticleNumber TextChanged event if needed
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            // Add logic for textBoxCategory TextChanged event if needed
        }
        private void TextBoxRabbatValue_KeyPress(object sender, KeyPressEventArgs e)
         {
           if (e.KeyChar == (char) Keys.Enter)
              {
                   e.Handled = true; // Prevent beep
                    SubmitForm();
                }
         }
    }
}

