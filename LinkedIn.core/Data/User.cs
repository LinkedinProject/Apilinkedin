using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.core.Data
{
    public partial class User
    {


        public decimal Userid { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public char Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string Imageuser { get; set; }
        public string Address { get; set; }
        public int Roleid { get; set; }
        public  string  pass { get; set; }
        public string edu_level { get; set; }
      
    }
}
