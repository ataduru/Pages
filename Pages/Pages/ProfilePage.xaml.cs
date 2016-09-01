using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Pages
{
    public partial class ProfilePage : ContentPage
    {
        IMobileServiceTable<User> UserTable = App.MobileService.GetTable<User>();
        List<User> Userlar = new List<User>();

        public ProfilePage()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            Userlar = await UserTable.ToListAsync();
            isim.Text = Userlar[Userf.whichUser].Name;
            base.OnAppearing();
        }
    }
}
