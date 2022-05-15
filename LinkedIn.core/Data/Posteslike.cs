using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.core.Data
{
    public partial class Posteslike
    {
        public decimal Likeid { get; set; }
        public decimal? Postid { get; set; }
        public decimal? Userid { get; set; }

        public virtual Userposte Post { get; set; }
        public virtual User User { get; set; }
    }
}
