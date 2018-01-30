using System;
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
    public class Atividades : IAtividades
    {
        private readonly ConnectionFactory connection;
        public Atividades(ConnectionFactory context)
        {
            this.connection = context;
        }

        public void Salvar(Atividade meta)
        {

        }

        public IEnumerable<Atividade> Todas()
        {
            var listaMetas = new List<Atividade>();

            var cmd = connection.GetCommand();
            cmd.CommandText = "select * from sad.catalogo where rownum <= 10";

            using(var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var atividade = ReaderToAtividade(reader);
                    listaMetas.Add(atividade);
                }
            }

            return listaMetas;
        }

        public Atividade PorId(long id)
        {
            Atividade atividade = null;

            var cmd = connection.GetCommand();
            cmd.CommandText = "select * from sad.catalogo where SEQ_CATALOGO = :id";
            cmd.Parameters.Add(new OracleParameter("id", id));

            using(var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    atividade = ReaderToAtividade(reader);
                }
            }

            return atividade;
        }

        public IEnumerable<Atividade> Todas(long codigoOrgao)
        {
            var listaAtividades = new List<Atividade>();

            var cmd = connection.GetCommand();
            cmd.CommandText = "select * from sad.catalogo where COD_ORGAO_LOCAL = :codOrgaoLocal";
            cmd.Parameters.Add(new OracleParameter("codOrgaoLocal", codigoOrgao));

            using(var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var atividade = ReaderToAtividade(reader);
                    listaAtividades.Add(atividade);
                }
            }

            return listaAtividades;
        }

        private Atividade ReaderToAtividade(OracleDataReader reader)
        {
            var atividade = new Atividade
            {
                Id = Convert.ToInt64(reader["SEQ_CATALOGO"]),
                Nome = (string) reader["DSC_CATALOGO"],
                Requisitos = (string) reader["DSC_REQUISITOS"],
                Pontos = (decimal) reader["VLR_PONTO"],
                Compartilhada = ((string) reader["STA_META_COMPARTILHADA"]).ToLower().Equals("s"),
                Complexa = ((string) reader["STA_COMPLEXIDADE"]).ToLower().Equals("s")
            };

            return atividade;
        }
    }
}