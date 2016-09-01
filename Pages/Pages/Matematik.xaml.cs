using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Pages
{
    public partial class Matematik : ContentPage
    {
        public Matematik()
        {
            InitializeComponent();
            BackgroundColor = Color.FromHex("FAA41A");
            

        }

        private void ekle(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MasterQuestionPage(true,2));
        }

        private void cevapla(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MasterAnswerPage());
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PushModalAsync(new MainPage());

            return true;
        }
    }
}
