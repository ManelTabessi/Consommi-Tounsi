using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consommi_Tounsi.Models
{
    public class Rating
    {
        public int id { get; set; }
        public int? ClientFk { get; set; }
        public Client Client { get; set; }
        public int? publicationFk { get; set; }
        public publication publication { get; set; }
        public int rating { get; set; }
    }
}