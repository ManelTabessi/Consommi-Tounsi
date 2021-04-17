using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consommi_Tounsi.Models
{
    public class comments
    {
        public int idcomment { get; set; }
        public String contents { get; set; }
        public DateTime dateComment { get; set; }
        public publication publication { get; set; }

        public Client Client { get; set; }
        public ISet<Vote> Vote { get; set; }
    }
}
}