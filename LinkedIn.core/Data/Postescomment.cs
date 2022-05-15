using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.core.Data
{
    public partial class Postescomment
    {
        public decimal Comentid { get; set; }
        public string Commenttext { get; set; }
        public decimal? Postid { get; set; }
        public decimal? Userid { get; set; }

        public virtual Userposte Post { get; set; }
        public virtual User User { get; set; }
    }
}
