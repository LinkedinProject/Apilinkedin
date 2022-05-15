using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.core.Data
{
    public class UserProjects
    {
        /// PROJECT,USERID,STARTDATE,ENDDATE,PRODESCRIPTION,PROLINK)
        public int Project { get; set; }
        public int UerId { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public string ProTitle { get; set; }

        public string ProDescription  { get; set; }
        //PRODESCRIPTION
        public string PROLINK { get; set; }
    }
}
