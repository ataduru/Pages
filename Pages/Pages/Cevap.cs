using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages
{
    public class Cevap
    {
        public string Id { get; set; }
        public int cevapid { get; set; }
        public int ekleyenid { get; set; }
        public string ekleyen { get; set; }
        public int sorunid { get; set; }
        public string textorurl { get; set; }
        public string text { get; set; }
        public bool isPhoto { get; set; }
        public DateTime koyulmatarihi { get; set; }
        public int puan { get; set; }
        public bool puanlandimi { get; set; }
    }
}
