using System;

namespace CoreMvc.Models.Views
{
    public class MetaRealizadaView
    {
        private float total;
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Requisitos { get; set; }
        public float Pontos { get; set; }
        public int Quantidade { get; set; }
        public float Total
        {
            get
            {
                if (total == 0L)
                    return Pontos * Quantidade;
                else
                    return total;
            }
            set
            {
                total = value;
            }
        }
        public string Detalhes { get; set; }
    }
}