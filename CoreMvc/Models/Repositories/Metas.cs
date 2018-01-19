using System.Collections.Generic;
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

        IList<Meta> IMetas.Todas()
        {
            throw new System.NotImplementedException();
        }
    }
}