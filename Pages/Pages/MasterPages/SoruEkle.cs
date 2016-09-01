using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pages
{
    class SoruEkle : MasterDetailPage
    {
        public SoruEkle()
        {
            Master = new MyMenu();
            Detail = new AddQuestion();
        }
    }
}
