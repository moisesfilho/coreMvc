using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace CoreMvc
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
            services.AddMvc();

            // services.AddSingleton<NHibernate.ISessionFactory>(factory =>
            // {
            //     return Fluently
            //         .Configure()
            //         .Database(() =>
            //         {
            //             return FluentNHibernate.Cfg.Db.MsSqlConfiguration
            //                 .MsSql2012
            //                 .ShowSql()
            //                 .ConnectionString("");
            //         })
            //         .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Model>())
            //         .BuildSessionFactory();
            // });

            // services.AddScoped<NHibernate.ISession>(factory =>
            //     factory
            //     .GetServices<NHibernate.ISessionFactory>()
            //     .First()
            //     .OpenSession()
            // );

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
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}