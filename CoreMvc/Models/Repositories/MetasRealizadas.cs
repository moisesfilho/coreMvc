using System.Linq;
using System.Collections.Generic;
using CoreMvc.Models.Entities;
using CoreMvc.Models.Repositories.Context;
using CoreMvc.Models.Repositories.Interfaces;

namespace CoreMvc.Models.Repositories
{
    public class MetasRealizadas : IMetasRealizadas
    {
        public CoreMvcDbContext context { get; set; }
        public MetasRealizadas(CoreMvcDbContext coreMvcDbContext)
        {
            this.context = coreMvcDbContext;
        }

        public void Salvar(MetaRealizada metaRealizada)
        {
            context.MetasRealizadas.Add(metaRealizada);
            context.SaveChanges();
        }

        public IEnumerable<MetaRealizada> Todas()
        {
            return from m in context.MetasRealizadas select m;
        }
    }
}