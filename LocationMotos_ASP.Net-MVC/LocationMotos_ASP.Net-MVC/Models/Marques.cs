using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocationMotos_ASP.Net_MVC.Models
{
    public class Marques
    {
        public List<Marque> ObtenirListeMoto()
        {
            return new List<Marque>
            {
                new Marque {IDMarque=1, MarqueM="BMW", Model="yz"},
                new Marque {IDMarque=2, MarqueM="Suzuki", Model="gxt125"}
            };
        }
    }
}