using LinkedIn.core.Data;
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
    public class WebsiteController : ControllerBase
    {

        private readonly IWebsiteService _websiteService;

        public WebsiteController(IWebsiteService websiteService)
        {
            _websiteService = websiteService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Website>), StatusCodes.Status200OK)]
        public List<Website> GetAllAbout()
        {
            return _websiteService.GetAllWebsite();
        }
        [HttpPost]
        public bool CreateWebsite([FromBody] Website website )
        {

            return _websiteService.CreateWebsite(website);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteWebsite(int id)
        {
            return _websiteService.DeleteWebsite(id);
        }
        [Route("UpdateWebsite/{id}")]

        [HttpPatch]
        public bool UpdateWebsite([FromBody] Website website)
        {
            return _websiteService.UpdateWebsite(website);
        }
    }
}
