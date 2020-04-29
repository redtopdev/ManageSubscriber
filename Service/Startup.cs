/// <summary>
/// Developer: ShyamSk
/// </summary>
namespace Register.Service
{
    using Engaze.Core.Persistance.Cassandra;
    using Engaze.Core.Web;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Register.DataManager;
    using Serilog;

    public class Startup : EngazeStartup
    {
        public Startup(IConfiguration configuration) : base(configuration) { }

        public override void ConfigureComponentServices(IServiceCollection services)
        {
            services.AddControllers();
            services.ConfigureCassandraServices(Configuration);
            services.AddTransient<IProfileManager, ProfileManager>();
            services.AddTransient<IContactsManager, ContactsManager>();
            services.AddTransient<IRepository, CassandraRepository>();
        }

        public override void ConfigureComponent(IApplicationBuilder app)
        {
            app.UseSerilogRequestLogging();
        }
    }
}
