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

        public void Salvar(Meta meta) => sessao.SaveOrUpdate(meta);

        public IList<Meta> Todas() => sessao.QueryOver<Meta>().List();

        public IList<Meta> Todas(long codigoOrgao) => sessao.QueryOver<Meta>().List();
    }
}