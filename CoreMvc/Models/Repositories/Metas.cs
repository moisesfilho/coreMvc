using System.Collections.Generic;
using CoreMvc.Models.Entities;
using CoreMvc.Models.Repositories.Interfaces;
using NHibernate;

namespace CoreMvc.Models.Repositoriess
{
    public class Metas : IMetas
    {
        private ISession sessao;

        public Metas(ISession sessao) => this.sessao = sessao;

        void IMetas.Salvar(Meta meta) => sessao.SaveOrUpdate(meta);

        IList<Meta> IMetas.Todas() => sessao.QueryOver<Meta>().List();
    }
}