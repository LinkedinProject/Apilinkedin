using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.core.Data
{
    public partial class Experience
    {
        public decimal Experienceid { get; set; }
        public string Jobtitle { get; set; }
        public string Companyname { get; set; }
        public string describtion { get; set; }
        public DateTime? Datefrom { get; set; }
        public DateTime? Dateto { get; set; }
        public decimal? Userid { get; set; }

  
    }
}
