using System;
using FluentNHibernate.Mapping;

namespace CoreMvc.Models.Entities
{
    public class MetaMap : ClassMap<Meta>
    {
        public MetaMap()
        {
            Id(meta => meta.Id).GeneratedBy.GuidComb();
            Map(meta => meta.Nome).Not.Nullable();
            Map(meta => meta.Descricao);
            Map(meta => meta.Pontos);
        }
    }
}