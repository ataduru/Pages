using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Pages
{
    public partial class Page2 : ContentPage
    {
        IMobileServiceTable<User> UserTable = App.MobileService.GetTable<User>();
        List<User> Userlar = new List<User>();
        protected override async void OnAppearing()
        {
            Userlar = await UserTable.ToListAsync();

            base.OnAppearing();
        }

        public Page2()
        {
            InitializeComponent();
            BackgroundColor = Color.FromHex("FAA41A");
            pick.Items.Add("Sınav");
            pick.Items.Add("Final");
            pick.Items.Add("Fem");
            pick.Items.Add("Birey");



        }
        private async void OnClick(object sender, EventArgs e)
        {

            User temp = new User();
            temp.Name = kadi.Text.ToString();
            temp.Password = pass.Text.ToString();
            temp.email = em.Text.ToString();
            temp.userid = Userlar.Count;
            if (pick.SelectedIndex != -1)
                temp.okul = pick.Items[pick.SelectedIndex];
            else
                temp.okul = "";


            await UserTable.InsertAsync(temp);

            //var newPage = new ContentPage();
            await Navigation.PushModalAsync(new Page1());
        }

    }
}
