using LinkedIn.core.Data;
using LinkedIn.core.Repository;
using LinkedIn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.infra.Service
{
    public class WebsiteService : IWebsiteService
    {
        private readonly IWebsiteRepository _websiteRepository;

        public WebsiteService(IWebsiteRepository websiteRepository)
        {
            _websiteRepository = websiteRepository;
        }
        public bool CreateWebsite(Website website)
        {
            return _websiteRepository.CreateWebsite(website);
        }

        public bool DeleteWebsite(int id)
        {
            return _websiteRepository.DeleteWebsite(id);
        }

        public List<Website> GetAllWebsite()
        {
            return _websiteRepository.GetAllWebsite();
        }

        public bool UpdateWebsite(Website website)
        {
            return _websiteRepository.UpdateWebsite(website);
        }
    }
}
