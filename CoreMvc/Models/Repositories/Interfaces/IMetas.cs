using System.Collections.Generic;
using CoreMvc.Models.Entities;

namespace CoreMvc.Models.Repositories.Interfaces
{
    public interface IMetas
    {
        IList<Meta> Todas();
        IList<Meta> Todas(long codigoOrgao);
        void Salvar(Meta meta);
    }
}