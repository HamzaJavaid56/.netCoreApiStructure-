using AF.DataEntities.Context;
using CB_BusinessLogic.Services;
using CB_BusinessLogic.Services.CustomerService;
using CB_BusinessLogic.Services.EfCoreCrud;
using CB_BusinessLogic.Services.GenericRepoEFCore;
using CB_DataEntity.GenericRepository;
using CB_WebAPI.Utilites;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        #region Constructor
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region Register Services
        public void ConfigureServices(IServiceCollection services)
        {
            // Add controller
            services.AddControllers();
            // Add Connection String
            services.AddDbContext<SpContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // application.json configration for class libraray
            services.Configure<AppSettingsModel2>(Configuration.GetSection("AppSettingsModel2"));
            services.AddOptions();

            #region  JWT Authentication Configration
            // Configure Jwt token Setting Section.
            var JwtSetting = Configuration.GetSection("JwtSettings");
            services.Configure<AppSettingsModel>(JwtSetting);
            var appSetting = JwtSetting.Get<AppSettingsModel>();
            // jwt     
            var key = Encoding.ASCII.GetBytes(appSetting.SecretKey);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSetting["SecretKey"])),
                    ClockSkew = TimeSpan.Zero // remove delay of token when expire
                };
                x.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];

                        //** If the request is for our hub...
                        //var path = context.HttpContext.Request.Path;
                        //if (!string.IsNullOrEmpty(accessToken) &&
                        //    (path.StartsWithSegments("/chatHub/negotiate")))
                        //{
                        //    //** Read the token out of the query string
                        //    context.Token = accessToken;
                        //}
                        context.Token = accessToken;
                        return Task.CompletedTask;
                    }
                };
            });
            #endregion

            #region Add Business Logic Services Classes
            services.AddSingleton<IJwtAuth>(new Auth(JwtSetting["SecretKey"]));
            services.AddScoped<IMainService, MainService>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IGenericRepoEFCoreService), typeof(GenericRepoEFCoreService));
            #endregion

            #region Add Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MyFirstAspCoreApi",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer",
                new Microsoft.OpenApi.Models.OpenApiSecurityScheme
               {
                   In = ParameterLocation.Header,
                   Description = "Please enter into field the word 'Bearer' following by space and JWT",
                   Name = "Authorization",
                   Type = SecuritySchemeType.ApiKey
               });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });
            #endregion
        }
        #endregion

        #region Add Middle-Ware
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyFirstAspCoreApi v1"));
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            // Authenticate the user [user name,password] 
            app.UseAuthentication();
            // Autherize the user [Check the users roles]
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        #endregion
    }
}
