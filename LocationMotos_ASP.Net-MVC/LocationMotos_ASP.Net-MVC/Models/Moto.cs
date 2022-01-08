using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocationMotos_ASP.Net_MVC.Models
{
    public class Moto
    {
        public int IDMoto { get; set; }
        public string Carburant { get; set; }
        public string Kilometrage { get; set; }
        public string Disponible { get; set; }


        //Chaque moto a une seul marque
        public int IDMarque { get; set; }
        public Marque Marque { get; set; }

        //Chaque moto a plusieurs locations
        public virtual ICollection<Location> Locations { get; set; }
    }
}