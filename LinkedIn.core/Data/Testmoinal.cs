using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.core.Data
{
    public partial class Testmoinal
    {
        public decimal TestId { get; set; }
        public string Subject { get; set; }
        public decimal? Websiteid { get; set; }

        public virtual Website Website { get; set; }
    }
}
