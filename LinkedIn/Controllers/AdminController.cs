
using LinkedIn.core.Data;
using LinkedIn.core.DTO;
using LinkedIn.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }



        [HttpGet]
        [Route("GetAllRgisteredCompany")]
        [ProducesResponseType(typeof(List<Company>), StatusCodes.Status200OK)]
        public List<Company> GetAllRgisteredCompany()
        {
            return _adminService.GetAllRgisteredCompany();
        }



        [HttpGet]
        [Route("getWebsite/{webId}")]
        [ProducesResponseType(typeof(Website), StatusCodes.Status200OK)]
        public Website getWebsite(int webId)
        {
            return _adminService.getWebsite(webId);
        }



        [HttpGet]
        [Route("getabout/{abautId}")]
        [ProducesResponseType(typeof(Aboutu), StatusCodes.Status200OK)]
        public Aboutu getAboutus(int abautId)
        {
            return _adminService.getAboutus(abautId);
        }

        [HttpGet]
        [Route("getContact/{contactId}")]
        [ProducesResponseType(typeof(Contactu), StatusCodes.Status200OK)]
        public Contactu getContact(int contactId)
        {
            return _adminService.getContact(contactId);
        }

        [HttpPost]
        [Route("GetAllRgisteredCompanyByDate")]
        [ProducesResponseType(typeof(List<Company>), StatusCodes.Status200OK)]
        public List<Company> GetAllRgisteredCompanyByDate(DatesSearch dates)
        {
            return _adminService.GetAllRgisteredCompanyByDate(dates);
        }

        [HttpPost]
        [Route("GetNumOfCompanyByDate")]
        [ProducesResponseType(typeof(Total), StatusCodes.Status200OK)]
        public Total GetNumOfCompanyByDate(DatesSearch dates)
        {
            return _adminService.GetNumOfCompanyByDate(dates);
        }


        [HttpPost]
        [Route("GetNumOfJobAppliedByDate")]
        [ProducesResponseType(typeof(Total), StatusCodes.Status200OK)]
        public Total GetNumOfJobAppliedByDate(DatesSearch dates)
        {
            return _adminService.GetNumOfJobAppliedByDate(dates);
        }


        [HttpGet]
        [Route("GetNumJobPostByCompany")]
        [ProducesResponseType(typeof(List<List<ComanyDto>>), StatusCodes.Status200OK)]
        public List<ComanyDto> GetNumJobPostByCompany()
        {
            return _adminService.GetNumJobPostByCompany( );
        }

        [HttpPost]
        [Route("GetNumJobPostByCompanyDate")]
        [ProducesResponseType(typeof(List<ComanyDto>), StatusCodes.Status200OK)]
        public List<ComanyDto> GetNumJobPostByCompanyDate(DatesSearch dates)
        {
            return _adminService.GetNumJobPostByCompanyDate(dates);
        }
        [HttpPut]
        [Route("UpdateWebsite")]
        public bool UpdateWebsite([FromBody] Website website)
        {
            return _adminService.UpdateWebsite(website);
        }


        [HttpPut]
        [Route("UpdateAbout")]
        public bool UpdateAbout([FromBody] Aboutu about)
        {
            return _adminService.UpdateAbout(about);
        }


        [HttpPut]
        [Route("UpdateContact")]
        public bool UpdateContact([FromBody] Contactu contactu)
        {
            return _adminService.UpdateContact(contactu);
        }

        [HttpPost]
        [Route("GetAllJobAppliedByDate")]
        [ProducesResponseType(typeof(List<JobApplicants>), StatusCodes.Status200OK)]
        public List<UserApplyJobDTO> GetAllJobAppliedByDate(DatesSearch dates)
        {
            return _adminService.GetAllJobAppliedByDate(dates);
        }


        [HttpGet]
        [Route("GetAllJobApplied")]
        [ProducesResponseType(typeof(List<UserApplyJobDTO>), StatusCodes.Status200OK)]
        public List<UserApplyJobDTO> GetAllJobApplied( )
        {
            return _adminService.GetAllJobApplied();
        }

        [HttpGet]
        [Route("GetAllRgisteredUsers")]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        public List<User> GetAllRgisteredUsers()
        {
            return _adminService.GetAllRgisteredUsers();
        }


        [HttpPut]
        [Route("updateJob")]
         public bool UpdateJob(Postedjob job)
        {
            return _adminService.UpdateJob(job);
        }


        [HttpPut]
        [Route("updateJob2")]
        public bool UpdateJob2(Postedjob job)
        {
            return _adminService.UpdateJob2(job);
        }
    }
}
