using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TestAddIn.customer;
using TestAddIn.orders;

namespace TestAddIn
{
 
public partial class Form1 : Form
    {
        private ListBox customerListBox;
        public Form1()
        {
            InitializeComponent();
            // Add ListBox programmatically with professional attributes
            customerListBox = new ListBox
            {
                Name = "customerListBox",
                Visible = false,
                Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular), // Professional, readable font
                ForeColor = System.Drawing.Color.DarkBlue, // Consistent with your choice
                BackColor = System.Drawing.Color.WhiteSmoke, // Subtle background for contrast
                BorderStyle = BorderStyle.FixedSingle, // Clean border
                Height = 400, // Set height to 400px as specified
                ScrollAlwaysVisible = true, // Visible vertical scrollbar for overflow
                IntegralHeight = false, // Allow exact height
                MultiColumn = false, // Single-column display
                SelectionMode = SelectionMode.One, // Single item selection
                ItemHeight = 20, // Adjust item height to fit font
            };
            this.Controls.Add(customerListBox);
            customerListBox.SelectedIndexChanged += customerListBox_SelectedIndexChanged;

            // Load customer file as db
            Customer.LoadCustomers("customers.txt");
            this.knr.KeyDown += Input_KeyDown;
            this.name.KeyDown += Input_KeyDown;
            this.phone.KeyDown += Input_KeyDown;
            this.str.KeyDown += Input_KeyDown;
            this.ort.KeyDown += Input_KeyDown;
            this.str.KeyDown += str_KeyDown;

            // Load orders file as a db
            OrdersManager.LoadOrders("orders.txt");
            LoadOrdersForCustomer(this.knr.Text);
            textBoxName.KeyDown += OrderTextBox_KeyDown;
            textBoxNr.KeyDown += OrderTextBox_KeyDown;
            textBoxSize.KeyDown += OrderTextBox_KeyDown;
            textBoxCount.KeyDown += OrderTextBox_KeyDown;
            textBoxExtra.KeyDown += OrderTextBox_KeyDown;
            textBoxPrice.KeyDown += OrderTextBox_KeyDown;

        }

        private void OrderTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent the ding sound

                Control current = (Control)sender;

                if (current == textBoxName)
                    textBoxNr.Focus();
                else if (current == textBoxNr)
                    textBoxSize.Focus();
                else if (current == textBoxSize)
                    textBoxCount.Focus();
                else if (current == textBoxCount)
                    textBoxExtra.Focus();
                else if (current == textBoxExtra)
                    textBoxPrice.Focus();
                else if (current == textBoxPrice)
                {
                    // Last field - save the order
                    SaveOrderToFile();

                    // Optionally clear fields or focus back to first field
                    textBoxName.Focus();
                }
            }
        }

        private void SaveOrderToFile()
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(knr.Text))
            {
                MessageBox.Show("KNr is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                search.Focus();
                return;
            }


            // Create order object (adjust based on your Order class structure)
            var order = new Order
            {
                KNr = knr.Text.Trim(),
                Name = textBoxName.Text.Trim(),
                Nr = textBoxNr.Text.Trim(),
                Size = textBoxSize.Text.Trim(),
                Count = textBoxCount.Text.Trim(),
                Extra = textBoxExtra.Text.Trim(),
                Price = textBoxPrice.Text.Trim(),
                Discount = "0" // Default value or get from another control
            };

            try
            {
                // Call your SaveOrder function from orders.cs
                OrdersManager.SaveOrder(order, "orders.txt");

                MessageBox.Show("Eine neue Bestellung wurde erfolgreich gespeichert.\r\n", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear fields after saving
                textBoxName.Text = "";
                textBoxNr.Text = "";
                textBoxSize.Text = "";
                textBoxCount.Text = "";
                textBoxExtra.Text = "";
                textBoxPrice.Text = "";
                textBoxDiscount.Text = "";

                // Refresh orders display if needed
                LoadOrdersForCustomer(knr.Text);

                // Focus back to first field
                textBoxName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadOrdersForCustomer(string customerId)
        {
            var filteredOrders = OrdersManager
                .GetAll()
                .Where(o => o.KNr.Trim() == customerId.Trim())
                .ToList();

            lastOrdersTable.Rows.Clear(); // Assuming you are manually adding rows

            foreach (var order in filteredOrders)
            {
                lastOrdersTable.Rows.Add(order.Name, order.Nr, order.Size, order.Count, order.Extra, order.Price, order.Discount);
            }
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
                        // focus cursor on Str if there is a list of streets popup 
                        if(found.Str != "" ) {
                            str.Focus();
                        }
                    }
                    else
                    {
                        // Customer not found - clear fields
                        knr.Text = string.Empty;
                        name.Text = string.Empty;
                        phone.Text = string.Empty;
                        str.Text = string.Empty;
                        ort.Text = string.Empty;

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
            // Validate required fields in logical order
            if (string.IsNullOrWhiteSpace(knr.Text))
            {
                MessageBox.Show("KNR is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                knr.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(name.Text))
            {
                MessageBox.Show("Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                name.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(phone.Text))
            {
                MessageBox.Show("Phone number is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                phone.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(str.Text))
            {
                MessageBox.Show("Street is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                str.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(ort.Text))
            {
                MessageBox.Show("City is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ort.Focus();
                return;
            }

            // Fill optional fields with defaults
            string bemerkung = "";
            string seit = DateTime.Now.ToString("dd.MM.yy");
            string mal = "1";
            string dm = "0,00";
            string letzte = DateTime.Now.ToString("dd.MM.yy");
            string rabatt = "0";

            string line = $"{knr.Text}\t{name.Text}\t{phone.Text}\t{str.Text}\t{ort.Text}\t{bemerkung}\t{phone.Text}\t{seit}\t{mal}\t{dm}\t{letzte}\t{rabatt}";
            string path = "customers.txt";

             
            try
            {
                // Check if the KNR already exists in the file
                if (File.Exists(path))
                {
                    var existingLines = File.ReadAllLines(path).ToList();

                    for (int i = 0; i < existingLines.Count; i++)
                    {
                        var fields = existingLines[i].Split('\t');
                        if (fields.Length > 0 && fields[0] == knr.Text)
                        {
                            existingLines[i] = line; // update the existing record
                            File.WriteAllLines(path, existingLines); // save changes
                            textBoxName.Focus();
                            return;
                        }
                    }
                }

                // add the record to file 
                File.AppendAllText(path, line + Environment.NewLine);
                MessageBox.Show("Customer saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                /* TODO:
                 * update the last order table by calling 
                 * move cursor on the first input box of CreateOrderForm
                 */
                textBoxName.Focus();

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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void createOrderForm_Load(object sender, EventArgs e)
        {

        }

        private void phone_TextChanged(object sender, EventArgs e)
        {

        }

        private void knr_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(knr.Text))
            {
                LoadOrdersForCustomer(knr.Text);
            }
            else
            {
                lastOrdersTable.Rows.Clear();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void customerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customerListBox == null || customerListBox.SelectedIndex < 0) return;

            var input = str.Text.Trim().ToLower();
            var customers = Customer.GetAll();
            // Group customers by Name and take the first occurrence
            var filteredCustomers = customers
                .Where(c => c.Str != null && c.Str.ToLower().StartsWith(input))
                .GroupBy(c => c.Name)
                .Select(g => g.First())
                .ToList();

            
        }
        private int FindStreetNumberIndex(string street)
        {
            for (int i = 0; i < street.Length; i++)
            {
                if (char.IsDigit(street[i]))
                {
                    if (i > 0 && (street[i - 1] == ' ' || street[i - 1] == '-' || street[i - 1] == '.'))
                    {
                        return i;
                    }
                    else if (i == 0)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        private void str_TextChanged(object sender, EventArgs e)
        {
            if (customerListBox == null) return; // Safety check

            var input = str.Text.Trim();
            customerListBox.Items.Clear();
            customerListBox.Visible = false;

            if (input.Length >= 2) // Only process if at least 2 characters
            {
                var customers = Customer.GetAll();
                // Group customers by Name and take the first occurrence
                var matches = customers
                    .Where(c => c.Str != null && c.Str.ToLower().StartsWith(input.ToLower()))
                    .GroupBy(c => c.Name)
                    .Select(g => g.First())
                    .ToList();

                foreach (var customer in matches)
                {
                    customerListBox.Items.Add($"{customer.Str} ({customer.Ort})");
                }

                if (matches.Count > 0)
                {
                    customerListBox.Visible = true;
                    // Ensure str control is valid before accessing Bottom
                    if (str != null && str.IsHandleCreated)
                    {
                        customerListBox.Top = str.Bottom + 60; // Position below str TextBox with 20px margin
                    }
                    else
                    {
                        // Fallback: Position relative to form's top
                        customerListBox.Top = 100;
                    }
                    customerListBox.Left = str?.Left ?? 10; // Fallback to 10 if str is null
                    customerListBox.Width = str?.Width ?? 200; // Fallback to 200 if str is null
                    customerListBox.Height = 400; // Match constructor height
                    customerListBox.BringToFront(); // Ensure highest display priority

                    if (matches.Count == 1)
                    {
                        // Single match found, populate fields
                        var customer = matches[0];
                        str.Text = customer.Str;
                        ort.Text = customer.Ort;
                        customerListBox.Visible = false;

                        // Set cursor to the street number
                        int streetNumberIndex = FindStreetNumberIndex(customer.Str);
                        if (streetNumberIndex >= 0)
                        {
                            int endIndex = streetNumberIndex;
                            while (endIndex < customer.Str.Length &&
                                   (char.IsLetterOrDigit(customer.Str[endIndex]) || customer.Str[endIndex] == ' '))
                            {
                                endIndex++;
                            }
                            str.SelectionStart = streetNumberIndex;
                            str.SelectionLength = endIndex - streetNumberIndex;
                        }
                    }
                }
            }
        }

        private void str_KeyDown(object sender, KeyEventArgs e)
        {
            if (customerListBox.Visible && customerListBox.Items.Count > 0)
            {
                if (e.KeyCode == Keys.Down)
                {
                    e.Handled = true;
                    if (customerListBox.SelectedIndex < customerListBox.Items.Count - 1)
                        customerListBox.SelectedIndex++;
                }
                else if (e.KeyCode == Keys.Up)
                {
                    e.Handled = true;
                    if (customerListBox.SelectedIndex > 0)
                        customerListBox.SelectedIndex--;
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;

                    var input = str.Text.Trim().ToLower();
                    var customers = Customer.GetAll();
                    var filteredCustomers = customers
                        .Where(c => c.Str != null && c.Str.ToLower().StartsWith(input))
                        .GroupBy(c => c.Name)
                        .Select(g => g.First())
                        .ToList();

                    if (customerListBox.SelectedIndex >= 0 && customerListBox.SelectedIndex < filteredCustomers.Count)
                    {
                        var selectedCustomer = filteredCustomers[customerListBox.SelectedIndex];
                        str.Text = selectedCustomer.Str;
                        ort.Text = selectedCustomer.Ort;
                        customerListBox.Visible = false;

                        str.Focus();
                        // Set cursor to the street number
                        int streetNumberIndex = FindStreetNumberIndex(selectedCustomer.Str);
                        if (streetNumberIndex >= 0)
                        {
                            int endIndex = streetNumberIndex;
                            while (endIndex < selectedCustomer.Str.Length &&
                                   (char.IsLetterOrDigit(selectedCustomer.Str[endIndex]) || selectedCustomer.Str[endIndex] == ' '))
                            {
                                endIndex++;
                            }
                            str.SelectionStart = streetNumberIndex;
                            str.SelectionLength = endIndex - streetNumberIndex;
                        }

                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void personalInfoPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void orderBez_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
