/// <summary>
/// Developer: ShyamSk
/// </summary>

namespace RegisterAPI.DataAccess
{
    using Cassandra;
    using Cassandra.Mapping;
    using Engaze.Core.Persistance.Cassandra;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using RegisterAPI.Abstract;
    using RegisterAPI.Models;
    using System;

    /// <summary>
    /// Cassandra DB Handler
    /// </summary>
    public class CassandraRepository : IDataAccess
    {
        private readonly ILogger<CassandraRepository> logger;
        private IConfiguration configuration;
        private CassandraSessionCacheManager sessionCacheManager;
        private string keySpace = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string KeySpace
        {
            get
            {
                if (string.IsNullOrEmpty(keySpace))
                {
                    keySpace = configuration.GetSection("CassandraConfiguration").GetValue<string>("KeySpace");
                }
                return keySpace;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionCacheManager"></param>
        /// <param name="cassandrConfig"></param>
        /// <param name="logger"></param>
        public CassandraRepository(CassandraSessionCacheManager sessionCacheManager, ILogger<CassandraRepository> logger, IConfiguration config)
        {
            this.sessionCacheManager = sessionCacheManager;
            this.configuration = config;
            this.logger = logger;
            //this.keySpace = 
        }

        /// <summary>
        /// Saves User Profile
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public Guid SaveProfile(UserProfile profile)
        {
            logger.LogInformation("Cassandra - Inserting profile ....");
            Guid userId = Guid.NewGuid();
            try
            {
                var session = sessionCacheManager.GetSession(KeySpace);
                var preparedStatement = session.Prepare(CassandraDML.InsertStatement);
                var statement = preparedStatement.Bind(userId, profile.GCMClientId, profile.ProfileName,
                    profile.ImageUrl,profile.CountryCode, profile.MobileNumber, profile.IsDeleted, 
                    profile.CreatedOn);

                session.Execute(statement);
                logger.LogInformation("Cassandra - Profile Saved....");
                return userId;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Saving profile failed.");
                throw;
            }
        }
    }
}
