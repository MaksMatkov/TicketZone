using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiketsTerminal.API.Infrastructure;
using TiketsTerminal.API.Middleware;
using TiketsTerminal.BusinessLogic;
using TiketsTerminal.BusinessLogic.Abstraction;
using TiketsTerminal.BusinessLogic.Interfaces;
using TiketsTerminal.BusinessLogic.Services;
using TiketsTerminal.Infrastucture.Infrastructure;

namespace TiketsTerminal.API
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TiketsTerminal.API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
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
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });

            services.Configure<AuthenticationConfiguration>(Configuration.GetSection("Authentication"));

            var authOptions = Configuration.GetSection("Authentication").Get<AuthenticationConfiguration>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateAudience = true,
                        ValidAudience = authOptions.Audience,

                        ValidateIssuer = true,
                        ValidIssuer = authOptions.Issuer,

                        ValidateLifetime = true,

                        IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true
                    };
                });

            SetupDependencyInjection(services);
        }

        private void SetupDependencyInjection(IServiceCollection services)
        {
            var connectionStrings = Configuration.GetSection("ConnectionStrings").Get<ConnectionStringsConfiguration>();

            services.AddDbContext<dbContext>(o =>
            {
            });

            //aded mapping
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            //add di
            services.AddSingleton(connectionStrings);

            //serv
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IFilmViewingTimeService, FilmViewingTimeService>();
            services.AddScoped<ITicketOrderService, TicketOrderService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TiketsTerminal.API v1"));
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(builder => builder
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
