using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocationMotos_ASP.Net_MVC.Models
{
    public class Client
    {
        public int IDClient { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string NumeroTel { get; set; }

        //Caque client a plusieurs locations
        public virtual ICollection<Location> Locations { get; set; }
    }
}