using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using PatientDbContext;
using PatientEntity;
using PatientManagement.Models;
using PatientManagement.PreProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PatientManagement
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
            // ADd NewtonSoft here
            services.AddControllers().AddNewtonsoftJson(options=>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            // Add CORS
            services.AddCors(o=>o.AddPolicy("MyCorsPolicy",builder=>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            // Add session
            services.AddSession(options=> {
                options.IdleTimeout = TimeSpan.FromSeconds(120);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddScoped<Patient>();

            // Add DbContext class for Database Providers
           
            services.AddDbContext<PatientDb>(
                options => { options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]); }
              );

            services.AddControllersWithViews();
            // Token will be checked after above method
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => 
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "Shiv",
                    ValidAudience = "Shiv",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Shiv@123333Shiv@12333"))

                };
            });
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //Add middleware
            app.UseMiddlewarePreProcessing1();
            app.UseMiddlewarePreProcessing2();

            app.UseRouting();

            // use CORS after below method i.e  Authentication
            app.UseCors("MyCorsPolicy");

            // use Authentication
            app.UseAuthentication();

            app.UseAuthorization();

            // use session here after method i.e Authorization 
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
