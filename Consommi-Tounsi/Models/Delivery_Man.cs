using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consommi_Tounsi.Models
{
    public class Delivery_Man
    {
        public int id_deliv_man { get; set; }
        public int chargeT_liv { get; set; }
        public String email_deliv_man { get; set; }
        public Boolean etat { get; set; }
        public String name_deliv_man { get; set; }
        public int phone_num_deliv_man { get; set; }
        public Administrator administrator { get; set; }
        public virtual ICollection<Delivery> delivery { get; set; }

    }
}