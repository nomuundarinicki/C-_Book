using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Book.Models;
using MySQL.Data.EntityFrameworkCore.Extensions;

namespace Book
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSession();
            services.AddDbContext<AuctionContext>(options => options.UseMySQL(Configuration["DBInfo:ConnectionString"]));
        }
        // public void Configure(IApplicationBuilder app, ILoggerFactory, IHostingEnvironment env)
        // {
        //     if( env.IsDevelopment() )
        //     {
        //         loggerFactory.AddConsole();
        //         app.UseDeveloperExceptionPage();
        //     }
        // }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc();
        }
    }
}