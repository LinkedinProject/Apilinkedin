using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.core.DTO
{
    public  class RecommendDTO
    {
        public int Recommendid { get; set; }
        public int Senderid { get; set; }

        public int Reseverid { get; set; }
        public string RecommendLeter { get; set; }
        public string UserName { get; set; }
        public string UserImg { get; set; }
    }
}
