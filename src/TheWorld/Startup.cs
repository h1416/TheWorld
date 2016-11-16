using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheWorld.Models;
using TheWorld.Services;

namespace TheWorld
{
    public class Startup
    {
        private IHostingEnvironment _env;
        private IConfigurationRoot _config;

        public Startup(IHostingEnvironment env)
        {
            _env = env;

            // build json files
            var builder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("config.json") // add config.jason file
                .AddEnvironmentVariables(); // add environment variables to help IT folks. The environment vars will override what every vars from the config.json file that have the same names

            _config = builder.Build(); // build the configuration root
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Add configuration root. This equipvalent to configuration manager in desktop apps
            // Register this singleton to use through out the app
            services.AddSingleton(_config);

            if (_env.IsEnvironment("Development") || _env.IsEnvironment("Testing"))
            {
                // for debugging or testing env
                services.AddScoped<IMailService, DebugMailService>();
            }
            else
            {
                // Implement a real mail service and register here
            }

            // register the world db context
            services.AddDbContext<WorldContext>(); // services.AddDbContext<WorldContext>(ServiceLifetime.Transient);
            services.AddScoped<IWorldRepository, WorldRepository>(); // register world repository
            services.AddTransient<WorldContextSeedData>(); // add seed data class

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            WorldContextSeedData seeder)
        {
            //app.UseDefaultFiles();
            app.UseStaticFiles();
            

            loggerFactory.AddConsole();

            if (env.IsEnvironment("Development"))
            {
                // display exception 
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(configRoute => configRoute.MapRoute(
                name: "Default",
                template: "{controller}/{action}/{id?}",
                defaults: new { controller = "App", action = "index" }));

            seeder.EnsureSeedData().Wait();
        }
    }
}
