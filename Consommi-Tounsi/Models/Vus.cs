using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consommi_Tounsi.Models
{
    public class Vus
    {
       public int id { get; set; }
        public int nbVus { get; set; }
        public DateTime dateAjout { get; set; }
        public publication publication { get; set; }
        public Client Client { get; set; }
    }

}