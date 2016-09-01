using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Pages
{
    public partial class Sorularım : ContentPage
    {
        IMobileServiceTable<Soru> SoruTable = App.MobileService.GetTable<Soru>();
        List<Soru> Sorular = new List<Soru>();
        IMobileServiceTable<Cevap> CevapTable = App.MobileService.GetTable<Cevap>();
        List<Cevap> Cevaplar = new List<Cevap>();
        IMobileServiceTable<User> UserTable = App.MobileService.GetTable<User>();
        List<User> Userlar = new List<User>();
        protected override async void OnAppearing()
        {
            Sorular = await SoruTable.ToListAsync();
            Userlar = await UserTable.ToListAsync();
            Cevaplar = await CevapTable.ToListAsync();

            List<Soru> myquestions = new List<Soru>();
            for(int i=0;i<Sorular.Count;i++)
            {
                if (Sorular[i].ekleyenid == Userf.whichUser)
                    myquestions.Add(Sorular[i]);
            }

            lstStudents.ItemsSource = myquestions;
            


            base.OnAppearing();
        }
        public Sorularım()
        {
            InitializeComponent();
            sl.BackgroundColor = Color.FromHex("FAA41A");
            rate.Items.Add("0");
            rate.Items.Add("1");
            rate.Items.Add("2");
            rate.Items.Add("3");
            rate.Items.Add("4");
            rate.Items.Add("5");



        }

        int sorui;
        Soru selectedStudent;
        private void onSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;


            selectedStudent = (Soru)e.SelectedItem;
            sorui = selectedStudent.soruid;

            if (selectedStudent.isAnswered == true) { okbut.Text = "Cevabı göster"; okbut.IsVisible = true; }
            if (selectedStudent.isAnswered == false) { okbut.IsVisible = false; cevaplanmadi.IsVisible = true; }

            if (selectedStudent.text != null)
            {
                lab11.Text = selectedStudent.text;
                lstStudents.IsVisible = false;
                grid.IsVisible = true;
                lab11.IsVisible = true;
                okbut1.IsVisible = true;
            }


            but.Source = selectedStudent.textorurl;
            lstStudents.IsVisible = false;
            but.IsVisible = true;
            grid.IsVisible = true;
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



        private async void onc1(object sender, EventArgs e)
        {
            cevaplanmadi.IsVisible = false;
            lstStudents.IsVisible = true;
            lab11.IsVisible = false;
            okbut.IsVisible = false;
            okbut1.IsVisible = false;
            grid.IsVisible = false;
            but.IsVisible = false;
            but2.IsVisible = false;
            lab22.IsVisible = false;
            cevapyazisi.IsVisible = false;

            if (rate.SelectedIndex != -1)
            {
                for (int i = 0; i < Cevaplar.Count; i++)
                {
                    if (Cevaplar[i].sorunid == sorui)
                    {
                        Cevaplar[i].puan = Convert.ToInt32(rate.Items[rate.SelectedIndex]);
                        Cevaplar[i].puanlandimi = true;
                        await CevapTable.UpdateAsync(Cevaplar[i]);
                        for(int j=0; j<Userlar.Count;j++)
                        {
                            if(Userlar[j].userid==Cevaplar[i].ekleyenid)
                            {
                                Userlar[j].puan += Cevaplar[i].puan;
                                await UserTable.UpdateAsync(Userlar[j]);
                                break;
                            }
                            
                        }
                        rate.IsVisible = false;
                    }

                }
            }
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
                        if (Cevaplar[i].puanlandimi == false) { rate.IsVisible = true; }
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


