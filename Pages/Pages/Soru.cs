using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages
{
    public class Soru
    {
        public string Id { get; set; }
        public int soruid { get; set; }
        public int ekleyenid { get; set; }
        public string ekleyen { get; set; }
        public int cevaplayanid { get; set; }
        public string cevaplayan { get; set; }
        public string textorurl { get; set; }
        public string text { get; set; }
        public bool isAnswered { get; set; }
        public bool isPhoto { get; set; }
        public bool IsShow { get; set; }
        public DateTime koyulmatarihi { get; set; }
        public DateTime cevaplanmatarihi { get; set; }
        public string icon { get; set; } 
    }
}
