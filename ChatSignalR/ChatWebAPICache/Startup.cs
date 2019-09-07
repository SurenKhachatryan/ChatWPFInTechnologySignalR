using BLL.Services.CacheServices;
using DAL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;

namespace ChatWebAPICache
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
            services.AddServices();

            services.AddDbContext<ChatDBContext>(config =>
                                                 config
                                                 .UseSqlServer(_configuration
                                                 .GetConnectionString("ChatDBContextOffice")));

            services.AddMvc()
                    .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    });
        }



        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            new CacheService(serviceProvider.GetService<ChatDBContext>());

            app.UseMvc();
        }
    }


    static class ServiceExtention
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IClientCacheService, ClientCacheService>();
            services.AddHttpClient();
        }
    }
}
