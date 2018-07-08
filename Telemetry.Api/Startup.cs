using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Telemetry.Api.Models;
using Telemetry.Api.Models.Inputs;
using Telemetry.Api.Mutations;
using Telemetry.Api.Queries;
using Telemetry.Api.Schemas;
using Telemetry.Core.Data;
using Telemetry.Dal;
using Telemetry.Dal.Repositories;

namespace Telemetry.Api
{
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
            services.AddMvc();
            services.AddDbContext<TelemetryDataContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:TeleMetry"]));

            services.AddTransient<IDeviceRepository, DeviceRepository>();
            services.AddTransient<IDeviceDataRepository, DeviceDataRepository>();

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            //Return types
            services.AddSingleton<DeviceType>();
            services.AddSingleton<DeviceDataType>();

            //Input types
            services.AddSingleton<CreateDeviceType>();
            
            //Queries
            services.AddSingleton<DeviceQuery>();
            services.AddSingleton<DeviceDataQuery>();
            services.AddSingleton<TelemetryQuery>();

            //Mutations
            services.AddSingleton<TelemetryMutation>();
            services.AddSingleton<DeviceMutation>();

            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new TelemetrySchema(new FuncDependencyResolver(type => sp.GetService(type))));

            Log.Logger = new LoggerConfiguration()
                                 .MinimumLevel.Information()
                                 .Enrich.FromLogContext()
                                 .WriteTo.Seq("http://localhost:5341")
                                .CreateLogger();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, TelemetryDataContext db, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
                      
            loggerFactory.AddSerilog();
            app.UseGraphiQl();
            app.UseMvc();
            db.EnsureSeedData();
            //Log.CloseAndFlush();
        }

    }
}
