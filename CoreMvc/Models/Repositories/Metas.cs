using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using CoreMvc.Infra;
using CoreMvc.Models.Entities;
using CoreMvc.Models.Repositories.Context;
using CoreMvc.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoreMvc.Models.Repositories
{
    public class Metas : IMetas
    {
        private readonly ConnectionFactory connection;
        public Metas(ConnectionFactory context)
        {
            this.connection = context;
        }

        public void Salvar(Meta meta)
        {
            
        }

        public IEnumerable<Meta> Todas()
        {
            var listaMetas = new List<Meta>();

            var cmd = connection.GetCommand();
            cmd.CommandText = "select * from sad.catalogo where rownum <= 10";

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var meta = new Meta { Nome = reader["DSC_CATALOGO"].ToString() };
                    listaMetas.Add(meta);
                }                
            }

            return listaMetas;
        }

        public void DeletarTodos()
        {
            //context.Database.ExecuteSqlCommand("DELETE FROM meta");
            //context.SaveChanges();
        }
    }
}