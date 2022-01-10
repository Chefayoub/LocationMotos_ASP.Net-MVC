using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocationMotos_ASP.Net_MVC.Models
{
    public class Marque
    {
        [Required]
        [Display(Name = "ID Marque")]
        public int IDMarque { get; set; }
        [Required]
        [Display(Name = "Marque Moto")]
        [MaxLength(100)]
        public string MarqueM { get; set; }
        [Required]
        [MaxLength(100)]
        public string Model { get; set; }

        //Une marque a concerne plusieurs motos
        public virtual ICollection<Moto> Motos { get; set; }
    }
}