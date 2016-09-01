using Pages.MasterPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Pages
{
    public partial class MyMenu : ContentPage
    {
        public MyMenu()
        {
            InitializeComponent();
            Title = "Bi' Soru";
            Icon = "whitemenu2.png";
            
            List<string> optionList = new List<string>()
{
    "Profilim","Sorularım","Sıralama","Ayarlar","Çıkış"
};


            lstStudents.ItemsSource = optionList;
        }

        private void onSelected(object sender, SelectedItemChangedEventArgs e)
        {
            string selectedStudent = (string)e.SelectedItem;
            if ((string)e.SelectedItem == "Profilim")
            {
                Navigation.PushModalAsync(new ProfileMasterPage());

                ListView lst = (ListView)sender;
                lst.SelectedItem = null;
            }

            if ((string)e.SelectedItem == "Sorularım")
            {
                Navigation.PushModalAsync(new SorularımMasterPage());

                ListView lst = (ListView)sender;
                lst.SelectedItem = null;
            }

            if ((string)e.SelectedItem == "Sıralama")
            {
                Navigation.PushModalAsync(new SıralamaMasterPage());

                ListView lst = (ListView)sender;
                lst.SelectedItem = null;
            }

            if ((string)e.SelectedItem == "Çıkış")
            {
                Navigation.PushModalAsync(new Page1());

                ListView lst = (ListView)sender;
                lst.SelectedItem = null;
            }

            else
                return;

        }
    }
}
