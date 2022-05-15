using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.core.Data
{
    public partial class Postedjob
    {
        public decimal Postid { get; set; }
        public string Job_Title { get; set; }
        public string description { get; set; }
        public string edu_Level { get; set; }
        public DateTime? post_Date { get; set; }
        public DateTime? end_Date { get; set; }
        public decimal? salary { get; set; }
        public string location { get; set; }
        public decimal? compid { get; set; }
        public decimal? catid { get; set; }

        public int job_ype { get; set; }
        public int onsite_remote { get; set; }



    }
}
