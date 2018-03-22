using System.Collections.Generic;
using CoreMvc.Models.Entities;

namespace CoreMvc.Models.Repositories.Interfaces
{
    public interface IMetas
    {
         IList<Meta> Todas();
         void Salvar(Meta meta);
    }
}