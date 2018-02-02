using CoreMvc.Infra;
using CoreMvc.Models.Business;
using CoreMvc.Models.Repositories;
using CoreMvc.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreMvc
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true; // false by default
            });
            
            var connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddTransient<ConnectionFactory>(_ => new ConnectionFactory(connectionString));
            // services.AddDbContext<CoreMvcDbContext>(options => options.UseOracle(conString));
            services.AddScoped<AtividadesRealizadas>();
            services.AddScoped<IAtividades, Atividades>();
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");
            });
        }
    }
}