using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pages
{
    class QuestionPage : MasterDetailPage
    {
        public QuestionPage()
        {
            Master = new MyMenu();
            Detail = new Matematik();
        }
    }
}
