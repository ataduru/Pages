using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages
{
    public class Userf
    {
        public static Userf Instance()
        {
            return new Userf();
        }

        /*public IMobileServiceTable<User> UserTable = App.MobileService.GetTable<User>();
        public IMobileServiceTable<Soru> SoruTable = App.MobileService.GetTable<Soru>();
        public IMobileServiceTable<Cevap> CevapTable = App.MobileService.GetTable<Cevap>();

        public ObservableCollection<User> Userlar { get; set; }

        public ObservableCollection<Soru> Sorular { get; set; }
        public ObservableCollection<Cevap> Cevaplar { get; set; }
        */
        public static int whichUser { get; set; }

        public Userf()
        {
            /*Userlar = new ObservableCollection<User>
            {
                new User
                {
                    Name = "Ata",
                    Password = "1234",
                    email = "email"
                    
                } ,
                new User
                {
                    Name = "Arda",
                    Password = "12345",
                    email = "email1",
                    sorduguPhotoURL="camera.png"

                }

            };
            Sorular = new ObservableCollection<Soru>();
            Cevaplar = new ObservableCollection<Cevap>();*/
        }
        
    }
}
