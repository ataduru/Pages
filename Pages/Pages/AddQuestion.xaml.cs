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
    public partial class AddQuestion : ContentPage
    {
        public AddQuestion()
        {
            InitializeComponent();
            BackgroundColor = Color.FromHex("FAA41A");

        }

        //void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        //{

        //    if (PathLabel.Text == "anan") PathLabel.Text = "baban";
        //    else PathLabel.Text = "anan";


        //}

        private async void add(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if(!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available  ", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(
                new StoreCameraMediaOptions
                {
                    SaveToAlbum = true,

                });
            if (file == null)
                return;
            PathLabel.Text = file.AlbumPath;

            MainImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;

            });      
        }


        private async void addgallery(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            MainImage.IsVisible = true;
            
            

            if ( !CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Oops", "Pick photo is not supported", "OK");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();
            
            if (file == null)
                return;

            PathLabel.Text = "Photo path" + file.Path;
           // Userf.Instance().Userlar[0].questionPhotoURL = file.Path;

            MainImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;

            });
        }
        
        private void asd(object sender, EventArgs e)
        {
            PathLabel.Text = "Sorunuz başarıyla yüklendi. ";
            MainImage.IsVisible = false;
            entri.Text = " ";

             

        }






    }
}
