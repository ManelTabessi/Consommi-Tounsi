using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consommi_Tounsi.Models
{
    public class Administrator
    {
        public int id_admin { get; set; }
        public Boolean actived { get; set; }
        public String email_admin { get; set; }
        public String name_admin { get; set; }
        public String password_admin { get; set; }
        public String username { get; set; }
    }
}