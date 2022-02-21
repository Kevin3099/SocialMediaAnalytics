using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using AnalyticsProject.Services;
using AnalyticsProject.Helpers;

namespace AnalyticsProject
{
    public class Startup
    {

        public const string CONFIG_DATABASE_CONNECTION = "socialMediaDatabase";


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            var connection = Configuration.GetConnectionString(CONFIG_DATABASE_CONNECTION);
            services.AddDbContext<DataModels.SMAContext>(options => options.UseSqlServer(connection));

            //   services.Configure<AppConfig>(Configuration.GetSection("appConfig"));
            services.AddTransient<IHomePageService, HomePageService>();
            services.AddTransient<IEventsService, EventsService>();
            services.AddTransient<IMachineLearningService, MachineLearningService>();
            services.AddTransient<ISummaryInformationService, SummaryInformationService>();

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(h => true).AllowCredentials());



            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
