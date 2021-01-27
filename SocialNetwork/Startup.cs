using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SocialNetworkLibrary.Repositories.Posts;
using SocialNetworkLibrary.Repositories.Users;

namespace SocialNetwork
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
            services.AddControllers().AddNewtonsoftJson();

            services.AddSwaggerGen(e =>
            {
                e.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "SocialNetwork API",
                    Description = "A SocialNetwork school project",
                    TermsOfService = new Uri("https://example.org/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Richard Gustavsson",
                        Email = "Retg94@gmail.com",
                        Url = new Uri("https://twitter.com/Richard")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "This is the license name",
                        Url = new Uri("https://example.com")
                    }                                    
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                var xmlFileTwo = $"SocialNetworkLibrary.xml";
                var xmlPathTwo = Path.Combine(AppContext.BaseDirectory, xmlFileTwo);
                e.IncludeXmlComments(xmlPath);
                e.IncludeXmlComments(xmlPathTwo);
            });

            services.AddSingleton<IUserRepository, SqlUserRepository>();
            services.AddSingleton<IPostRepository, SqlPostRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(e =>
                {
                    e.SwaggerEndpoint("/swagger/v1/swagger.json", "SocialNetwork API V1");
                }
            );

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
