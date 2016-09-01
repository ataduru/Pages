using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Pages
{
    public partial class CevapSayfa : ContentPage
    {
        IMobileServiceTable<Soru> SoruTable = App.MobileService.GetTable<Soru>();
        List<Soru> Sorular = new List<Soru>();
        IMobileServiceTable<Cevap> CevapTable = App.MobileService.GetTable<Cevap>();
        List<Cevap> Cevaplar = new List<Cevap>();
        protected override async void OnAppearing()
        {
            Sorular = await SoruTable.ToListAsync();
            //Userlar = await UserTable.ToListAsync();
            Cevaplar = await CevapTable.ToListAsync();
            lstStudents.ItemsSource = Sorular;
            
            base.OnAppearing();
        }
        public CevapSayfa()
        {
            InitializeComponent();
            sl.BackgroundColor = Color.FromHex("FAA41A");




        }

        int sorui;
        Soru selectedStudent;
        private void onSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;


            selectedStudent = (Soru)e.SelectedItem;
            sorui = selectedStudent.soruid;

            if (selectedStudent.isAnswered == true) { okbut.Text = "Cevabı göster"; }
            if (selectedStudent.isAnswered == false) { okbut.Text = "Cevapla"; }

            if (selectedStudent.text != null)
            {
                lab11.Text = selectedStudent.text;
                lstStudents.IsVisible = false;
                grid.IsVisible = true;
                lab11.IsVisible = true;
                okbut.IsVisible = true;
                okbut1.IsVisible = true;
            }


            but.Source = selectedStudent.textorurl;
            lstStudents.IsVisible = false;
            but.IsVisible = true;
            grid.IsVisible = true;

            okbut.IsVisible = true;
            okbut1.IsVisible = true;

            ListView lst = (ListView)sender;
            lst.SelectedItem = null;
        }

        private void onc(object sender, EventArgs e)
        {

            lstStudents.IsVisible = true;
            but.IsVisible = false;
            lab11.IsVisible = false;
            okbut.IsVisible = false;
            okbut1.IsVisible = false;
            grid.IsVisible = false;
            but.IsVisible = false;
            but2.IsVisible = false;
            lab22.IsVisible = false;
            cevapyazisi.IsVisible = false;
        }



        private void onc1(object sender, EventArgs e)
        {

            lstStudents.IsVisible = true;
            lab11.IsVisible = false;
            okbut.IsVisible = false;
            okbut1.IsVisible = false;
            grid.IsVisible = false;
            but.IsVisible = false;
            but2.IsVisible = false;
            lab22.IsVisible = false;
            cevapyazisi.IsVisible = false;
        }


        private void oncevap(object sender, EventArgs e)
        {

        }
        private void onc2(object sender, EventArgs e)
        {



            if (selectedStudent.isAnswered == false)
            {
                lstStudents.IsVisible = true;
                lab11.IsVisible = false;
                okbut.IsVisible = false;
                okbut1.IsVisible = false;
                grid.IsVisible = false;
                but.IsVisible = false;
                Navigation.PushModalAsync(new MasterQuestionPage(false, sorui));
            }

            else
            {

                int s = Cevaplar.Count;
                for (int i = 0; i < s; i++)
                {
                    if (Cevaplar[i].sorunid == sorui)
                    {
                        if (Cevaplar[i].text != null)
                        {
                            cevapyazisi.IsVisible = true;
                            lab22.Text = Cevaplar[i].text;
                            lab22.IsVisible = true;
                        }
                        if (Cevaplar[i].text == null && Cevaplar[i].textorurl != null)
                        {
                            cevapyazisi.IsVisible = true;
                            but2.Source = Cevaplar[i].textorurl;
                            but2.IsVisible = true;
                        }
                    }

                }


            }


        }



    }
}
