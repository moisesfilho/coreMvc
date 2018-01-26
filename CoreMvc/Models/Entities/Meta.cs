using System;

namespace CoreMvc.Models.Entities
{
    public class Meta
    {
        public virtual long Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Requisitos { get; set; }
        public virtual float Pontos { get; set; }
    }
}