using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blog.Business;
using Blog.Business.Contracts;
using Blog.Data;
using Blog.Data.Contracts;
using Blog.Data.EF;

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

namespace Blog.Api
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
            // Register DbContext and Provide Connection String
            var blogConnectionString = Configuration.GetConnectionString("BlogConnectionString");
            services.AddDbContext<BlogContext>(options => options.UseSqlServer(blogConnectionString));

            // AutoMapper Configuration
            services.AddAutoMapper(typeof(Startup));

            // DI Configurations - Business Layer
            services.AddScoped<IPostsBusiness, PostsBusiness>();
            services.AddScoped<ITagsBusiness, TagsBusiness>();
            services.AddScoped<ICategoriesBusiness, CategoriesBusiness>();

            // DI Configurations - Data Access Layer
            services.AddScoped<IPostsRepository, PostsRepository>();
            services.AddScoped<ITagsRepository, TagsRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Blog.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
