/// <summary>
/// Developer: ShyamSk
/// </summary>

namespace RegisterAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using RegisterAPI.Abstract;
    using RegisterAPI.Models;
    using System;

    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private ILogger<RegisterController> logger;
        private IRepository repository;
        public RegisterController(ILogger<RegisterController> logger, IRepository repo)
        {
            this.logger = logger;
            this.repository = repo;
        }

        [HttpGet]
        public string Get()
        {
            logger.LogInformation("RegisterAPI is running. Get()");
            return "Im up";
        }

        [HttpPost]
        //[Route("RegisterAPI/register")]
        public IActionResult Post(UserProfile profile)
        {
            logger.LogInformation("Saving Profile");
            try
            {
                return Ok(repository.RegisterUserProfile(profile));
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
