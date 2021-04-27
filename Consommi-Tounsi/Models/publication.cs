using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consommi_Tounsi.Models
{
    public class publication
    {
        public int idpub { get; set; }
        public String subject { get; set; }
        public String contents { get; set; }
        public DateTime date_discussion { get; set; }

        public float rating { get; set; }
        public String etat { get; set; }



        //public int? ClientFk { get; set; }
        public Client Client { get; set; }
    }
}