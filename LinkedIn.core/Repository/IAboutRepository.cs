using LinkedIn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.core.Repository
{
   public interface IAboutRepository
    {
        bool CreateAbout(Aboutu aboutu);
        bool UpdateAbout(Aboutu aboutu);
        bool DeleteAbout(int id);
        List<Aboutu> GetAllAbout();

    }
}
