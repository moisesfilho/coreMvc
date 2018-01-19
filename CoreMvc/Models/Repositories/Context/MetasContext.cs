using System.Collections.Generic;
using CoreMvc.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreMvc.Models.Repositories.Context
{
    public class MetasContext : DbContext
    {
        public MetasContext(DbContextOptions<MetasContext> options) : base(options) { }

        public DbSet<Meta> Metas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Meta>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}