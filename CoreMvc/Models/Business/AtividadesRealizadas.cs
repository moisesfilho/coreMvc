using System.Collections.Generic;
using CoreMvc.Models.Repositories.Interfaces;
using CoreMvc.Models.Views;

namespace CoreMvc.Models.Business
{
    public class AtividadesRealizadas
    {
        private readonly IAtividades atividades;
        
        public AtividadesRealizadas(IAtividades atividades)
        {
            this.atividades = atividades;
        }

        public virtual List<AtividadeRealizadaView> Todas()
        {
            var atividades = this.atividades.Todas();

            var atividadesRealizadas = new List<AtividadeRealizadaView>();

            foreach (var meta in atividades)
            {
                atividadesRealizadas.Add(new AtividadeRealizadaView
                {
                    Nome = meta.Nome,
                    NomeCurto = meta.Nome.Length > 100 ? meta.Nome.Substring(0, 100) : meta.Nome,
                    Requisitos = meta.Requisitos,
                    Pontos = meta.Pontos
                });
            }

            return atividadesRealizadas;
        }
    }
}