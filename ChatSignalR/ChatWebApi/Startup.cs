using BLL.Core;
using BLL.Helpers;
using BLL.Services.FileManagmentServices;
using BLL.Services.UserServices;
using ChatWebApi.Hubs;
using DAL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            services.AddSignalR();
            services.AddMvc();
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSignalR(routes =>
            {
                routes.MapHub<NotificationHub>("/NotificationHub");
            });
            app.UseMvc();
        }

    }

    static class ServiceExtention
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<UserIdentity>();
            services.AddScoped<HttpHelpers>();

            services.AddTransient<IFileServices, FileServices>();
            services.AddTransient<IFileManagmentServices, FileManagmentServices>();
            services.AddTransient<IUserService, UserService>();
            services.AddDbContext<ChatDBContext>();
        }
    }
}