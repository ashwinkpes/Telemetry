using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;
using Telemetry.Api.APIAgents;
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
            services.AddSingleton<MovieType>();
            services.AddSingleton<CustomerType>();

            //Input types
            services.AddSingleton<CreateDeviceType>();
            
            //Queries
            services.AddSingleton<DeviceQuery>();
            services.AddSingleton<DeviceDataQuery>();
            services.AddSingleton<SmartPumpquery>();
            services.AddSingleton<TelemetryQuery>();

            //Mutations
            services.AddSingleton<TelemetryMutation>();
            services.AddSingleton<DeviceMutation>();

            //Agents
            services.AddTransient<SmartPumpApiAgent>();

            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new TelemetrySchema(new FuncDependencyResolver(type => sp.GetService(type))));

            //Logging using serilog - http server as seq
            Log.Logger = new LoggerConfiguration()
                                 .MinimumLevel.Information()
                                 .Enrich.FromLogContext()
                                 .WriteTo.Seq("http://localhost:5341")
                                .CreateLogger();


            //Logging into database using serilog
            //services.AddSingleton<Serilog.ILogger>
            //(x => new LoggerConfiguration()
            //      .MinimumLevel.Information()
            //      .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            //      .MinimumLevel.Override("System", LogEventLevel.Error)
            //      .WriteTo.MSSqlServer(Configuration["Serilog:ConnectionString"]
            //      , Configuration["Serilog:TableName"]
            //      , LogEventLevel.Information)
            //      .CreateLogger());


            services.AddOptions();

            var swaggerSettings = Configuration.GetSection("SwaggerSettings");           

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info {
                    Title = swaggerSettings["Title"],
                    Version = swaggerSettings["Version"],
                    Description = swaggerSettings["Description"],
                    TermsOfService = swaggerSettings["TermsOfService"],
                    Contact = new Contact
                    {
                        Name = swaggerSettings["Contact:Name"],
                        Email = swaggerSettings["Contact:Email"],
                        Url = swaggerSettings["Contact:Url"],
                    }                    ,
                    License = new License
                    {
                        Name = swaggerSettings["License:Name"],
                        Url = swaggerSettings["License:Url"],
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });


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
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQL API V1");
            });
            app.UseMvc();
            db.EnsureSeedData();
            //Log.CloseAndFlush();
        }

    }
}
