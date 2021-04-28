using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consommi_Tounsi.Models
{
    public class Commandes
    {
        public int id { get; set; }
        public DateTime date_commande { get; set; }
        public double prixtotale { get; set; }
        public Payment_TYPE paymentType { get; set; }
        public Product Product { get; set; }

        public Client Client { get; set; }

        //public Enume id { get; set; }
        //public int id { get; set; }


    }
}