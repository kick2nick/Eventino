using Dal.DbContext;
using Application.Configuration;
using Domain.Entities;
using EventinoApi.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using Dal.Configuration;

namespace EventinoApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication();
            ConfigureCors(services);

            ConfigureDbContext(services);
            ConfigureIdentity(services);

            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    IConfigurationSection googleAuthNSection =
                        Configuration.GetSection("Authentication:Google");

                    options.ClientId = googleAuthNSection["ClientId"];
                    options.ClientSecret = googleAuthNSection["ClientSecret"];
                    options.SignInScheme = IdentityConstants.ExternalScheme;
                });

            services.AddControllers();

            services.AddHttpContextAccessor();

            services.AddApplicationInsightsTelemetry();

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "EventinoApi", Version = "v1" }));

            services.AddBllServices(Configuration);

            services.AddDal();

            services.AddMapper();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EventinoApi v1"));
                app.UseCors();
            }
            else
            {
                app.UseHttpStatusCodeExceptionMiddleware();
            }


            app.UseStaticFiles();
            app.UseDefaultFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        private void ConfigureInMemoryDbContext(IServiceCollection services)
        {
            services.AddDbContext<EventinoDbContext>(opt => 
                opt.UseInMemoryDatabase("EventinoDb"));
        }

        private void ConfigureDbContext(IServiceCollection services)
        {
            var constring = Environment.GetEnvironmentVariable("DB_CONNSTRING") ?? Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<EventinoDbContext>(opt =>
                opt.UseNpgsql(constring));
        }

        private void ConfigureIdentity(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole<Guid>>(
                options => options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+/ ")
                .AddEntityFrameworkStores<EventinoDbContext>()
                .AddDefaultTokenProviders();
        }

        private void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().Build();
                });
            });
        }
    }
}
