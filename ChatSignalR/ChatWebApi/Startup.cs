using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWebApi.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BLL.Services;
using BLL.Services.FileManagmentServices;
using BLL.Core;
using BLL.Services.UserServices;
using DAL.Models;

namespace ChatWebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddTransient<IFileServices, FileServices>();
            services.AddTransient<IFileManagmentServices, FileManagmentServices>();
            services.AddSingleton<UserIdentity>();
            services.AddTransient<IUserService, UserService>();
            services.AddDbContext<ChatDBContext>();

            services.AddSignalR();
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
}
