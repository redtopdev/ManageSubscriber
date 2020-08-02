/// <summary>
/// Developer: ShyamSk
/// </summary>

namespace Subscriber.Service
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Subscriber.DataContract;
    using System.Threading.Tasks;

    [ApiController]
    [Route("users/register")]
    public class RegisterController : ControllerBase
    {
        private ILogger<RegisterController> logger;
        private IProfileManager profileManager;
        public RegisterController(ILogger<RegisterController> logger, IProfileManager profileManager)
        {
            this.logger = logger;
            this.profileManager = profileManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserProfile profile)
        {
            logger.LogInformation("Saving Profile");

            //put try catch only when you want to return custom message or status code, else this will
            //be caught in ExceptionHandling middleware so no need to put try catch here


            return Ok(new { Id = await profileManager.RegisterUserProfile(profile) });
        }
    }
}
