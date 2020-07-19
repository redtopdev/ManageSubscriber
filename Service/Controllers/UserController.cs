using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Subscriber.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpPost("users/registered")]
        public async Task<IActionResult> GetRegisteredContacts(Contacts contacts)
        {
            logger.LogInformation("Fetching Registered Contacts");

            //put try catch only when you want to return custom message or status code, else this will
            //be caught in ExceptionHandling middleware so no need to put try catch here

            return Ok(await contactsManager.GetRegisteredContacts(contacts));
        }

        [HttpGet("users/gcmclientid")]

        public async Task<IActionResult> GetGCMClientIds([FromQuery(Name = "userIds")]IEnumerable<Guid> userIds)
        {
            logger.LogInformation("Fetching GCM ClientIds");
            var result = await contactsManager.GetGCMClientIds(userIds);
            //Dictionary is not supported as returned value
            return Ok(result.Keys.Select(key => new { UserId = key, GcmClientId = result[key] }));
        }
    }
}
