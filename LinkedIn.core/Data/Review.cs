using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.core.Data
{
    public partial class Review
    {
        public decimal Reviewid { get; set; }
        public string Stutes { get; set; }
        public string Logo { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Websiteid { get; set; }

        public virtual User User { get; set; }
        public virtual Website Website { get; set; }
    }
}
