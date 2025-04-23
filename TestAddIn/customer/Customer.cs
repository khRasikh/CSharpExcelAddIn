using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TestAddIn.customer
{
    internal class Customer
    {
        public string KNr { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public string Ort { get; set; }
        public string Str { get; set; }
        public string Bemerkung { get; set; }
        public string Seit { get; set; }
        public string Mal { get; set; }
        public string DM { get; set; }
        public string Letzte { get; set; }
        public string Rabatt { get; set; }
        public string Fix { get; set; }

        private static List<Customer> customers = new List<Customer>();

        public static void LoadCustomers(string filePath)
        {
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
                    var columns = line.Split('\t');
                    if (columns.Length >= 12)
                    {
                        var customer = new Customer
                        {
                            KNr = columns[0],
                            Name = columns[1],
                            Tel = columns[2],
                            Str = columns[3],
                            Ort = columns[4],
                            Bemerkung = columns[5],
                            Seit = columns[6],
                            Mal = columns[7],
                            DM = columns[8],
                            Letzte = columns[9],
                            Rabatt = columns[10],
                            Fix = columns[11]
                        };
                        customers.Add(customer);
                    }
                }

                Console.WriteLine("Customers loaded: " + customers.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message);
            }
        }


        public static Customer FindByKNr(string knr)
        {
            return customers.Find(c => c.KNr == knr.Trim());
        }


        public static List<Customer> GetAll()
        {
            return customers; 
        }

    }
}
