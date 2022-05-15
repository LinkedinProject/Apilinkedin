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
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<Aboutu>), StatusCodes.Status200OK)]
        public List<Aboutu> GetAllAbout()
        {
            return _aboutService.GetAllAbout();
        }
        [HttpPost]
        public bool CreateAbout([FromBody] Aboutu aboutu)
        {

            return _aboutService.CreateAbout(aboutu);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteAbout(int AboutId)
        {
            return _aboutService.DeleteAbout(AboutId);
        }
        [HttpPatch]
        public bool UpdateAbout([FromBody] Aboutu aboutu)
        {
            return _aboutService.UpdateAbout(aboutu);
        }

    }
}
