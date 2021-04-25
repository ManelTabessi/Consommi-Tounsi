using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consommi_Tounsi.Models
{
    public class Delivery
    {
        public int id_deliv { get; set; }
        public DateTime date_debut { get; set; }
        public DateTime date_fin { get; set; }
        public float fresh { get; set; }
        public String location { get; set; }
        public String moyenT { get; set; }
        public float weight { get; set; }
        public Administrator administrator { get; set; }
        public int? Delivery_ManFK { get; set; }
        public Delivery_Man Delivery_Man { get; set; }
        public int? OrderFK { get; set; }
        public Order order { get; set; }
    }
}