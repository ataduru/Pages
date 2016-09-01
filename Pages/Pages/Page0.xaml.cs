using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Pages
{
    public partial class Page0 : ContentPage
    {
        public Page0()
        {
            InitializeComponent();
            stek.BackgroundColor = Color.White; //FromHex("FFFBD0");
            bisoru.TextColor = Color.FromHex("FF9900");

        }
        

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(3000);
            await this.Navigation.PushModalAsync(new Page1());
        }
    }
}
