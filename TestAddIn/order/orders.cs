using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace TestAddIn.orders
{
    public class Order
    {
        public string KNr { get; set; }
        public string Anz { get; set; }
        public string Nr { get; set; }
        public string Bez { get; set; }
        public string Size { get; set; }
        public string Extra { get; set; }
        public string Price { get; set; }
        public string Rabbat { get; set; }
    }

    public static class OrdersManager
    {
        private static List<Order> orders = new List<Order>();

        public static void LoadOrders(string filePath)
        {
            orders.Clear();

            if (!File.Exists(filePath))
            {
                MessageBox.Show("File not found: " + filePath);
                return;
            }

            try
            {
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines.Skip(1)) // Skip header
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    // Normalize whitespace: Replace tabs with single space, then split
                    var normalizedLine = Regex.Replace(line.Trim(), @"\s+", "\t");
                    var columns = normalizedLine.Split('\t');

                    if (columns.Length >= 8)
                    {
                        var order = new Order
                        {
                            KNr = columns[0],
                            Anz = columns[1],
                            Nr = columns[2],
                            Size = columns[3],
                            Bez = columns[4],
                            Extra = columns[5].Replace("€", "").Trim(),
                            Price = columns[6].Replace("€", "").Trim(),
                            Rabbat = columns[7].Replace("%", "").Trim()
                        };

                        orders.Add(order);
                    }
                    else
                    {
                        MessageBox.Show($"Invalid line format:\n{line}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message);
            }
        }


        public static void SaveOrder(Order order, string filePath)
        {
            if (string.IsNullOrWhiteSpace(order.KNr) || string.IsNullOrWhiteSpace(order.Rabbat))
            {
                MessageBox.Show("All fields must be filled out before saving.");
                return;
            }

            try
            {
                List<string> lines = new List<string>();
                if (File.Exists(filePath))
                {
                    // Read all lines and remove any line with the same KNr
                    lines = File.ReadAllLines(filePath)
                                .Where(l => !l.StartsWith(order.KNr + "\t"))
                                .ToList();
                }

                // Add the new order
                string newLine = $"{order.KNr}\t{order.Anz}\t{order.Nr}\t{order.Size}\t{order.Bez}\t{order.Extra}\t{order.Price}\t{order.Rabbat}";
                lines.Add(newLine);

                // Overwrite the file with the updated list
                File.WriteAllLines(filePath, lines);

                // Update in-memory list
                orders.RemoveAll(o => o.KNr == order.KNr);
                orders.Add(order);

                MessageBox.Show("Die Bestellung wurde erfolgreich gespeichert oder aktualisiert.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving order: " + ex.Message);
            }
        }


        public static void FocusCursorOnAnz(DataGridView lastOrdersTable)
        {
            if (lastOrdersTable.Rows.Count > 0)
            {
                // Skip the new row at the bottom
                int rowIndex = lastOrdersTable.Rows.Count - 1;
                if (lastOrdersTable.Rows[rowIndex].IsNewRow && rowIndex > 0)
                    rowIndex--;

                // Focus the first cell of the row
                lastOrdersTable.CurrentCell = lastOrdersTable.Rows[rowIndex].Cells[0];
                lastOrdersTable.Focus();
            }
        }

        public static decimal GetLastDiscount(string KNr, string filePath)
        {
            decimal discount = 0;

            if (!File.Exists(filePath))
            {
                MessageBox.Show("File not found: " + filePath);
                return discount;
            }

            try
            {
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines.Skip(1)) // Skip header
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    // Normalize whitespace and split by tab
                    var normalizedLine = Regex.Replace(line.Trim(), @"\s+", "\t");
                    var columns = normalizedLine.Split('\t');

                    if (columns.Length >= 8)
                    {
                        string rowKNr = columns[0];
                        string rabbatStr = columns[7].Replace("%", "").Trim();

                        if (rowKNr == KNr && !string.IsNullOrWhiteSpace(rabbatStr))
                        {
                            decimal.TryParse(rabbatStr, out discount);
                            break; // Found the first match, exit
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting last discount: " + ex.Message);
            }

            return discount;
        }

        public static List<Order> GetAll()
        {
            return orders;
        }

        public static void Clear()
        {
            orders.Clear();
        }
    }
}
