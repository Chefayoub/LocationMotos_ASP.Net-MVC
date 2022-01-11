using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocationMotos_ASP.Net_MVC.Models
{
    public class Location
    {
        [Required]
        [Display(Name = "ID location")]
        public int IDLocation { get; set; }
        [Required]
        [Display(Name = "Frais")]
        [MaxLength(10)]
        public string FraisDeLocation { get; set; }
        [Required]
        [Display(Name = "Date début")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date_debut { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date fin")]
        public DateTime Date_fin { get; set; }


        //Pour chaque location il y a un client
        [Required]
        [Display(Name = "ID Client")]
        public int IDClient { get; set; }
        public Client Client { get; set; }

        //Chaque location concerne une moto
        [Required]
        [Display(Name = "ID Moto")]
        public int IDMoto { get; set; }
        public Moto Moto { get; set; }
    }
}