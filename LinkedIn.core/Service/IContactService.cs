using LinkedIn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.core.Service
{
   public interface IContactService
    {
        bool CreateContact(Contactu contactu);
        bool UpdateContact(Contactu contactu);
        bool DeleteContact(int contactid);
        List<Contactu> GetAllContact();
    }
}
