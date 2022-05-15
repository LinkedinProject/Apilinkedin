using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.core.DTO
{
  public  class CompanyApplyDTO
    {
        public int Application_Id { get; set; }
        public string fname { get; set; }
        public string Email { get; set; }
        public DateTime Applay_date { get; set; }
        public string Stutus { get; set; }
        public string Company { get; set; }
        public string uploadcv { get; set; }

        public int User_Id { get; set; }


        public string imageuser { get; set; }
    }
}
