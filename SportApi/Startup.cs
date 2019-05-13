using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.SwaggerGeneration.Processors.Security;
using ProjectG05.Data;
using ProjectG05.Data.Repositories;
using ProjectG05.Models.Domain;
using SportApi.IRepos;
using SportApi.Repos;

namespace SportApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            var connection = @"Server=(localdb)\mssqllocaldb;Database=Project05ApiDatabase;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(connection));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddScoped<DataInitializer>();
            services.AddTransient<IAfbeelding, AfbeeldingRepository>();
            services.AddTransient<IActiviteit, ActiviteitRepository>();
            services.AddTransient<ICommentaar, CommentaarRepository>();
            services.AddScoped<ISessie, SessieRepository>();
            services.AddScoped<IGebruiker, GebruikerRepository>();
            services.AddScoped<IVideo, VideoRepository>();
            services.AddScoped<ILes, LesRepository>();
            services.AddTransient<ILesmateriaal, LesmateriaalRepository>();
            services.AddOpenApiDocument(c =>
            {
                c.DocumentName = "apidocs";
                c.Title = "Sport API";
                c.Version = "v1";
                c.Description = "The Sport API documentation description.";
            });
            services.AddCors(options => options.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DataInitializer dataInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors("AllowAllOrigins");
            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseMvc();

            app.UseSwaggerUi3();
            app.UseSwagger();
          //  dataInitializer.InitializeData().Wait();
        }
    }
}