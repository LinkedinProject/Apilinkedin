using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.core.Data
{
    public partial class Userposte
    {


        public decimal Postid { get; set; }
        public string Posttext { get; set; }
        public string Image { get; set; }
        public decimal? Userid { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Postescomment> Postescomments { get; set; }
        public virtual ICollection<Posteslike> Posteslikes { get; set; }
    }
}
