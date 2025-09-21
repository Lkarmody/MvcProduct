using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Infrastructure.Data
{
    public class SettingsManager
    {
        private static string _filePath = "settings.xml";

        // Save a simple XML file
        public static void Save(string filePath = null)
        {
            if (filePath != null)
                _filePath = filePath;

            var doc = new XDocument(
                new XElement("Root",
                    new XElement("Child", "content")
                )
            );

            doc.Save(_filePath);
            Console.WriteLine($"Settings saved to {_filePath}");
            Console.WriteLine(File.ReadAllText(_filePath));
        }

        // Load a simple XML file
        public static void Load(string filePath = null)
        {
            if (filePath != null)
                _filePath = filePath;

            if (!File.Exists(_filePath))
            {
                Console.WriteLine("Settings file not found, creating default...");
                Save(_filePath); // create default
                return;
            }

            var doc = XDocument.Load(_filePath);
            Console.WriteLine($"Settings loaded from {_filePath}:");
            Console.WriteLine(doc.ToString());
        }
    }
}
