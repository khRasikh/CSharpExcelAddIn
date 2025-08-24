﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TestAddIn.article;
using TestAddIn.customer;
using TestAddIn.extras;
using TestAddIn.orders;
using TestAddIn.shared;

namespace TestAddIn
{

    public partial class Form1 : Form
    {
        private ListBox customerListBox;
        private Tools tools;
        private List<Article> articles;
        private List<Extras> extras = new List<Extras>();
        private ListBox searchListBox;

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
            
            // lastOrdersTable cell navigation 
            /*override method used ProcessCmdKey*/

            textBoxDiscount.KeyDown += OrderTextBox_KeyDown;

            // focus cursor on search box when form loads
            this.Load += (s, e) => search.Focus();

            // beam cursor default custom size
            tools = new Tools();
            tools.HookAllTextBoxes(this.Controls);
            // Custom beam for cells in lastORdersTable 
            lastOrdersTable.EditingControlShowing += LastOrdersTable_EditingControlShowing;

            // Handle cell edit end to auto-fill "Bez" based on "Nr"
            articles = Article.LoadArticles("article.json");
            lastOrdersTable.CellValueChanged += lastOrdersTable_CellValueChanged;

            //handle extra list 
            ExtrasManager.LoadExtras("extra.json");

            //top header
            Timer timer = new Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += Timer_Tick;
            timer.Start();

            labelPRValue.Text = "1";

            //popup
            searchListBox = new ListBox();
            searchListBox.Visible = false;
            searchListBox.Height = 200;
            searchListBox.Width = search.Width;
            searchListBox.Left = search.Left;
            searchListBox.Top = search.Bottom;
            searchListBox.Font = new Font("Segoe UI", 10);
            searchListBox.BringToFront();
            this.Controls.Add(searchListBox);

            // Event handlers
            searchListBox.KeyDown += SearchListBox_KeyDown;
            searchListBox.Click += SearchListBox_Click;

        }

        private void SearchListBox_Click(object sender, EventArgs e)
        {
            SelectCustomerFromPopup();
        }
         

        private void SelectCustomerFromPopup()
        {
            if (searchListBox.SelectedIndex >= 0 && searchListBox.Tag is List<Customer> matches)
            {
                var selectedCustomer = matches[searchListBox.SelectedIndex];
                PopulateCustomerFields(selectedCustomer);

                searchListBox.Visible = false;
                this.lastOrdersTable.Focus();
            }
        }
        private void PopulateCustomerFields(Customer found)
        {
            knr.Text = found.KNr;
            name.Text = found.Name;
            phone.Text = found.Tel;
            str.Text = found.Str;
            ort.Text = found.Ort;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            labelDate.Text = DateTime.Now.ToString("dd.MM.yyyy    HH:mm:ss");
        }

        private void LastOrdersTable_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (lastOrdersTable.IsCurrentCellDirty)
                lastOrdersTable.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void lastOrdersTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var dgv = sender as DataGridView;
            var editedCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
            string articlID = editedCell.Value?.ToString() ?? "";

            if (dgv.Columns[e.ColumnIndex].Name == "lastOrderNr")
            {
                var bezCell = dgv.Rows[e.RowIndex].Cells["lastOrderName"];
                var article = articles.FirstOrDefault(a => a.CompNum == articlID);
                if (article != null)
                    bezCell.Value = article.Name;
                else
                    bezCell.Value = "";

                // Move focus to lastOrderSize
                dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells["lastOrderSize"];
                dgv.BeginEdit(true);
            }
        }


        private void LastOrdersTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var dgv = sender as DataGridView;
            var editedCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
            string articlID = editedCell.Value?.ToString() ?? "";

            if (dgv.Columns[e.ColumnIndex].Name == "lastOrderNr")
            {
                var bezCell = dgv.Rows[e.RowIndex].Cells["lastOrderName"];
                if (bezCell != null)
                {
                    // Lookup in JSON
                    var article = articles.FirstOrDefault(a => a.CompNum == articlID);
                    if (article != null)
                        bezCell.Value = article.Name;
                    else
                        bezCell.Value = "";

                    // Move focus to lastOrderSize
                    dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells["lastOrderSize"];
                    dgv.BeginEdit(true);
                }
            }
        }

        private void LastOrderSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lastOrdersTable.CurrentCell == null) return;

            var dgv = lastOrdersTable;
            int rowIndex = dgv.CurrentCell.RowIndex;

            var anzCell = dgv.Rows[rowIndex].Cells["lastOrderAnz"];
            var nrCell = dgv.Rows[rowIndex].Cells["lastOrderNr"];
            var priceCell = dgv.Rows[rowIndex].Cells["lastOrderPrice"];
            var sizeCell = dgv.Rows[rowIndex].Cells["lastOrderSize"];

            string articlID = nrCell.Value?.ToString() ?? "";
            var article = articles.FirstOrDefault(a => a.CompNum == articlID);

            if (article == null) return;

            switch (char.ToUpper(e.KeyChar))
            {
                case 'S':
                    priceCell.Value = Convert.ToDecimal(article.SinglPreis) * Convert.ToDecimal(anzCell.Value);
                    break;
                case 'J':
                    priceCell.Value = Convert.ToDecimal(article.JumboPreis) * Convert.ToDecimal(anzCell.Value); 
                    break;
                case 'F':
                    priceCell.Value = Convert.ToDecimal(article.FamilyPreis) * Convert.ToDecimal(anzCell.Value);
                    break;
                case 'P':
                    priceCell.Value = Convert.ToDecimal(article.PartyPreis) * Convert.ToDecimal(anzCell.Value);
                    break;
                default:
                    break;
            }
        }
         

        private void LastOrdersTable_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox tb)
            {
                // --- Existing GotFocus handler ---
                tb.GotFocus -= Tb_GotFocus;
                tb.GotFocus += Tb_GotFocus;

                // --- Add KeyPress handlers for size and extra ---
                int colIndex = lastOrdersTable.CurrentCell.ColumnIndex;
                string colName = lastOrdersTable.Columns[colIndex].Name;

                // Remove previous KeyPress handlers
                tb.KeyPress -= LastOrderSize_KeyPress;

                if (colName == "lastOrderSize")
                {
                    tb.KeyPress += LastOrderSize_KeyPress;
                    tb.TextChanged += LastOrderSize_TextChanged;
                }
                else if (colName == "lastOrderExtra") //TODO: update extra
                                                      //tb.KeyPress += LastOrderExtra_KeyPress;
                {
                    //
                    // MessageBox.Show("KNr is required." + colName, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                UpdateTotals();
            }
        }

        private void LastOrderSize_TextChanged(object sender, EventArgs e)
        {
            if (!(sender is TextBox tb)) return;

            // Only enforce uppercase / single letter if current cell is lastOrderSize
            if (lastOrdersTable.CurrentCell?.OwningColumn.Name != "lastOrderSize")
                return;

            if (!string.IsNullOrEmpty(tb.Text))
                tb.Text = tb.Text.Substring(0, 1).ToUpper();

            tb.SelectionStart = tb.Text.Length;
            tb.SelectionLength = 0;
        }

        private void Tb_GotFocus(object sender, EventArgs e)
        {
            if (sender is TextBox tb)
            {
                tools.ApplyCustomCaret(tb);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            var dgv = lastOrdersTable;

            bool gridHasFocus =
                dgv != null &&
                (dgv.Focused || (dgv.EditingControl != null && dgv.EditingControl.Focused));

            if (!gridHasFocus)
                return base.ProcessCmdKey(ref msg, keyData);

            var key = keyData & Keys.KeyCode;

            if (key == Keys.Enter)
            {
                if (dgv.CurrentCell == null) return true;

                int curCol = dgv.CurrentCell.ColumnIndex;
                int curRow = dgv.CurrentCell.RowIndex;

                // Get column indexes safely
                int colLastOrderAnz = dgv.Columns.Contains("lastOrderAnz") ? dgv.Columns["lastOrderAnz"].Index : -1;
                int colLastOrderNr = dgv.Columns.Contains("lastOrderNr") ? dgv.Columns["lastOrderNr"].Index : -1;
                int colLastOrderBez = dgv.Columns.Contains("lastOrderBez") ? dgv.Columns["lastOrderBez"].Index : -1;
                int colLastOrderSize = dgv.Columns.Contains("lastOrderSize") ? dgv.Columns["lastOrderSize"].Index : -1;
                int colLastOrderExtra = dgv.Columns.Contains("LastOrderExtra") ? dgv.Columns["LastOrderExtra"].Index : dgv.Columns.Count - 1;
                //case 1: Enter on lastOrderAnz
                if(curCol == colLastOrderAnz)
                {
                    dgv.EndEdit();
                    dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);

                    string anzID = dgv.Rows[curRow].Cells["lastOrderAnz"].Value?.ToString()?.Trim() ?? "";
                    var anz = articles.FirstOrDefault(a => a.CompNum == anzID);

                    if (anz == null)
                    {
                        dgv.Rows[curRow].Cells["lastOrderAnz"].Value = 1;
                    }
                    dgv.CurrentCell = dgv.Rows[curRow].Cells["lastOrderNr"];
                    dgv.BeginEdit(true);
                    return true;
                }
                // --- Case 2: Enter on lastOrderNr ---
                else if (curCol == colLastOrderNr)
                {
                    dgv.EndEdit();
                    dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);

                    string articlID = dgv.Rows[curRow].Cells["lastOrderNr"].Value?.ToString()?.Trim() ?? "";
                    var article = articles.FirstOrDefault(a => a.CompNum == articlID);

                    if (article != null)
                    {
                        dgv.Rows[curRow].Cells["lastOrderName"].Value = article.Name;
                        dgv.CurrentCell = dgv.Rows[curRow].Cells["lastOrderSize"];
                    }
                    else
                    {
                        dgv.Rows[curRow].Cells["lastOrderName"].Value = "";
                        MessageBox.Show("Artikel nicht gefunden. Bitte prüfen!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgv.CurrentCell = dgv.Rows[curRow].Cells["lastOrderNr"];
                    }

                    dgv.BeginEdit(true);
                    return true;
                }

                // --- Case 2: Enter on LastOrderExtra ---
                // TODO: extra update
                else if (curCol == colLastOrderExtra)
                {
                    dgv.EndEdit();
                    dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);

                    // Get entered value from LastOrderExtra cell
                    string extraInput = dgv.Rows[curRow].Cells[colLastOrderExtra].Value?.ToString()?.Trim();
                    string sizeText = dgv.Rows[curRow].Cells["lastOrderSize"].Value?.ToString()?.Trim();
                    char sizeCode = 'S';
                    if (!string.IsNullOrEmpty(sizeText))
                        sizeCode = char.ToUpper(sizeText[0]);
                    //    MessageBox.Show("Extra value:" + extraInput + "SizeCode:"+ sizeCode, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (!string.IsNullOrEmpty(extraInput))
                    {
                        // Try to parse extra ID
                        if (int.TryParse(extraInput, out int extraId))
                        {
                            var extraItem = TestAddIn.extras.ExtrasManager.GetExtraByIdCode(extraId, sizeCode);
                            // Get the old extra ID stored in the cell (if any)
                            var oldExtraId = dgv.Rows[curRow].Cells[colLastOrderExtra].Tag as int?;

                            if (extraItem != null)
                            {

                                // If an old extra exists and is different from the new one, remove it first
                                if (oldExtraId.HasValue && oldExtraId.Value != extraItem.Id)
                                {
                                    var oldExtra = extras.FirstOrDefault(e => e.Id == oldExtraId.Value);
                                    if (oldExtra != null)
                                        extras.Remove(oldExtra);
                                }

                                // Check if the new extra already exists in the list
                                var existingExtra = extras.FirstOrDefault(e => e.Id == extraItem.Id);
                                if (existingExtra == null)
                                {
                                    extras.Add(extraItem); // Add new extra only if not already added
                                }

                                // Store the current ID in the cell's Tag for tracking future changes
                                dgv.Rows[curRow].Cells[colLastOrderExtra].Tag = extraItem.Id;
                            } 
                            else
                            {
                                var oldExtra = extras.FirstOrDefault(e => e.Id == oldExtraId.Value);
                                if (oldExtra != null)
                                    extras.Remove(oldExtra);
                                dgv.Rows[curRow].Cells["LastOrderExtra"].Value = 0;
                            }
                        }
                        else
                        {
                            // Invalid input → reset
                            dgv.Rows[curRow].Cells["LastOrderExtra"].Value = 0;
                            MessageBox.Show("Invalid Extra ID!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        // Empty input → reset
                        dgv.Rows[curRow].Cells["LastOrderExtra"].Value = 0;
                    }


                    // Move to next row, first column
                    int nextRow = curRow + 1;
                    int firstColIndex = 0;

                    if (nextRow >= dgv.Rows.Count - 1 && dgv.AllowUserToAddRows)
                        dgv.CurrentCell = dgv.Rows[dgv.NewRowIndex].Cells[firstColIndex];
                    else
                        dgv.CurrentCell = dgv.Rows[nextRow].Cells[firstColIndex];

                    dgv.BeginEdit(true);
                    return true;
                }
                // --- Case 3: Other columns → Enter acts like Tab ---
                SendKeys.Send("{TAB}");
                return true;
            }
            else if (key == Keys.F6)
            {
                this.textBoxDiscount.Focus(); 
                return true;
            }
            else if (key == Keys.F2)
            {
                dgv.Rows.Clear();
                extras.Clear();
                this.search.Focus();
            }
            else if (key == Keys.F3)
            {
                dgv.Rows.Clear();
                extras.Clear();
                this.name.Focus();
            }
            else if (key == Keys.Tab)
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
            else if (key == Keys.F1)
            {
                // Clear all rows
                dgv.Rows.Clear();
                extras.Clear();

                // Ensure at least one row exists
                if (!dgv.AllowUserToAddRows || dgv.Rows.Count == 0)
                    dgv.Rows.Add();

                // Focus on the "Anz" column (or first column if missing)
                int anzIndex = dgv.Columns.Contains("Anz") ? dgv.Columns["Anz"].Index : 0;
                int targetRowIndex = dgv.Rows.Count - 1; // last row (or the newly added one)

                // Set the current cell and begin edit immediately
                dgv.CurrentCell = dgv.Rows[targetRowIndex].Cells[anzIndex];
                dgv.BeginEdit(true);

                return true; // handled
            }
            else if (key == Keys.Back)
            {
                if (dgv.CurrentCell != null)
                {
                    int curRow = dgv.CurrentCell.RowIndex;
                    int curCol = dgv.CurrentCell.ColumnIndex;

                    // Get the current cell value
                    var currentValue = dgv.CurrentCell.Value?.ToString();

                    // CASE 1: If cell is NOT empty → clear the value, but stay in the same cell
                    if (!string.IsNullOrEmpty(currentValue))
                    {
                        dgv.CurrentCell.Value = string.Empty;
                        dgv.BeginEdit(true); // Keep editing mode
                        return true; // Handled
                    }

                    // CASE 2: If cell is already empty → move focus to previous cell
                    int prevCol = curCol - 1;
                    int prevRow = curRow;

                    // If we're at the start of the row, go to the last column of the previous row
                    if (prevCol < 0)
                    {
                        prevRow--;
                        if (prevRow >= 0)
                        {
                            prevCol = dgv.Columns.Count - 1;
                        }
                        else
                        {
                            // Already at the very first cell in the grid → do nothing
                            return true;
                        }
                    }

                    // Set the new current cell and enter edit mode
                    dgv.CurrentCell = dgv.Rows[prevRow].Cells[prevCol];
                    dgv.BeginEdit(true);
                    return true;
                }
            }
            else if (key == Keys.F9)
            {
                var customer = Customer.FindByKNr(this.knr.Text);
                PrintOrder(lastOrdersTable, customer); // pass your customer and DGV
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        //TODO> update this vlue 
        private void PrintOrder(DataGridView dgv, Customer customer)
        {
            // Collect order list from DGV

            var orderList = new List<dynamic>();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                // Safely parse total and discount
                decimal totalValue = 0;
                decimal discountValue = 0;

                decimal.TryParse(this.labelSumValue.Text, out totalValue);
                decimal.TryParse(this.labelLastDiscountValue.Text?.ToString() ?? "0", out discountValue);

                var order = new
                {
                    count = row.Cells["lastOrderAnz"].Value ?? 0,
                    id = row.Cells["lastOrderNr"].Value ?? "",
                    name = row.Cells["lastOrderName"].Value ?? "",
                    category = row.Cells["lastOrderSize"].Value ?? "",
                    total = totalValue,
                    discount = discountValue,
                    extra = new
                    {
                        id = Convert.ToDecimal(row.Cells["LastOrderExtra"].Value ?? 0),
                        name = "test",
                        price = Convert.ToDecimal("2.2")
                    }
                };
                orderList.Add(order);
            }


            // Prepare category mapping outside the loop
            var categoryMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                    {
                        { "Single", "S" },
                        { "Jumbo", "J" },
                        { "Family", "F" },
                        { "Party", "P" }
                    };

            // Build HTML string
            decimal totalPrices = 0;
            decimal totalDiscounts = 0;

            var sb = new StringBuilder();
            sb.Append("<html><head>");
            sb.Append("<style>table, th, td { border: 1px solid black; border-collapse: collapse; } th, td { padding: 4px; text-align: center; }</style>");
            sb.Append("</head><body>");
            sb.Append($"<div>{DateTime.Now:dd.MM.yyyy}</div>");
            sb.Append($"<div>Customer: {customer.KNr} - {customer.Name}</div>");
            sb.Append("<table><thead><tr><th>Anz</th><th>Nr.</th><th>Bez.</th><th>Kategorie</th><th>Pr</th></tr></thead><tbody>");

            foreach (var order in orderList)
            {
                totalPrices += Convert.ToDecimal(order.total);
                totalDiscounts += Convert.ToDecimal(order.discount) * Convert.ToDecimal(order.total) / 100;

                // Safe category lookup
                string categoryLetter;
                if (!categoryMap.TryGetValue(order.category ?? "", out categoryLetter))
                    categoryLetter = "";

                sb.Append($"<tr><td>{order.count}X</td><td>{order.id}</td><td>{order.name}</td><td>{categoryLetter}</td><td>{order.total}</td></tr>");

                if (Convert.ToInt16(order.extra.id) != 0)
                {
                    sb.Append($"<tr><td>-</td><td>{order.extra.id}</td><td>{order.extra.name}</td><td>-</td><td>{order.extra.price}</td></tr>");
                }
            }


            sb.Append("</tbody></table>");
            sb.Append($"<div>Total Brutto: €{(totalPrices + totalDiscounts):0.00}</div>");
            sb.Append($"<div>Total Discount: €{totalDiscounts:0.00}</div>");
            sb.Append($"<div>Total Netto: €{totalPrices:0.00}</div>");
            sb.Append("<div>Vielen Dank für Ihre Bestellung</div>");
            sb.Append("</body></html>");

            // Print using WebBrowser
            var wb = new WebBrowser
            {
                DocumentText = sb.ToString()
            };
            wb.DocumentCompleted += (s, e) =>
            {
                wb.Print();
            };
            // Add the WebBrowser to the form to keep it alive
            this.Controls.Add(wb);
        }


        private void OrderTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent the ding sound

                Control current = (Control)sender;

                //calculate Sum and Count 
                UpdateTotals();

                if (current == textBoxDiscount)
                {
                    SaveTableOrdersToFile();
                }
            }
        }
        private void SaveTableOrdersToFile()
        {
            if (string.IsNullOrWhiteSpace(knr.Text))
            {
                MessageBox.Show("KNr is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                search.Focus();
                return;
            }

            try
            {
                var ordersForKnr = new List<Order>();

                foreach (DataGridViewRow row in lastOrdersTable.Rows)
                {
                    if (row.IsNewRow) continue;

                    var order = new Order
                    {
                        KNr = knr.Text.Trim(),
                        Anz = row.Cells[0].Value?.ToString()?.Trim() ?? "",
                        Nr = row.Cells[1].Value?.ToString()?.Trim() ?? "",
                        Bez = row.Cells[2].Value?.ToString()?.Trim() ?? "",
                        Size = row.Cells[3].Value?.ToString()?.Trim() ?? "",
                        Extra = row.Cells[4].Value?.ToString()?.Trim() ?? "",
                        Price = row.Cells[5].Value?.ToString()?.Trim() ?? "",
                        Rabbat = this.textBoxDiscount.Text.Trim()
                    };

                    ordersForKnr.Add(order);
                }

                // 👉 einmal speichern mit allen Orders für diese KNr
                OrdersManager.SaveOrders("orders.txt", knr.Text, ordersForKnr);

                MessageBox.Show("Alle Bestellungen aus der Tabelle wurden erfolgreich gespeichert.",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                LoadOrdersForCustomer(knr.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving table orders: {ex.Message}\n\n{ex.StackTrace}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }


        private void SearchListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectCustomerFromPopup();
                e.Handled = true; // optional
            }
            else if (e.KeyCode == Keys.Escape)
            {
                searchListBox.Visible = false; // hide the popup
                e.Handled = true;
                this.search.Focus();
            }
        }

        private void LoadOrdersForCustomer(string customerId)
        {
            var filteredOrders = OrdersManager
                .GetAll()
                .Where(o => o.KNr.Trim() == customerId.Trim())
                .ToList();

            lastOrdersTable.Rows.Clear(); 

            foreach (var order in filteredOrders)
            {
                lastOrdersTable.Rows.Add(order.Anz, order.Nr, order.Bez, order.Size, order.Extra, order.Price, order.Rabbat);
            }

            UpdateTotals();
        }

        private string GetStreetNumber(string street)
        {
            if (string.IsNullOrWhiteSpace(street))
                return "";

            // Extract first number found in the street string
            var match = System.Text.RegularExpressions.Regex.Match(street, @"\d+");
            return match.Success ? match.Value : "";
        }

        private string GetStreetName(string street)
        {
            if (string.IsNullOrWhiteSpace(street))
                return "";

            // Remove the street number part
            return System.Text.RegularExpressions.Regex.Replace(street, @"\d+", "").Trim();
        }

        private void search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var input = search.Text.Trim();
                if (string.IsNullOrEmpty(input)) return;

                // Check if the input is numeric → treat it as KNr
                if (int.TryParse(input, out _))
                {
                    // Get last discount
                    int lastDiscountPercentage = OrdersManager.GetLastDiscount(search.Text, "orders.txt");
                    textBoxDiscount.Text = lastDiscountPercentage.ToString() ?? "0";

                    var found = Customer.FindByKNr(input);

                    if (found != null)
                    {
                        PopulateCustomerFields(found);
                        this.lastOrdersTable.Focus();
                        return;
                    }
                    else
                    {
                        knr.Text = string.Empty;
                        name.Text = string.Empty;
                        phone.Text = string.Empty;
                        str.Text = string.Empty;
                        ort.Text = string.Empty;

                        var result = MessageBox.Show("Kunde nicht gefunden. Möchten Sie einen neuen Kunden anlegen?",
                                                     "Kunde anlegen",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            var allCustomers = Customer.GetAll();
                            int maxKnr = allCustomers
                                .Select(c => int.TryParse(c.KNr, out int num) ? num : 0)
                                .DefaultIfEmpty(0)
                                .Max();

                            knr.ReadOnly = true;
                            knr.Text = (maxKnr + 1).ToString();
                            name.Focus();
                        }
                        return;
                    }
                }
                else
                {
                    // Non-numeric → search by address
                    var matches = Customer.GetByAddress(input);

                    searchListBox.Items.Clear();
                    searchListBox.Visible = false;

                    if (matches.Count > 0)
                    {
                        searchListBox.Items.Clear();

                        // Add header first
                        searchListBox.Items.Add(
                            string.Format("{0,-5} {1,-15} {2,-20} {3,-25} {4,-15}",
                                "NO", "Str.No", "Name", "Str", "Tel")
                        );
                        searchListBox.Items.Add(new string('-', 85)); // separator line

                        int index = 1;
                        foreach (var customer in matches)
                        {
                            // Split street into number + name
                            string streetNumber = GetStreetNumber(customer.Str);
                            string streetName = GetStreetName(customer.Str);

                            searchListBox.Items.Add(
                                string.Format("{0,-5} {1,-6} {2,-15} {3,-20} {4,-10}",
                                    index,
                                    streetNumber,
                                    customer.Name,
                                    streetName,
                                    customer.Tel
                                )
                            );
                            index++;
                        }

                        searchListBox.Tag = matches; // Store matches for later selection
                        searchListBox.ItemHeight = 32; // Adjust row height for padding effect
                        searchListBox.BackColor = Color.Black;
                        searchListBox.ForeColor = Color.White;
                        searchListBox.BorderStyle = BorderStyle.FixedSingle;
                        searchListBox.Width = 1000; // Wider for readability
                        searchListBox.Height = Math.Min(400, matches.Count * searchListBox.ItemHeight + 8); // Add some padding
                        searchListBox.Font = new Font(FontFamily.GenericMonospace, 16, FontStyle.Regular);


                        // Center on the screen
                        searchListBox.Left = (this.ClientSize.Width - searchListBox.Width) / 2;
                        searchListBox.Top = (this.ClientSize.Height - searchListBox.Height) / 2;

                        searchListBox.BringToFront();
                        searchListBox.Visible = true;
                        searchListBox.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No matching addresses found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            //focus on the first cell of lastOrdersTable 
                            OrdersManager.FocusCursorOnAnz(lastOrdersTable);
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
                OrdersManager.FocusCursorOnAnz(lastOrdersTable);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                } else if (e.KeyCode == Keys.Escape)
                {
                    customerListBox.Visible = false;
                    e.Handled = true;
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

        private void UpdateTotals()
        {
            try
            {
                int totalCount = 0;
                decimal totalSum = 0;
                decimal totalExtra = 0;
                decimal lastTotalDiscountValue = 0;

                // Get discount from TextBox (user can change it)
                int lastDiscountPercentage = 0;
                int.TryParse(textBoxDiscount.Text.Trim(), out lastDiscountPercentage);

                foreach (DataGridViewRow row in lastOrdersTable.Rows)
                {
                    if (row.IsNewRow) continue;

                    // totalCount
                    if (int.TryParse(row.Cells["lastOrderAnz"].Value?.ToString(), out int anz))
                        totalCount += anz;

                    // totalSum and extra
                    decimal price = 0;
                    decimal.TryParse(row.Cells["lastOrderPrice"].Value?.ToString(), out price);

                    totalSum += price;
                }

                if (extras.Count > 0)
                {
                    totalExtra = extras.Sum(e => e.Price);
                }

                // Calculate discount amount
                lastTotalDiscountValue = ((totalSum + totalExtra) * lastDiscountPercentage) / 100;

                // Update labels
                labelCountValue.Text = totalCount.ToString();
                labelSumValue.Text = "€" + ((totalSum + totalExtra) - lastTotalDiscountValue).ToString("F2");
                labelLastDiscountValue.Text = $"(- €{lastTotalDiscountValue:F2})";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating totals: " + ex.Message);
            }
        }

        private void textBoxDiscount_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }
    }
}
