using BLL.Services.ClientServices;
using DAL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;

namespace ChatWebAPICache
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServices();

            services.AddMvc()
                    .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    });
        }



        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            app.UseMvc();

            new CacheService(serviceProvider.GetRequiredService<ChatDBContext>());
        }
    }


    static class ServiceExtention
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddDbContext<ChatDBContext>();
            services.AddTransient<IClientCacheService, ClientCacheService>();
            services.AddHttpClient();
        }
    }
}
