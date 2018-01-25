using System.Collections.Generic;
using CoreMvc.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreMvc.Models.Repositories.Context
{
    public class CoreMvcDbContext : DbContext
    {
        public CoreMvcDbContext(DbContextOptions<CoreMvcDbContext> options) : base(options) { }

        public DbSet<Meta> Metas { get; set; }
        public DbSet<MetaRealizada> MetasRealizadas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // builder.Entity<Meta>().Property(m => m.Nome).HasColumnName("DSC_CATALOGO");            
            // builder.Entity<Meta>().HasKey(m => m.Id).HasName("SEQ_CATALOGO");
            // // builder.Entity<Meta>()
            // //        .Property(i => i.Id)
            // //        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
            // //        .HasColumnName("SEQ_CATALOGO");
            // builder.Entity<Meta>().ToTable("CATALOGO");

            builder.Entity<MetaRealizada>().ToTable("metaRealizada").HasKey(m => m.Id);
            
            base.OnModelCreating(builder);
        }
    }
}