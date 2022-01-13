
using Business;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;
using User_gems_challenge_business;
using User_gems_challenge_entity;
using User_gems_challenge_interface_business;
using User_gems_challenge_interface_repository;
using User_gems_challenge_repository;
using User_gems_challenge_utils;

namespace User_gems_challenge
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
            //services.AddControllers();
            services.AddCors(Options =>
            {
                Options.AddPolicy(
                    "CorsPolicy",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Api do aplicativo ServicesForOne",
                    Description = "Api que fornece uma forma de usuarios contratarem e oferecerem serci�os de todos os tipos",
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

            });

            services.Configure<ConnectionString>(Configuration.GetSection("ConnectionStrings"));

            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IRetweetBusiness, RetweetBusiness>();
            services.AddScoped<IFollowingBusiness, FollowingBusiness>();
            services.AddScoped<ITweetBusiness, TweetBusiness>();


            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IRepository<Following>, Repository<Following>>();
            services.AddScoped<IRepository<Retweets>, Repository<Retweets>>();
            services.AddScoped<ITweetRepository, TweetRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRepository<Tweets>, Repository<Tweets>>();
            services.AddScoped<IRepository<Retweets>, Repository<Retweets>>();

            // Add functionality to inject IOptions<T>
            services.AddOptions();

            // Add our Config object so it can be injected
            services.AddMvc(options =>
            {
                options.Filters.Add(new AllowAnonymousFilter());
                options.EnableEndpointRouting = false;
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
                app.UseHsts();
            }
            app.UseSwagger();

            const string swagger = "/swagger/v1/swagger.json";

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(swagger, $"UserGemsChallenge");
            });
            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseMvc();
        }
    }
}
