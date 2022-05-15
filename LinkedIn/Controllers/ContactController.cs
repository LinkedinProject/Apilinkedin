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
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<Contactu>), StatusCodes.Status200OK)]
        public List<Contactu> GetAllContact()
        {
            return _contactService.GetAllContact();
        }
        [HttpPost]
        public bool CreateContact([FromBody] Contactu contactu)
        {

            return _contactService.CreateContact(contactu);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteContact(int contactid)
        {
            return _contactService.DeleteContact(contactid);
        }
        [HttpPatch]
        public bool UpdateContact([FromBody] Contactu contactu)
        {
            return _contactService.UpdateContact(contactu);
        }

    }
}
