using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocationMotos_ASP.Net_MVC.Models
{
    public class Moto
    {
        [Required]
        [Display(Name = "ID Moto")]
        public int IDMoto { get; set; }
        [Required]
        [MaxLength(20)]
        public string Carburant { get; set; }
        [Required]
        [MaxLength(10)]
        public string Kilometrage { get; set; }
        [Required]
        [MaxLength(10)]
        public string Disponible { get; set; }


        //Chaque moto a une seul marque
        [Required]
        [Display(Name = "ID Marque")]
        public int IDMarque { get; set; }
        public Marque Marque { get; set; }

        //Chaque moto a plusieurs locations
        public virtual ICollection<Location> Locations { get; set; }


    }
}