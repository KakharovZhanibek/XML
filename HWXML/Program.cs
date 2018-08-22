using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using HWXML.Modul;
namespace HWXML
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("https://habrahabr.ru/rss/interesting/");
            List<Item> items = new List<Item>();

            foreach (XmlNode root in doc.SelectNodes("rss/channel/item"))
            {
                Item item = new Item();
                item.Title = root
                    .SelectSingleNode("title")
                    .InnerText;
                item.Description = root
                    .SelectSingleNode("description")
                    .InnerText;
                item.Link = root
                    .SelectSingleNode("link")
                    .InnerText;
                item.PubDate = DateTime.Parse(root
                    .SelectSingleNode("pubDate")
                    .InnerText);
                items.Add(item);
            }
            foreach (Item it in items)
            {
                it.Print();
            }
            XmlSerializer x = new XmlSerializer(items.GetType());
            using (FileStream f = new FileStream(@"C:\Users\ОмаровК\source\repos\HWXML\HWXML\bin\Debug\Items.xml", FileMode.OpenOrCreate))
            {
                x.Serialize(f, items);
                Console.WriteLine("Список объектов успешно сериализирован!");
            }
        }
    }
}
