using LinkedIn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.core.Repository
{
   public interface IWebsiteRepository
    {
        bool CreateWebsite(Website website);
        bool UpdateWebsite(Website website);
        bool DeleteWebsite(int id);
        List<Website> GetAllWebsite();
    }
}
