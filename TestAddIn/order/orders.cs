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
        public string Name { get; set; }
        public string Nr { get; set; }
        public string Size { get; set; }
        public string Count { get; set; }
        public string Extra { get; set; }
        public string Price { get; set; }
        public string Discount { get; set; }
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
                            Name = columns[1],
                            Nr = columns[2],
                            Size = columns[3],
                            Count = columns[4],
                            Extra = columns[5].Replace("€", "").Trim(),
                            Price = columns[6].Replace("€", "").Trim(),
                            Discount = columns[7].Replace("%", "").Trim()
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
            if (string.IsNullOrWhiteSpace(order.KNr) ||
                string.IsNullOrWhiteSpace(order.Discount))
            {
                MessageBox.Show("All fields must be filled out before saving.");
                return;
            }

            try
            {
                string line = $"{order.KNr}\t{order.Name}\t{order.Nr}\t{order.Size}\t{order.Count}\t{order.Extra}\t{order.Price}\t{order.Discount}";
                File.AppendAllText(filePath, line + Environment.NewLine);
                orders.Add(order);
                MessageBox.Show("Eine neue Bestellung wurde erfolgreich gespeichert.\r\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving order: " + ex.Message);
            }
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
