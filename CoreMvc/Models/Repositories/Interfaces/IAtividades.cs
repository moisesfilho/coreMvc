using System.Collections.Generic;
using CoreMvc.Models.Entities;

namespace CoreMvc.Models.Repositories.Interfaces
{
    public interface IAtividades
    {
         IEnumerable<Atividade> Todas();
         IEnumerable<Atividade> Todas(long codigoOrgao);
         Atividade PorId(long id);
    }
}