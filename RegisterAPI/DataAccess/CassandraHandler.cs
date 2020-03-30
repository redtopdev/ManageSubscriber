/// <summary>
/// Developer: ShyamSk
/// </summary>

namespace RegisterAPI.DataAccess
{
    using Cassandra;
    using Cassandra.Mapping;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using RegisterAPI.Abstract;
    using RegisterAPI.Models;
    using System;

    /// <summary>
    /// Cassandra DB Handler
    /// </summary>
    public class CassandraHandler : IDataAccess
    {
        private readonly ILogger<CassandraHandler> _logger;
        private IConfiguration _configuration;

        public CassandraHandler(ILogger<CassandraHandler> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        /// <summary>
        /// Saves User Profile
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public Guid SaveProfile(UserProfile profile)
        {
            _logger.LogInformation("Cassandra - Inserting profile ....");
            UserProfile profileD = new UserProfile();

            try
            {
                IConfiguration cassandraConfig = _configuration.GetSection("Cassandra");
                string contactPoints = cassandraConfig.GetValue<string>("host");// "127.0.0.1,127.0.0.2,127.0.0.3";
                var builder = Cluster.Builder().WithConnectionString(String.Format("Contact Points={0}", contactPoints));
                //var config = builder.GetConfiguration();
                builder = Cluster.Builder().WithConnectionString(String.Format("Contact Points={0};Port=" + cassandraConfig.GetValue<string>("port"), contactPoints));
                var config = builder.GetConfiguration();
                var myCassandraCluster = builder.Build();

                using (var session = myCassandraCluster.Connect("dev"))
                {
                    IMapper mapper = new Mapper(session);
                    MappingConfiguration.Global.Define(
                       new Map<UserProfile>()
                          .TableName("userprofile")
                          .PartitionKey(u => u.UserId));

                    profile.UserId = Guid.NewGuid();
                    mapper.Insert<UserProfile>(profile);

                    profileD = mapper.Single<UserProfile>("SELECT userid, profilename, gcmclientid, countrycode, mobilenumber FROM UserProfile WHERE Userid = ?", profile.UserId);
                    Console.WriteLine("Found Profile:{0}", profileD.ProfileName + " " + profileD.MobileNumber);
                    _logger.LogInformation("Cassandra - Profile Saved!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Saving profile failed.");
                throw;
            }
            return profileD.UserId;
        }
    }
}
