/// <summary>
/// Developer: ShyamSk
/// </summary>
namespace Subscriber.Service
{
    using Engaze.Core.Persistance.Cassandra;
    using Engaze.Core.Web;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Subscriber.DataPersistance;

    public class Startup : EngazeStartup
    {
        public Startup(IConfiguration configuration) : base(configuration) { }

        public override void ConfigureComponentServices(IServiceCollection services)
        {         
            services.ConfigureCloudCassandra(Configuration);
            services.AddTransient<IProfileManager, ProfileManager>();
            services.AddTransient<IContactsManager, ContactsManager>();
            services.AddTransient<IUserProfileRepository, UserProfileRepository>();
        }

        public override void ConfigureComponent(IApplicationBuilder app) { }
        
    }
}
