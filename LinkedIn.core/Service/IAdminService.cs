using LinkedIn.core.Data;
using LinkedIn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.core.Service
{
  public  interface IAdminService
    {
        List<Company> GetAllRgisteredCompany();

        List<User> GetAllRgisteredUsers();
        bool UpdateJob(Postedjob job);
        bool UpdateJob2(Postedjob job);
        bool UpdateWebsite(Website website);

        List<Company> GetAllRgisteredCompanyByDate(DatesSearch dates);
        List<UserApplyJobDTO> GetAllJobAppliedByDate(DatesSearch dates);
        List<UserApplyJobDTO> GetAllJobApplied();
        Total GetNumOfCompanyByDate(DatesSearch dates);
        Total GetNumOfJobAppliedByDate(DatesSearch dates);
        List<ComanyDto> GetNumJobPostByCompany();
        List<ComanyDto> GetNumJobPostByCompanyDate(DatesSearch dates);
        Website getWebsite(int webId);

        bool UpdateAbout(Aboutu aboutu);
        Aboutu getAboutus(int abautId);
        Contactu getContact(int contactId);
        bool UpdateContact(Contactu contactu);

    }
}
