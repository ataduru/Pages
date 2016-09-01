using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pages
{
    public class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            Master = new MyMenu();
            Detail = new MyDetail();
        }
    }
}
