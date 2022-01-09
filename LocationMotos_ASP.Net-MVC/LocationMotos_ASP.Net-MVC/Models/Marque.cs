using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocationMotos_ASP.Net_MVC.Models
{
    public class Marque
    {
        public int IDMarque { get; set; }
        [Display(Name = "Marque Moto")]
        public string MarqueM { get; set; }
        public string Model { get; set; }

        //Une marque a concerne plusieurs motos
        public virtual ICollection<Moto> Motos { get; set; }


    }
}