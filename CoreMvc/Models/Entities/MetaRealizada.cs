namespace CoreMvc.Models.Entities
{
    public class MetaRealizada
    {
        public long Id { get; internal set; }
        public Atividade Meta { get; set; }
        public float QuantidadeRealizada { get; set; }
        public float Total { get; set; }
        
    }
}