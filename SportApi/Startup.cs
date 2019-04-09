using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(connection));

            //services.AddScoped<DataInitializer>();
            
            services.AddTransient<IAfbeelding, AfbeeldingRepository>();
            services.AddTransient<ICommentaar, CommentaarRepository>();

            services.AddTransient<ISessie, SessieRepository>();


            services.AddTransient<IGebruiker, GebruikerRepository>();
            services.AddTransient<ILes, LesRepository>();
            services.AddTransient<ILesmateriaal, LesmateriaalRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env/* DataInitializer dataInitializer*/)
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
            //dataInitializer.InitializeData().Wait();
        }
    }
}
