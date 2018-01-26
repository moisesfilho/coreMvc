using System.Collections.Generic;
using System.Linq;
using CoreMvc.Models.Entities;
using CoreMvc.Models.Repositories.Context;
using CoreMvc.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoreMvc.Models.Repositories
{
    public class Metas : IMetas
    {
        private readonly CoreMvcDbContext context;
        public Metas(CoreMvcDbContext context)
        {
            this.context = context;
        }

        public void Salvar(Meta meta)
        {
            context.Metas.Add(meta);
            context.SaveChanges();
        }

        public IEnumerable<Meta> Todas()
        {            
            return from meta in context.Metas select meta;
        }

        public void DeletarTodos()
        {
            //context.Database.ExecuteSqlCommand("DELETE FROM meta");
            //context.SaveChanges();
        }
    }
}