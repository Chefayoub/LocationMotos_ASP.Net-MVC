using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocationMotos_ASP.Net_MVC.Models
{
    public class Location
    {
        public int IDLocation { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string NumeroTel { get; set; }

        //Pour chaque location il y a un client
        public int IDClient { get; set; }
        public Client Client { get; set; }

        //Chaque location concerne une moto
        public int IDMoto { get; set; }
        public Moto Moto { get; set; }
    }
}