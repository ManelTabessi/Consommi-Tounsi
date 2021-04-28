using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consommi_Tounsi.Models
{
    public class Factures
    {
        public int id { get; set; }
        public DateTime date_de_depart { get; set; }
        public Commandes Commandes { get; set; }


    }
}