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
            using (var _db = new OracleConnection("User Id=myUser;Password=myPassword;Data Source=MyOracleConnection"))
            {
                Console.WriteLine("Open connection...");
                _db.Open();
                Console.WriteLine(  "Connected to:" +_db.ServerVersion);
                Console.WriteLine("\r\nDone. Press key for exit");
                Console.ReadKey();
            }    
        }
    }
}