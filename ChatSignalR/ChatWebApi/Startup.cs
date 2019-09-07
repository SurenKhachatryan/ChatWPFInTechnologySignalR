using BLL.Core;
using BLL.Helpers;
using BLL.Services.FileManagmentServices;
using BLL.Services.UserServices;
using ChatWebApi.AttributeFilters;
using ChatWebApi.Hubs;
using DAL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace ChatWebApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            AppConfigSettings.CacheUrl = _configuration.GetSection("CacheSettings:CacheUrl").Value;

            services.AddServices();

            services.AddDbContext<ChatDBContext>(config =>
                                                 config
                                                 .UseSqlServer(_configuration
                                                 .GetConnectionString("ChatDBContextOffice")));

            services.AddSignalR();

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(AppExceptionFilter));
            }).AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

        }


        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            app.UseSignalR(routes =>
            {
                routes.MapHub<NotificationHub>("/NotificationHub");
            });

            new Services(serviceProvider.GetService<HttpHelpers>());

            app.UseMvc();
        }

    }

    static class ServiceExtention
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<UserIdentity>();
            services.AddScoped<HttpHelpers>();
            services.AddTransient<AppException>();
            services.AddHttpClient();

            services.AddTransient<IFileServices, FileServices>();
            services.AddTransient<IFileManagmentServices, FileManagmentServices>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}