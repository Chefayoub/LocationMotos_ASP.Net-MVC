using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocationMotos_ASP.Net_MVC.Models
{
    public class Client
    {
        [Required]
        [Display(Name = "ID Client")]
        public int IDClient { get; set; }
        [Required]
        [MaxLength(150)]
        public string Nom { get; set; }
        [Required]
        [MaxLength(150)]
        public string Prenom { get; set; }
        [Required]
        [MaxLength(200)]
        public string Adresse { get; set; }
        [Required]
        [Display(Name = "Numéro de téléphone")]
        [MaxLength(15)]
        public string NumeroTel { get; set; }

        //Caque client a plusieurs locations
        public virtual ICollection<Location> Locations { get; set; }
    }
}