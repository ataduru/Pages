using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pages
{
    class MasterAnswerPage : MasterDetailPage
    {
        public MasterAnswerPage()
        {
            Master = new MyMenu();
            Detail = new CevapSayfa();
        }
    }
}
