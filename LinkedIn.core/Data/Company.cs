using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.core.Data
{
    public partial class Company
    {


        public int Compid { get; set; }
        public string Compname { get; set; }
        public string Location { get; set; }
        public string specialties { get; set; }
        public DateTime registereddate { get; set; }
        public string website_url { get; set; }
        public string Phone { get; set; }
        public string Logo { get; set; }
        public string Descreption { get; set; }
        public int Userid { get; set; }
        public decimal? Roleid { get; set; }

        public string email { get; set; }
        public string pass { get; set; }

        public virtual ICollection<Postedjob> Postedjobs { get; set; }
    }
}
