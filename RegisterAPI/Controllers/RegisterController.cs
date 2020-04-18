/// <summary>
/// Developer: ShyamSk
/// </summary>

namespace Register.Service
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Register.DataContract;
    using System;
    using System.Data;

    [ApiController]
    [Route("register")]
    public class RegisterController : ControllerBase
    {
        private ILogger<RegisterController> logger;
        private IProfileManager profileManager;
        public RegisterController(ILogger<RegisterController> logger, IProfileManager profileManager)
        {
            this.logger = logger;
            this.profileManager = profileManager;
        }

        public IActionResult CheckStatus()
        {
            Exception ex = new Exception("server error");
            throw ex;
        }


        [HttpPost]
        public IActionResult Post(UserProfile profile)
        {
            logger.LogInformation("Saving Profile");

            //put try catch only when you want to return custom message or status code, else this will
            //be caught in ExceptionHandling middleware so no need to put try catch here

            return Ok(profileManager.RegisterUserProfile(profile));
        }
    }
}
