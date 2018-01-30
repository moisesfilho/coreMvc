using System;

namespace CoreMvc.Models.Entities
{
    public class Atividade
    {
        public virtual long Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Requisitos { get; set; }
        public virtual decimal Pontos { get; set; }
        public bool Compartilhada;
        public bool Complexa;
    }
}