using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pages.MasterPages
{
    class SıralamaMasterPage : MasterDetailPage
    {
        public SıralamaMasterPage()
        {
            Master = new MyMenu();
            Detail = new SıralamaPage();
        }
    }
}
