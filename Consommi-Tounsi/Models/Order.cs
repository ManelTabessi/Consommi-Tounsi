using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consommi_Tounsi.Models
{
    public class Order
    {
        public int id_ord { get; set; }
        public DateTime date_order { get; set; }
        public virtual ICollection<Delivery> delivery { get; set; }

    }
}