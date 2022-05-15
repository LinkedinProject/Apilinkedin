using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.core.DTO
{
   public class JobApplicants
    {
        public int Application_Id { get; set; }
         public string Fname { get; set; }
        public string Job_title { get; set; }
        public string Company { get; set; }

        public DateTime Applay_date { get; set; }
      }
}
