using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Register.DataContract;

namespace Register.Service.Controllers
{

    [Route("user/registeredcontacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private ILogger<ContactsController> logger;
        private IContactsManager contactsManager;

        public ContactsController(ILogger<ContactsController> logger, IContactsManager contactsManager)
        {
            this.logger = logger;
            this.contactsManager = contactsManager;
        }

        [HttpPost]
        public IActionResult Post(ContactsRequest request)
        {
            logger.LogInformation("Fetching Registered Contacts");

            //put try catch only when you want to return custom message or status code, else this will
            //be caught in ExceptionHandling middleware so no need to put try catch here

            return Ok(contactsManager.GetRegisteredContacts(request));
        }


    }
}