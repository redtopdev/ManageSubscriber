/// <summary>
/// Developer: ShyamSk
/// </summary>
namespace RegisterAPI.BL
{
    using Microsoft.Extensions.Logging;
    using RegisterAPI.Abstract;
    using RegisterAPI.Models;
    using System;

    /// <summary>
    /// Registration Implementation
    /// </summary>
    public class RegisterRepository : IRepository
    {
        /// <summary>
        /// DB Handler
        /// </summary>
        private readonly IDataAccess _db;
        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger<RegisterRepository> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        public RegisterRepository(IDataAccess db, ILogger<RegisterRepository> logger )
        {
            _db = db;
            _logger = logger;
        }

        /// <summary>
        /// Register User Profile
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public RegisterResponse RegisterUserProfile(UserProfile profile)
        {
            _logger.LogInformation("Register repo - Saving Profile.");
            RegisterResponse response = new RegisterResponse();
            response.UserId =   _db.SaveProfile(profile);            
            return response;
        }
    }
}
