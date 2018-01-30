using System.Collections.Generic;
using CoreMvc.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreMvc.Models.Repositories.Context
{
    public class CoreMvcDbContext : DbContext
    {
        public CoreMvcDbContext(DbContextOptions<CoreMvcDbContext> options) : base(options) { }

        public DbSet<Atividade> Metas { get; set; }
        public DbSet<MetaRealizada> MetasRealizadas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("SAD");

            builder.Entity<Atividade>().ToTable("CATALOGO");
            builder.Entity<Atividade>().HasKey(m => m.Id);
            builder.Entity<Atividade>().Property(m => m.Id).HasColumnName("SEQ_CATALOGO");
            builder.Entity<Atividade>().Property(m => m.Nome).HasColumnName("DSC_CATALOGO");
            builder.Entity<Atividade>().Property(m => m.Pontos).HasColumnName("VLR_PONTO");
            builder.Entity<Atividade>().Property(m => m.Requisitos).HasColumnName("DSC_REQUISITOS"); 

            //builder.Entity<MetaRealizada>().ForOracleToTable("metaRealizada").HasKey(m => m.Id);
            
            base.OnModelCreating(builder);
        }
    }
}