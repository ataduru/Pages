using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pages
{

    public class User
    {
        public string Id { get; set; }
        public int userid { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string email { get; set; }
        public string okul { get; set; }
        public string SorduguPhotoURL { get; set; }
        public string CevapladigiSoruPhotoURL { get; set; }

        public int puan { get; set; }



    }

}
