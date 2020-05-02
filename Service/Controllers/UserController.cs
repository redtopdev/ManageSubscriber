using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Subscriber.DataContract;
using System;
using System.Collections.Generic;

namespace Subscriber.Service
{

    [ApiController]
    public class UserController : ControllerBase
    {
        private ILogger<UserController> logger;
        private IContactsManager contactsManager;

        public UserController(ILogger<UserController> logger, IContactsManager contactsManager)
        {
            this.logger = logger;
            this.contactsManager = contactsManager;
        }

        [HttpGet("users/registered")]
        public IActionResult Get(Contacts contacts)
        {
            logger.LogInformation("Fetching Registered Contacts");

            //put try catch only when you want to return custom message or status code, else this will
            //be caught in ExceptionHandling middleware so no need to put try catch here

            return Ok(contactsManager.GetRegisteredContacts(contacts));
        }

        [HttpGet("users/gmcclientid")]

        public IActionResult GetGCMClientIds([FromQuery(Name = "userIds")]IEnumerable<Guid> userIds)
        {
            logger.LogInformation("Fetching GCM ClientIds");

            return Ok(contactsManager.GetGCMClientIds(userIds));
        }
    }
}