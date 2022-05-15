using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.core.Data
{
 public   class Email
    {


        public string From { get; set; }
        public string to { get; set; }
        public string password { get; set; }
        public string message { get; set; }
        public string subject { get; set; }
        public string user { get; set; }

        public string company { get; set; }

    }
}
