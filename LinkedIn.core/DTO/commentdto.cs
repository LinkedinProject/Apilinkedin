using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.core.DTO
{
  public  class commentdto
    {
        public int com_id { get; set; }
        public int userid { get; set; }
        public string comments { get; set; }
        public DateTime dates { get; set; }
        public int postid { get; set; }
        public string imageuser { get; set; }

        public string fname { get; set; }
        public string lname { get; set; }

    }
}
