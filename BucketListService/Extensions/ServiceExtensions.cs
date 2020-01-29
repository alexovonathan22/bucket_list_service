using Contracts;
using Repository;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace BucketListService.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(opts =>
            {
                opts.AddPolicy("CorsPolicy", 
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        //configure an IIS integration which will help us with the IIS deployment
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        //service for our connString
 
 
        public static void ConfigureMSSqlContext(this IServiceCollection services, IConfiguration Configuration)
        {
            //var connectionString = Configuration.GetConnectionString("sqlConnection");
            services.AddDbContext<RepositoryContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("sqlConnection")));
        }

        //ConfigureRepositoryWrapper
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
}

}
