using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWXML.Modul
{
    [Serializable]
    public class Item
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public DateTime PubDate { get; set; }
        public void Print()
        {
            Console.WriteLine("\n-------------------------------");
            Console.WriteLine(Title);
            Console.WriteLine(Link);
            Console.WriteLine(Description);
            Console.WriteLine(PubDate);
            Console.WriteLine("\n-------------------------------");
        }
    }
}
