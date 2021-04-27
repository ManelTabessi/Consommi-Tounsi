using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consommi_Tounsi.Models
{
   
    public class Vote
    {
        public int id { get; set; }
        public int liked { get; set; }
        public int dislike { get; set; }
        public Client Client { get; set; }
        public publication publication { get; set; }
        public comments comments { get; set; }
    }
}