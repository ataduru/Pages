using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Pages
{
    public partial class MyDetail : ContentPage
    {
       // IMobileServiceTable<User> UserTable = App.MobileService.GetTable<User>();

        public MyDetail()
        {
            InitializeComponent();
            sl.BackgroundColor = Color.FromHex("FAA41A");
            
        }

        //protected override async void OnAppearing()
        //{
        //    //lstView.ItemsSource = await UserTable.ToListAsync();
        //    base.OnAppearing();
        //}

        private void onc(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new QuestionPage());
        }
        protected override bool OnBackButtonPressed()
        {
           // Navigation.PushModalAsync(new Page1());

            return true;
        }

    }
}
