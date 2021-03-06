using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Image_Loader.Data;
using Image_Loader.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Image_Loader
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<ImageContext>(options=> options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnectionString")));
            services.AddCors(options => options.AddDefaultPolicy(builder => builder.AllowAnyHeader().AllowAnyHeader().AllowAnyOrigin()));
            services.AddScoped<IRepository<Image>, ImageRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.Use(async (context, next) =>

            {

                await next();

                if (context.Response.StatusCode == 404 && !System.IO.Path.HasExtension(context.Request.Path.Value))

                {

                    context.Request.Path = "/index.html";

                    await next();

                }

            });

            app.UseDefaultFiles();

            app.UseStaticFiles();
            app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
