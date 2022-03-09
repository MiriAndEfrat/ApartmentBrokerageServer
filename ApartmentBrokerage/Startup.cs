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
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace ApartmentBrokerage
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
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("key").Value);

              services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {

                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApartmentBrokerage", Version = "v1" });
                
                // To Enable authorization using Swagger (JWT)    
               c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });

            services.AddScoped(typeof(IUserBL), typeof(UserBL));
            services.AddScoped(typeof(IUserDL), typeof(UserDL)); 
            services.AddScoped(typeof(IPersonDL), typeof(PersonDL));
            
            services.AddScoped(typeof(ISubscriptionPerUserBL), typeof(SubscriptionPerUserBL));
            services.AddScoped(typeof(ISubscriptionPerUserDL), typeof(SubscriptionPerUserDL));

            services.AddScoped(typeof(ISubscriberPropertyDetailsBL), typeof(SubscriberPropertyDetailsBL));
            services.AddScoped(typeof(ISubscriberPropertyDetailsDL), typeof(SubscriberPropertyDetailsDL));

            services.AddScoped(typeof(ISubscriptionTypeBL), typeof(SubscriptionTypeBL));
            services.AddScoped(typeof(ISubscriptionTypeDL), typeof(SubscriptionTypeDL));

            services.AddScoped(typeof(IUserTypeBL), typeof(UserTypeBL));
            services.AddScoped(typeof(IUserTypeDL), typeof(UserTypeDL));

            services.AddScoped(typeof(ICityBL), typeof(CityBL));
            services.AddScoped(typeof(ICityDL), typeof(CityDL));

            services.AddScoped(typeof(INeighborhoodBL), typeof(NeighborhoodBL));
            services.AddScoped(typeof(INeighborhoodDL), typeof(NeighborhoodDL));

            services.AddScoped(typeof(IStreetBL), typeof(StreetBL));
            services.AddScoped(typeof(IStreetDL), typeof(StreetDL));

            services.AddScoped(typeof(IPropertyDetailBL), typeof(PropertyDetailBL));
            services.AddScoped(typeof(IPropertyDetailDL), typeof(PropertyDetailDL));

            services.AddScoped(typeof(IAreaBL), typeof(AreaBL));
            services.AddScoped(typeof(IAreaDL), typeof(AreaDL));

            services.AddScoped<IPasswordHashHelper, PasswordHashHelper>();

            services.AddScoped(typeof(IRatingBL), typeof(RatingBL));
            services.AddScoped(typeof(IRatingDL), typeof(RatingDL));

            services.AddScoped(typeof(ICodeTableBL), typeof(CodeTableBL));
            services.AddScoped(typeof(ICodeTableDL), typeof(CodeTableDL));

            services.AddDbContext<ApartmentBrokerageContext>(options => options.UseSqlServer(
               Configuration.GetConnectionString("srv2\\pupils")), ServiceLifetime.Scoped);

            services.AddAutoMapper(typeof(Startup));

            services.AddResponseCaching();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILogger<Startup> logger)
        {

            logger.LogInformation("server is up");

            //app.UseLoggerMiddleware();


            if (env.IsDevelopment())
            {
                //app.UseLoggerMiddleware();

                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApartmentBrokerage v1"));
            }

            app.UseStaticFiles();//???????????

            app.UseHttpsRedirection();

            app.UseResponseCaching();
            app.UseCacheMiddleware();

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.Map("/api", app2 =>
            {
                app2.UseRouting();
                app2.UseAuthorization();
                app2.UseRatingMiddleware();
                app2.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            });

            app.UseAuthorization();
            //app.UseRatingMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
