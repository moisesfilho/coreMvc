using System.Collections.Generic;
using CoreMvc.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreMvc.Models.Repositories.Context
{
    public class CoreMvcDbContext : DbContext
    {
        public CoreMvcDbContext(DbContextOptions<CoreMvcDbContext> options) : base(options) { }

        public DbSet<Meta> Metas { get; set; }
        public DbSet<MetaRealizada> MetasRealizadas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Meta>().ToTable("meta").HasKey(m => m.Id);
            builder.Entity<MetaRealizada>().ToTable("metaRealizada").HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}