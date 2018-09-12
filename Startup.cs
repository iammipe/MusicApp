using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using mnRelations.Services;
using mnRelations.Models;
using Microsoft.EntityFrameworkCore;
using mnRelations.Data;
using mnRelations.DataSql;
using System;
using System.IO;
// Requires NuGet package
// Microsoft.Extensions.Configuration.Json
using Microsoft.Extensions.Configuration;

namespace mnRelations
{
    public class Startup
    {

        public IConfigurationRoot Configuration { get; }

        public Startup(IConfiguration configuration)
        {
        }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<MusicDBContext>(
                options => options.UseSqlServer(
                    @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Music;Integrated Security=True;Connect Timeout=30;"
                ));

            services.AddScoped<IMusic, SqlMusicData>();
            services.AddScoped<IPlaylist, SqlPlaylistsData>();
            services.AddScoped<ISongs, SqlSongsData>();
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
