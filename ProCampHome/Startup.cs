using System;
using System.IO;
using System.Xml.XPath;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using ProCampHome.Models;
using ProCampHome.Models.Responses;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ProCampHome
{
    /// <summary>
    /// Startup the project.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// The hosting env.
        /// </summary>
        private readonly IHostingEnvironment _hostingEnv;

        /// <summary>
        /// The API name.
        /// </summary>
        private readonly string ApiName = "ProCampHomeApi";

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnv)
        {
            _hostingEnv = hostingEnv;
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(opts =>
            {
                opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddSwaggerGen(options =>
            {
                SetupSwagger(options, ApiName, _hostingEnv);
            });

            Mapper.Initialize(c =>
            {
                c.CreateMissingTypeMaps = true;
                c.CreateMap<Customer, CustomersResponse>();
            });
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", ApiName));
        }

        /// <summary>
        /// Setups the swagger.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="apiName">Name of the API.</param>
        /// <param name="hostingEnv">The hosting env.</param>
        private static void SetupSwagger(SwaggerGenOptions options, string apiName, IHostingEnvironment hostingEnv)
        {
            options.SwaggerDoc("v1", new Info
            {
                Title = apiName,
                Description = $"{apiName} (ASP.NET Core 2.2)",
                Version = "1.0.BUILD_NUMBER"
            });

            options.DescribeAllEnumsAsStrings();

            var comments =
                new XPathDocument($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{hostingEnv.ApplicationName}.xml");
            options.OperationFilter<XmlCommentsOperationFilter>(comments);

            options.AddSecurityDefinition("Bearer", new ApiKeyScheme()
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = "header",
                Type = "apiKey"
            });

            options.IgnoreObsoleteActions();
        }
    }
}
