using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pages
{
    class MasterQuestionPage : MasterDetailPage
    {
        public MasterQuestionPage(bool x, int k)
        {
            Master = new MyMenu();
            Detail = new silinecek(x,k);
        }
    }
}
