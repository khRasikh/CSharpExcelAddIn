using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TestAddIn.customer;

namespace TestAddIn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //C:\Users\KhudaDadRasikh\Desktop\projects\.net\crud-main\WindowsFormsApp1\WindowsFormsApp1\db\customers.txt
            Customer.LoadCustomers("customers.txt");
            this.knr.KeyDown += Input_KeyDown;
            this.name.KeyDown += Input_KeyDown;
            this.phone.KeyDown += Input_KeyDown;
            this.str.KeyDown += Input_KeyDown;
            this.ort.KeyDown += Input_KeyDown;

        }


        private void search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var input = search.Text.Trim();

                if (!string.IsNullOrEmpty(input))
                {
                    // Try to find customer
                    var found = Customer.FindByKNr(input);

                    if (found != null)
                    {
                        // Customer found - populate fields
                        knr.Text = found.KNr;
                        name.Text = found.Name;
                        phone.Text = found.Tel;
                        str.Text = found.Str;
                        ort.Text = found.Ort;
                        label4.Text = found.Name;
                    }
                    else
                    {
                        // Customer not found - clear fields
                        knr.Text = string.Empty;
                        name.Text = string.Empty;
                        phone.Text = string.Empty;
                        str.Text = string.Empty;
                        ort.Text = string.Empty;
                        label4.Text = "No";

                        // Ask user if they want to create a new customer
                        var result = MessageBox.Show("Customer not found. Do you want to create a new customer?",
                                                     "Create Customer",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            var allCustomers = Customer.GetAll(); // Assumes you have this method
                            int maxKnr = 0;

                            foreach (var cust in allCustomers)
                            {
                                if (int.TryParse(cust.KNr, out int parsedKnr))
                                {
                                    if (parsedKnr > maxKnr)
                                        maxKnr = parsedKnr;
                                }
                            }

                            int newKnr = maxKnr + 1;
                            knr.ReadOnly = true;
                            knr.Text = newKnr.ToString();

                            // Focus the name field so user can begin entry
                            name.Focus();
                        }
                    }
                }
            }
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // prevent ding sound

                Control current = (Control)sender;

                if (current == knr)
                    name.Focus();
                else if (current == name)
                    phone.Focus();
                else if (current == phone)
                    str.Focus();
                else if (current == str)
                    ort.Focus();
                else if (current == ort)
                {
                    // Last field - submit data
                    SaveCustomerToFile();
                }
            }
        }

        private void SaveCustomerToFile()
        {
            // Fill missing fields with blanks or sensible defaults
            string bemerkung = "";
            string seit = DateTime.Now.ToString("dd.MM.yy");
            string mal = "1";
            string dm = "0,00";
            string letzte = DateTime.Now.ToString("dd.MM.yy");
            string rabatt = "0";
            string fix = "";

            string line = $"{knr.Text}\t{name.Text}\t{phone.Text}\t{str.Text}\t{ort.Text}\t{bemerkung}\t{phone.Text}\t{seit}\t{mal}\t{dm}\t{letzte}\t{rabatt}";

            string path = "customers.txt";

            try
            {
                File.AppendAllText(path, line + Environment.NewLine);
                MessageBox.Show("Customer saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear fields and reset focus
                knr.Text = name.Text = phone.Text = str.Text = ort.Text = "";
                knr.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*customize cursor focus*/
        [DllImport("user32.dll")]
        private static extern bool CreateCaret(IntPtr hWnd, IntPtr hBitmap, int nWidth, int nHeight);

        [DllImport("user32.dll")]
        private static extern bool ShowCaret(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool SetCaretPos(int x, int y);

        private void search_GotFocus(object sender, EventArgs e)
        {
            CreateCaret(search.Handle, IntPtr.Zero, 4, search.Font.Height);
            ShowCaret(search.Handle);
        }


        /*menu button click*/
        private void menuButton_Click(object sender, EventArgs e)
        {
            contextMenu.Show(menuButton, new System.Drawing.Point(0, menuButton.Height));
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Option 1 selected");
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Option 2 selected");
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Option 3 selected");
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            // You can leave this empty or handle other search-related functionality here
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Optional: You can remove this if it's not needed
        }

        // Optional: Remove empty label click handlers
        private void labelPhoneValue_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void labelOrtValue_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
    }
}
