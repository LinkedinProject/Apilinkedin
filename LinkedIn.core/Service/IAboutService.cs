using LinkedIn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.core.Service
{
  public  interface IAboutService
    {
        bool CreateAbout(Aboutu aboutu);
        bool UpdateAbout(Aboutu aboutu);
        bool DeleteAbout(int AboutId);
        List<Aboutu> GetAllAbout();
    }
}
