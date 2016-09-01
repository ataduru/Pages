using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Pages
{
    public partial class SıralamaPage : ContentPage
    {
        IMobileServiceTable<User> UserTable = App.MobileService.GetTable<User>();
        List<User> Userlar = new List<User>();

        protected override async void OnAppearing()
        {
            Userlar = await UserTable.ToListAsync();
            List<User> SortedList = Userlar.OrderByDescending(o => o.puan).ToList();
            lstStudents.ItemsSource = SortedList;

            base.OnAppearing();
        }
        public SıralamaPage()
        {

            InitializeComponent();
            sl.BackgroundColor = Color.FromHex("FAA41A");
           

        }
    }
}
