using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Pages
{
    public partial class Page1 : ContentPage
    {
        IMobileServiceTable<User> UserTable = App.MobileService.GetTable<User>();
        List<User> Userlar = new List<User>();

        public Page1()
        {

            InitializeComponent();
            layout.BackgroundColor = Color.FromHex("FAA41A");


        }

        protected override async void OnAppearing()
        {
            Userlar = await UserTable.ToListAsync();
            base.OnAppearing();
        }

        private void OnClick(object sender, EventArgs e)
        {
            string kadi = kullaniciadi.Text;
            string pass = sifre.Text;
            bool enter = false;

            if (kullaniciadi.Text == null || sifre.Text == null)
            {
                l.IsVisible = true;
            }

            else
            {
                for (int i = 0; i < Userlar.Count(); i++)
                {
                    if (kadi == Userlar[i].Name && pass == Userlar[i].Password)
                    {
                        enter = true;
                        Userf.whichUser = Userlar[i].userid;
                        break;
                    }
                }

                if (enter == true)
                {
                    Navigation.PushModalAsync(new MainPage());

                }
                else l.IsVisible = true;


            }
        }
        private void OnClick1(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Page2());
        }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }



    }
}
