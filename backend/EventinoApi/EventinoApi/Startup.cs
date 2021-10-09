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

            ConfigureInMemoryDbContext(services);
            ConfigureIdentity(services);

            services.AddControllers();

            services.AddHttpContextAccessor();

            services.AddApplicationInsightsTelemetry();

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "EventinoApi", Version = "v1" }));

            services.AddBllServices(Configuration);
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

        // TODO: Add connection string
        private void ConfigureDbContext(IServiceCollection services)
        {
            services.AddDbContext<EventinoDbContext>(opt =>
                opt.UseNpgsql("connection string"), 
                    ServiceLifetime.Transient);
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
