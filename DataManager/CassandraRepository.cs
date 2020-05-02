/// <summary>
/// Developer: ShyamSk
/// </summary>

namespace Subscriber.DataPersistance
{
    using Engaze.Core.Persistance.Cassandra;
    using Microsoft.Extensions.Logging;
    using Subscriber.DataContract;
    using System;
    using System.Collections.Generic;


    /// <summary>
    /// Cassandra DB Handler
    /// </summary>
    public class CassandraRepository : IRepository
    {
        private readonly ILogger<CassandraRepository> logger;
        private CassandraSessionCacheManager sessionCacheManager;
        private string keySpace;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionCacheManager"></param>
        /// <param name="cassandrConfig"></param>
        /// <param name="logger"></param>
        public CassandraRepository(CassandraSessionCacheManager sessionCacheManager, CassandraConfiguration cassandrConfig, ILogger<CassandraRepository> logger)
        {
            this.sessionCacheManager = sessionCacheManager;
            this.keySpace = cassandrConfig.KeySpace;
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
                var session = sessionCacheManager.GetSession(keySpace);
                var preparedStatement = session.Prepare(CassandraDML.InsertStatement);
                var statement = preparedStatement.Bind(userId, profile.GCMClientId, profile.ProfileName,
                    profile.ImageUrl, profile.CountryCode, profile.MobileNumber, profile.IsDeleted,
                    profile.CreatedOn);

                session.Execute(statement);
                logger.LogInformation("Cassandra - Profile Saved....");
                return userId;
            }
            catch (Exception ex)
            {
                logger.LogError("Saving profile failed. Exception " + ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// Saves User Profile
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public List<PhoneContact> GetRegisteredUsers()
        {
            logger.LogInformation("Cassandra - Fetching Registered Users ..");
            Guid userId = Guid.NewGuid();
            List<PhoneContact> pcList = new List<PhoneContact>();
            try
            {
                var session = sessionCacheManager.GetSession(keySpace);
                var preparedStatement = session.Prepare(CassandraDML.SelectAllUserProfiles);
                //var statement = preparedStatement.Bind(userId, profile.GCMClientId, profile.ProfileName,
                //    profile.ImageUrl, profile.CountryCode, profile.MobileNumber, profile.IsDeleted,
                //    profile.CreatedOn);

                var resultSet = session.Execute(preparedStatement.Bind());

                logger.LogInformation("Found results.");
                foreach (var res in resultSet)
                {
                    pcList.Add(new PhoneContact()
                    {
                        UserId = res.GetValue<System.Guid>("userid"),
                        CountryCode = res.GetValue<string>("countrycode"),
                        MobileNumber = res.GetValue<string>("mobilenumber")
                    });
                }
                return pcList;
            }
            catch (Exception ex)
            {
                logger.LogError("Saving profile failed. Exception " + ex.ToString());
                throw;
            }
        }
    }
}
