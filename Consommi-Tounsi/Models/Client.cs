using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consommi_Tounsi.Models
{
    public class Client
    {
       public int id_client { get; set; }
        public String name_client { get; set; }
        public int phone_num_client { get; set; }
        public String email_client { get; set; }
        public String password_client { get; set; }
        public Boolean actived { get; set; }
        public String city_client { get; set; }
        public String adress_client { get; set; }
        public int postal_code_client { get; set; }
        public String username { get; set; }

        public virtual ICollection<publication> publication { get; set; }
        public virtual ICollection<comments> comments { get; set; }
        public virtual ICollection<Vote> Vote { get; set; }
        public virtual ICollection<Vus> Vus { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }

        public virtual ICollection<Reclamation> reclamation { get; set; }
    }
}