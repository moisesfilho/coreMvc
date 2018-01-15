using System;

namespace CoreMvc.Models.Views
{
    public class Atividade
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public float Pontos { get; set; }
        public int Quantidade { get; set; }
        public float Total => Quantidade * Pontos;
        public string Detalhes { get; set; }
    }
}