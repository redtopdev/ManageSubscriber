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
    using System.Data;

    [ApiController]
    [Route("register")]
    public class RegisterController : ControllerBase
    {
        private ILogger<RegisterController> logger;
        private IRepository repository;
        public RegisterController(ILogger<RegisterController> logger, IRepository repo)
        {
            this.logger = logger;
            this.repository = repo;
        }

        public IActionResult CheckStatus()
        {
            Exception ex= new Exception("server error");
            throw ex;
        }


        [HttpPost]       
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
