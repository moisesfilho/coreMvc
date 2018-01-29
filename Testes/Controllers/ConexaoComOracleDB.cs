using System;
using System.Data.OracleClient;
using NUnit.Framework;

namespace Testes.Controllers
{
    public class ConexaoComOracleDB
    {
        [Test]
        public void TesteDeConexao()
        {
            using (var connection = new OracleConnection("Data Source=10.10.57.116:1521/dese;User Id=CONSEGWEB_SAD;Password=sad123"))
            {
                connection.Open();

                var cmd = connection.CreateCommand();
                cmd.CommandText = "select * from sad.catalogo where rownum <= 10";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string col = reader["DSC_CATALOGO"].ToString();
                }                
            }    
        }
    }
}