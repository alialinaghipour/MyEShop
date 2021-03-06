using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyEShop.Infrastructure.Application;
using MyEShop.PersistenceEF;
using MyEShop.PersistenceEF.Features;
using MyEShop.PersistenceEF.ProdcutGroups;
using MyEShop.PersistenceEF.ProductComments;
using MyEShop.PersistenceEF.ProductFeatures;
using MyEShop.PersistenceEF.ProductGalleries;
using MyEShop.PersistenceEF.Products;
using MyEShop.PersistenceEF.ProductSelectedGroups;
using MyEShop.PersistenceEF.ProductTags;
using MyEShop.Services.Features;
using MyEShop.Services.ProductComments;
using MyEShop.Services.ProductFeatures;
using MyEShop.Services.ProductGalleries;
using MyEShop.Services.ProductGroups;
using MyEShop.Services.ProductGroups.Contracts;
using MyEShop.Services.Products;
using MyEShop.Services.ProductSelectedGroups;
using MyEShop.Services.ProductTags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEShop.RestApi
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

            services.AddDbContext<EFDataContext>(options =>
            {
                options.UseSqlServer("Server =.; Database = MyEShopDB; Trusted_Connection = True; ");
            });

            services.AddScoped<UnitOfWork, EFUnitOfWork>();

            services.AddScoped<ProductGroupRepository, EFProductGroupRepository>();
            services.AddScoped<ProductGroupServices, ProductGroupAppServices>();

            services.AddScoped<ProductServices, ProductAppServices>();
            services.AddScoped<ProductRepository, EFProductRepository>();

            services.AddScoped<ProductSelectedGroupServices, ProductSelectedGroupAppServices>();
            services.AddScoped<ProductSelectedGroupRepository, EFProductSelectedGroupRepository>();

            services.AddScoped<ProductGalleryRepository, EFProductGalleryRepository>();
            services.AddScoped<ProductGalleryServices, ProductGalleryAppServices>();

            services.AddScoped<ProductTagRepository, EFProductTagRepository>();

            services.AddScoped<FeatureRepository, EFFeatureRepository>();
            services.AddScoped<FeatureServices, FeatureAppServices>();

            services.AddScoped<ProductFeatureServices, ProductFeatureAppServices>();
            services.AddScoped<ProductFeatureRepository, EFProductFeatureRepository>();

            services.AddScoped<ProductCommentServices, ProductCommnetAppServices>();
            services.AddScoped<ProductCommentRepository, EFProductCommentRepository>();

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
