using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Http;
using Microsoft.EntityFrameworkCore;

namespace CIS174_TestCoreApp
{
    public class Startup
    {
        private readonly object connectionString;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration; 
         
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var connectionString = @"Server=tcp:cis174demo.database.windows.net,1433;Initial Catalog=CIS174;Persist Security Info=False;User ID=nlbrown;Password=????????;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            services.AddDbContext<Assgn10Context>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<Assgn10Context>();
            services.AddScoped<Assgn10Context>();
         //   services.AddScoped<PeopleService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc().AddXmlSerializerFormatters();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(" / Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                   name: "default2",
                   template: "{controller=Student}/{access:range(1,10)}/{action=AccessCk}/{id?}",
                defaults: new
                {
                    access = 11
                });

            });

           // Assgn10Context.Initialize(app.ApplicationServices);
        }
    }
}
