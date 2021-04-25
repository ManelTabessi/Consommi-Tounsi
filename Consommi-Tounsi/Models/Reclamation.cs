using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consommi_Tounsi.Models
{
    public class Reclamation
    {
        public int id_recl { get; set; }
        public String objet { get; set; }
        public String content { get; set; }
        public int? ClientFk { get; set; }
        public Client Client { get; set; }
        public virtual Decision decision { get; set; }
    }
}