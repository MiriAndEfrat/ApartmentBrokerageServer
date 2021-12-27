using AutoMapper;
using BL;
using DL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ApartmentBrokerage///what happen??
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
            

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApartmentBrokerage", Version = "v1" });
            });

            services.AddScoped(typeof(IUserBL), typeof(UserBL));
            services.AddScoped(typeof(IUserDL), typeof(UserDL));
            services.AddScoped(typeof(IPersonDL), typeof(PersonDL));
            
            services.AddScoped(typeof(ISubscriptionPerUserBL), typeof(SubscriptionPerUserBL));
            services.AddScoped(typeof(ISubscriptionPerUserDL), typeof(SubscriptionPerUserDL));

            services.AddScoped(typeof(ISubscriberPropertyDetailsBL), typeof(SubscriberPropertyDetailsBL));
            services.AddScoped(typeof(ISubscriberPropertyDetailsDL), typeof(SubscriberPropertyDetailsDL));

            


            services.AddDbContext<ApartmentBrokerageContext>(options => options.UseSqlServer(
               Configuration.GetConnectionString("srv2\\pupils")), ServiceLifetime.Scoped);

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILogger<Startup> logger)
        {

            logger.LogInformation("server is up");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApartmentBrokerage v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
