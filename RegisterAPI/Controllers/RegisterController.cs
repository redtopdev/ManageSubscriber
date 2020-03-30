/// <summary>
/// Developer: ShyamSk
/// </summary>

namespace RegisterAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using RegisterAPI.Abstract;
    using RegisterAPI.Models;

    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly ILogger<RegisterController> _logger;
        private readonly IRepository _repository;
        public RegisterController(ILogger<RegisterController> logger, IRepository repo)
        {
            _logger = logger;
            _repository = repo;
        }

        [HttpGet]
        public string Get()
        {
            _logger.LogInformation("RegisterAPI is running. Get()");
            return "Im up";
        }

        [HttpPost]
        public RegisterResponse Post(UserProfile profile)
        {
            _logger.LogInformation("Saving Profile");
            return _repository.RegisterUserProfile(profile);
        }
    }
}
