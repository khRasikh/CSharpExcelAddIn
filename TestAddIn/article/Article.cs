using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace TestAddIn.article
{
    internal class Article
    {
        public string Type { get; set; }
        public string CompNum { get; set; }
        public string IhreNum { get; set; }
        public string Name { get; set; }
        public string SinglPreis { get; set; }
        public string JumboPreis { get; set; }
        public string FamilyPreis { get; set; }
        public string PartyPreis { get; set; }
        public string MWSt { get; set; }
        public string Rabatt { get; set; }

        // Load JSON file into a list of Article
        public static List<Article> LoadArticles(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath, Encoding.UTF8);
                return JsonSerializer.Deserialize<List<Article>>(json) ?? new List<Article>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load articles: " + ex.Message);
                return new List<Article>();
            }
        }
    }
}
