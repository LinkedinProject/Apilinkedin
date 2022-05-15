using LinkedIn.core.Data;
using LinkedIn.core.DTO;
using LinkedIn.core.Repository;
using LinkedIn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.infra.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public Aboutu getAboutus(int abautId)
        {
            return _adminRepository.getAboutus(abautId);
        }

        public List<UserApplyJobDTO> GetAllJobAppliedByDate(DatesSearch dates)
        {
            return _adminRepository.GetAllJobAppliedByDate(dates);
        }

        public List<UserApplyJobDTO> GetAllJobApplied()
        {
            return _adminRepository.GetAllJobApplied();
        }

        public List<Company> GetAllRgisteredCompany()
        {
            return _adminRepository.GetAllRgisteredCompany();
        }

        public List<Company> GetAllRgisteredCompanyByDate(DatesSearch dates)
        {
            return _adminRepository.GetAllRgisteredCompanyByDate(dates);
        }

        public List<User> GetAllRgisteredUsers()
        {
            return _adminRepository.GetAllRgisteredUsers();
        }

        public Contactu getContact(int contactId)
        {
            return _adminRepository.getContact(contactId);
        }

        public List<ComanyDto> GetNumJobPostByCompany()
        {
            return _adminRepository.GetNumJobPostByCompany();
        }

        public List<ComanyDto> GetNumJobPostByCompanyDate(DatesSearch dates)
        {
            return _adminRepository.GetNumJobPostByCompanyDate(dates);
        }
      
        public Total GetNumOfCompanyByDate(DatesSearch dates)
        {
            return _adminRepository.GetNumOfCompanyByDate(dates);
        }

        public Total GetNumOfJobAppliedByDate(DatesSearch dates)
        {
            return _adminRepository.GetNumOfJobAppliedByDate(dates);
        }

        public Website getWebsite(int webId)
        {
            return _adminRepository.getWebsite( webId);

        }

        public bool UpdateAbout(Aboutu UpdateAbout)
        {
            return _adminRepository.UpdateAbout(UpdateAbout);

        }

        public bool UpdateContact(Contactu contactu)
        {
            return _adminRepository.UpdateContact(contactu);
        }

        public  bool UpdateJob(Postedjob job)
        {
            return _adminRepository.UpdateJob(job);

        }

        public bool UpdateJob2(Postedjob job)
        {
            return _adminRepository.UpdateJob2(job);
        }

        public bool UpdateWebsite(Website website)
        {
            return _adminRepository.UpdateWebsite(website);
        }
    }
}
