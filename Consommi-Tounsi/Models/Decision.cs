using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consommi_Tounsi.Models
{
    public class Decision
    {
        public int id_deci { get; set; }
        public String typedecision { get; set; }
        public int? ReclamationFK { get; set; }
        public virtual Reclamation Reclamation { get; set; }

    }
}