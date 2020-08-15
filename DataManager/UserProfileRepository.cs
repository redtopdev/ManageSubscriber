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
    using System.Linq;
    using System.Threading.Tasks;


    /// <summary>
    /// Cassandra DB Handler
    /// </summary>
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ILogger<UserProfileRepository> logger;
        private CassandraSessionCacheManager sessionCacheManager;
        private string keySpace;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionCacheManager"></param>
        /// <param name="cassandrConfig"></param>
        /// <param name="logger"></param>
        public UserProfileRepository(CassandraSessionCacheManager sessionCacheManager, CassandraConfiguration cassandrConfig, ILogger<UserProfileRepository> logger)
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
        public async Task<Guid> SaveProfile(UserProfile profile)
        {
            logger.LogInformation("Cassandra - Inserting profile ....");
            Guid userId = Guid.NewGuid();
            try
            {
                var session = sessionCacheManager.GetSession(keySpace);
                //Get existing users
                var preparedStatement = session.Prepare(CassandraDML.SelectAllUserProfiles);
                var resultSet = await session.ExecuteAsync(preparedStatement.Bind());
                logger.LogInformation("Found results.");
                foreach (var res in resultSet)
                {
                    Guid UserId = res.GetValue<System.Guid>("userid");
                    string CountryCode = res.GetValue<string>("countrycode");
                    string MobileNumber = res.GetValue<string>("mobilenumber");
                    if (profile.MobileNumber == MobileNumber && profile.CountryCode == CountryCode)
                    {
                        return UserId;
                    }
                }
                //Insert record if new record
                var preparedStatementInsert = session.Prepare(CassandraDML.InsertStatement);
                var statement = preparedStatementInsert.Bind(userId, profile.GCMClientId, profile.ProfileName,
                    profile.ImageUrl, profile.CountryCode, profile.MobileNumber, profile.IsDeleted,
                    profile.CreatedOn);

                await session.ExecuteAsync(statement);
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
        public async Task<List<PhoneContact>> GetRegisteredUsers()
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

                var resultSet = await session.ExecuteAsync(preparedStatement.Bind());

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

        public async Task<Dictionary<Guid, string>> GetGCMClientIds(IEnumerable<Guid> userIds)
        {
            logger.LogInformation("Cassandra - Fetching Gcm Client Ids ..");
            Guid userId = Guid.NewGuid();
            Dictionary<Guid, string> result = new Dictionary<Guid, string>();
            try
            {
                var session = sessionCacheManager.GetSession(keySpace);
                var preparedStatement = session.Prepare(string.Format(CassandraDML.selectGcmClientIdsByUserIds, string.Join(',', userIds)));

                var resultSet = await session.ExecuteAsync(preparedStatement.Bind());

                logger.LogInformation("Found results.");
                resultSet.ToList().ForEach(res => result.Add(res.GetValue<System.Guid>("userid"), res.GetValue<string>("gcmclientid")));
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError("Saving profile failed. Exception " + ex.ToString());
                throw;
            }
        }
    }
}
