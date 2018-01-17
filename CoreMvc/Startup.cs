using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoreMvc.Models.Entities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            services.AddSingleton<NHibernate.ISessionFactory>(factory =>
            {
                return Fluently
                    .Configure()
                    .Database(
                        SQLiteConfiguration.Standard
                        .UsingFile("aplicacoes.db")
                    )
                    // .Database(() =>
                    // {
                    //     return FluentNHibernate.Cfg.Db.MsSqlConfiguration
                    //         .MsSql2012
                    //         .ShowSql()
                    //         .ConnectionString("");
                    // })
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<MetaMap>())
                    .ExposeConfiguration(BuildSchema)
                    .BuildSessionFactory();
            });

            services.AddScoped<NHibernate.ISession>(factory =>
                factory
                .GetServices<NHibernate.ISessionFactory>()
                .First()
                .OpenSession()
            );

        }

        private static void BuildSchema(Configuration config)
        {
            // delete the existing db on each run
            if (File.Exists("aplicacoes.db"))
                File.Delete("aplicacoes.db");

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config).Create(false, true);
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