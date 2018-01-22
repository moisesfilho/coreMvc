using System.Collections.Generic;
using CoreMvc.Models.Entities;

namespace CoreMvc.Models.Repositories.Interfaces
{
    public interface IMetasRealizadas
    {
         void Salvar(MetaRealizada metaRealizada);
         IEnumerable<MetaRealizada> Todas();
    }
}