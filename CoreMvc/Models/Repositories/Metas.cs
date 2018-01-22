using System.Collections.Generic;
using System.Linq;
using CoreMvc.Models.Entities;
using CoreMvc.Models.Repositories.Context;
using CoreMvc.Models.Repositories.Interfaces;

namespace CoreMvc.Models.Repositories
{
    public class Metas : IMetas
    {
        private readonly MetasContext context;
        public Metas(MetasContext context)
        {
            this.context = context;
        }

        void IMetas.Salvar(Meta meta)
        {
            context.Metas.Add(meta);
        }

        IEnumerable<Meta> IMetas.Todas()
        {
            return from m in context.Metas select m;
        }
    }
}