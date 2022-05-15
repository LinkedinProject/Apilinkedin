using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.core.Data
{
    public partial class Jopapply
    {
        public int Application_Id { get; set; }
        public string Uploadcv { get; set; }
        public string Uploadecrtificate { get; set; }
        public string Stutus { get; set; }
        public DateTime? Applay_Date { get; set; }
        public DateTime? Response_Date { get; set; }
        public decimal? Jobid { get; set; }
        public decimal? Userid { get; set; }

        public string applicantname { get; set; }
        public string applicantemail { get; set; }
        public string coverletter { get; set; }


    }
}
