using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlaceholderAPI.Proxy.Extensions;
using PlaceholderAPI.Proxy.Interfaces;
using PlaceholderAPI.Proxy.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace PlaceholderAPI.Proxy
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
            services.AddSerilogLogger(Configuration);
            services.ConfigureHttpClients(Configuration.GetSection("PlaceholderAPI"));

            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IAlbumsService, AlbumsService>();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info {
                    Title = "Placeholder API",
                    Version = "v1",
                    Description = "PlaceholderAPI is a template for a REST API project based on .NET Core WebAPI"
                });
            });

            services.AddMvc(options =>
            {
                // Add XML Content Negotiation
                options.RespectBrowserAcceptHeader = true;
                options.ReturnHttpNotAcceptable = true;
            })
            .AddXmlSerializerFormatters()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json","Placeholder API");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
