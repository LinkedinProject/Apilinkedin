using LinkedIn.core.Data;
using LinkedIn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.core.Repository
{
  public  interface IAdminRepository
    {
        List<Company> GetAllRgisteredCompany();
        List<User> GetAllRgisteredUsers();
        bool UpdateJob(Postedjob job);
        bool UpdateJob2(Postedjob job);
        List<Company> GetAllRgisteredCompanyByDate(DatesSearch dates);
        Total GetNumOfCompanyByDate(DatesSearch dates);
        Total GetNumOfJobAppliedByDate(DatesSearch dates);
        List<UserApplyJobDTO> GetAllJobAppliedByDate(DatesSearch dates);
        List<UserApplyJobDTO> GetAllJobApplied ();
        List<ComanyDto> GetNumJobPostByCompany( );
        List<ComanyDto> GetNumJobPostByCompanyDate(DatesSearch dates);
        bool UpdateWebsite(Website website);
        Website getWebsite(int webId);
        bool UpdateContact(Contactu contactu);
        Aboutu getAboutus(int abautId);
        Contactu getContact(int contactId);

        bool UpdateAbout(Aboutu aboutu);
     

    }
}
