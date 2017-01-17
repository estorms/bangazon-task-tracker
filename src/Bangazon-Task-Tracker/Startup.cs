//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;
//using Microsoft.EntityFrameworkCore;
//using Bangazon_Task_Tracker.Data;
//using Microsoft.EntityFrameworkCore.Infrastructure;

//namespace Bangazon_Task_Tracker
//{
//    public class Startup
//    {
//        public Startup(IHostingEnvironment env)
//        {
//            var builder = new ConfigurationBuilder()
//                .SetBasePath(env.ContentRootPath)
//                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
//                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

//            if (env.IsEnvironment("Development"))
//            {
//                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
//                builder.AddApplicationInsightsSettings(developerMode: true);
//            }

//            builder.AddEnvironmentVariables();
//            Configuration = builder.Build();
//        }

//        public IConfigurationRoot Configuration { get; }

//        // This method gets called by the runtime. Use this method to add services to the container
//        public void ConfigureServices(IServiceCollection services)
//        {

//            //string path = System.Environment.GetEnvironmentVariable("Bangazon_Db_Path");
//            //var connection = $"Filename={path}";
//            //Console.WriteLine($"connection = {connection}");
//            //services.AddDbContext<BangazonDbContext>(options => options.UseSqlite(connection));
//            services.AddDbContext<BangazonDbContext>(options => options.UseSqlite("Filename=./bangazon.db"));


//        // Add framework services.
//        services.AddApplicationInsightsTelemetry(Configuration);

//            services.AddMvc();
//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
//        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
//        {
//            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
//            loggerFactory.AddDebug();

//            app.UseApplicationInsightsRequestTelemetry();

//            app.UseApplicationInsightsExceptionTelemetry();

//            app.UseMvc();
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Bangazon_Task_Tracker.Data;

namespace Bangazon_Task_Tracker
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            var connection = @"Server=(localdb)\mssqllocaldb;Database=TaskTracker;Trusted_Connection=True;";
            services.AddDbContext<BangazonDbContext>(options => options.UseSqlServer(connection));

            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseMvc();
        }
    }
}