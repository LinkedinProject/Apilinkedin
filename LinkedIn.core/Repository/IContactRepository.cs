using LinkedIn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.core.Repository
{
   public interface IContactRepository
    {
        bool CreateContact(Contactu contactu);
        bool UpdateContact(Contactu contactu);
        bool DeleteContact(int contactid);
        List<Contactu> GetAllContact();
    }
}
