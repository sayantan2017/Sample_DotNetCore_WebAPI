using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sample_DotNetCore_WebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_DotNetCore_WebAPI
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
            //Sayantan
            //Adding cors to avoid cors issue in local FE
            services.AddCors();
            //Sayantan
            //Register API Controller Service- In the 'Startup.cs' file we have to register the 'AddController' service.
            services.AddControllers();
            //Sayantan
            //Registering Swegger in the Project
            services.AddSwaggerGen();
            //Sayantan
            //Register 'Project_DBContext' into the dependency services.
            services.AddDbContext<Project_DBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ProjectDbConnection"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Sayantan
            //Adding cors to avoid cors issue in local FE
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:3000"));
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            //Sayantan
            //Endpoint Routing Middleware -
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //Sayantan
            //Register Swagger Middleware(Line 56,57)
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample_DotNetCore_WebAPI");
            });
            app.UseStaticFiles();
            app.UseCors("ReactJSDomain");
        }
    }
}
