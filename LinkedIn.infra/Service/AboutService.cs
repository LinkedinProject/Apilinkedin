using LinkedIn.core.Data;
using LinkedIn.core.Repository;
using LinkedIn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.infra.Service
{
     public class AboutService: IAboutService
    {
        private readonly IAboutRepository _aboutRepository;

        public AboutService(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }


         public bool CreateAbout(Aboutu aboutu)
        {
            return _aboutRepository.CreateAbout(aboutu);
        }
       public bool UpdateAbout(Aboutu aboutu)
        {
            return _aboutRepository.UpdateAbout(aboutu);
        }
        public bool DeleteAbout(int AboutId)
        {
            return _aboutRepository.DeleteAbout(AboutId);
        }
        public List<Aboutu> GetAllAbout()
        {
            return _aboutRepository.GetAllAbout();
        }
    }
}
