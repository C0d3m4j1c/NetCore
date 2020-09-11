using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AT.DataAccess.Data;
using AT.DataAccess.Repository;
using AT.IDataAccess.IRepository;
using AT.Model.Common;
using AT.Model.MapperProfiles;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace AT.WebApi
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
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo  { Title = "AT.WebApi", Version = "v1" });
                }
            );
            services.AddDbContext<ATDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IRepository<User>,UserRepository>();
            services.AddTransient<IRepository<Product>,ProductRepository>();
            services.AddTransient<IRepository<ProductType>,ProductTypeRepository>();
            var mappingConfig = new MapperConfiguration(mc => 
                {
                    mc.AddProfile(new UserUserForList());
                    mc.AddProfile(new UserForRegistrationUser());
                    mc.AddProfile(new ProductProductForList());
                    mc.AddProfile(new ProductForRegistrationProduct());
                    mc.AddProfile(new ProductForDeletionProduct());
                    mc.AddProfile(new ProductForUpdateProduct());
                    mc.AddProfile(new ProductTypeProductTypeForList());
                    mc.AddProfile(new ProductTypeForRegistrationProductType());
                    mc.AddProfile(new ProductTypeForUpdateProductType());
                    mc.AddProfile(new ProductTypeForDeletionProductType());
                }
            );

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
                {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AT.WebApi");
                });
        }
    }
}
