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
        private readonly IDataAccess db;
        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger<RegisterRepository> logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        public RegisterRepository(IDataAccess db, ILogger<RegisterRepository> logger )
        {
            this.db = db;
            this.logger = logger;
        }

        /// <summary>
        /// Register User Profile
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public RegisterResponse RegisterUserProfile(UserProfile profile)
        {
            logger.LogInformation("Register repo - Saving Profile.");
            RegisterResponse response = new RegisterResponse();
            response.UserId =   db.SaveProfile(profile);            
            return response;
        }
    }
}
