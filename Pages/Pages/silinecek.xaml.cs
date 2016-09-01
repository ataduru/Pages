using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Pages
{
    public partial class silinecek : ContentPage
    {
        IMobileServiceTable<User> UserTable = App.MobileService.GetTable<User>();
        List<User> Userlar = new List<User>();
        IMobileServiceTable<Soru> SoruTable = App.MobileService.GetTable<Soru>();
        List<Soru> Sorular = new List<Soru>();
        IMobileServiceTable<Cevap> CevapTable = App.MobileService.GetTable<Cevap>();
        List<Cevap> Cevaplar = new List<Cevap>();
        protected override async void OnAppearing()
        {
            Userlar = await UserTable.ToListAsync();
            Sorular = await SoruTable.ToListAsync();
            Cevaplar = await CevapTable.ToListAsync();
            base.OnAppearing();
        }
        public silinecek(bool sorumu, int k)
        {
            InitializeComponent();
            BackgroundColor = Color.FromHex("FAA41A");
            sorumu1 = sorumu;
            soruid = k;
            if (sorumu == false)
            {
                entri.Placeholder = "Cevabını text halinde buraya girebilirsin...";
            }

        }
        string pet;
        bool sorumu1;
        int soruid;
        private async void imgFotoEkle_Clicked(object sender, EventArgs e)
        {
            //ComboBox foto = new ComboBox();
            //foto.Items.Add((object)btnFotoEkle);
            //foto.Items.Add((object)btnFotoDegistir);

            btnFotoEkle_Clicked();

            lblpath.IsVisible = true;
        }

        private async void imgFotoEkle_Clicked2(object sender, EventArgs e)
        {
            //ComboBox foto = new ComboBox();
            //foto.Items.Add((object)btnFotoEkle);
            //foto.Items.Add((object)btnFotoDegistir);

            btnGaleridenekle_Clicked();
            lblpath.IsVisible = true;
        }

        

        private async void btnFotoEkle_Clicked()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No Camera Available", "OK");
                return;
            }
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                SaveToAlbum = true,
                Directory = "Sample",
                Name = "result.png"
            });
            pet = file.Path;
            if (file == null)
                return;
            MainImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });

        
        }
        private async void btnGaleridenekle_Clicked()
        {

            await CrossMedia.Current.Initialize();
            imgFotoEkle.IsVisible = true;
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Opps", "Seçtiğin foto desteklenmiyor !", "OK");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync();
            pet = file.Path;

            if (file == null)
                return;


            MainImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });


        }


        protected override bool OnBackButtonPressed()
        {
            Navigation.PushModalAsync(new QuestionPage());

            return true;
        }

       /* string Upload(System.IO.Stream stream)
        {
            CloudStorageAccount account = new CloudStorageAccount(new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials("bisoru", "i/20lNkE0b7bFpe1RCbwRH5ycJ9LUSJ49UMVok2Pc19WqgPtYGE81fgpYoCUVLkpLDMISu0e42cd7i/Rx2KO7w=="), true);

            CloudBlobClient blobClient = account.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("fotograflar");

            container.CreateIfNotExists();
            container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(Guid.NewGuid().ToString() + ".png");
            blockBlob.UploadFromStream(stream);
            return blockBlob.Uri.ToString();
        }*/

        private async void yukle(object sender, EventArgs e)
        {

            if (sorumu1 == true)
            {
                //Userlar[Userf.whichUser].SorduguPhotoURL = pet;
                Soru temp = new Soru();
                temp.textorurl = pet;
                temp.ekleyenid = Userf.whichUser;
                temp.ekleyen = Userlar[Userf.whichUser].Name;
                temp.isAnswered = false;
                temp.koyulmatarihi = DateTime.Now;
                if (entri.Text != "")
                {
                    temp.isPhoto = false;
                    temp.text = entri.Text;
                }
                
                int k = Sorular.Count;
                temp.soruid = k + 1;

                temp.IsShow = false;
                temp.icon = "qmm.png";
                await SoruTable.InsertAsync(temp);


                await DisplayAlert("Sorunuz yüklendi", " ", "Tamam");

                await Navigation.PushModalAsync(new QuestionPage());


            }


            if (sorumu1 == false)
            {
                //Userlar[whichUser].cevapladigiSoruPhotoURL = pet;
                Cevap temp = new Cevap();
                temp.textorurl = pet;
                temp.ekleyenid = Userf.whichUser;
                temp.ekleyen = Userlar[Userf.whichUser].Name;
                temp.koyulmatarihi = DateTime.Now;
                if (entri.Text != null)
                {
                    temp.isPhoto = false;
                    temp.text = entri.Text;
                }

                int k = Sorular.Count;
                temp.cevapid = k + 1;
                temp.sorunid = soruid;
                await CevapTable.InsertAsync(temp);

                int s = Sorular.Count;
                for (int i = 0; i < s; i++)
                {
                    if (Sorular[i].soruid == soruid)
                    {
                        Sorular[i].isAnswered = true;
                        Sorular[i].icon = "tick.png";
                        await SoruTable.UpdateAsync(Sorular[i]);
                        break;
                    }
                }

                await DisplayAlert("Cevabınız yüklendi", " ", "Tamam");

                await Navigation.PushModalAsync(new QuestionPage());

            }


        }
    }
}