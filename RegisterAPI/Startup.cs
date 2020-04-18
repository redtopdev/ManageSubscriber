/// <summary>
/// Developer: ShyamSk
/// </summary>
namespace RegisterAPI
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using RegisterAPI.Abstract;
    using RegisterAPI.BL;
    using RegisterAPI.DataAccess;
    using Serilog;
    using Engaze.Core.Persistance.Cassandra;
    using Engaze.Core.Persistance.Cassandra.Abstract;
    using RegisterAPI.Middleware;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<ISessionManager, CassandraSessionCacheManager>();
            services.AddTransient<IRepository, RegisterRepository>();
            services.AddTransient<IDataAccess, CassandraRepository>();
            services.ConfigureCassandraServices(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAppException();
            app.UseAppStatus();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.Use)
        }
    }
}
