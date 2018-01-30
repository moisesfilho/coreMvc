using System.Linq;
using CoreMvc.Infra;
using CoreMvc.Models.Repositories;
using NUnit.Framework;

namespace Testes.Models.Repositories
{
    [TestFixture]
    public class AtividadesTest
    {
        private string connectionString = "Data Source=10.10.57.116:1521/dese;User Id=CONSEGWEB_SAD;Password=sad123";

        [Test]
        public void TodosRetornam10Atividades()
        {
            var connectionFactory = new ConnectionFactory(connectionString);

            var atividades = new Atividades(connectionFactory);

            var listaAtividade = atividades.Todas();

            Assert.That(listaAtividade.Count(), Is.EqualTo(10));
        }

        [Test]
        public void TodosPorCodigoDoOrgaoRetornam13Atividades()
        {
            var connectionFactory = new ConnectionFactory(connectionString);

            var atividades = new Atividades(connectionFactory);

            var listaAtividade = atividades.Todas(10511006);

            Assert.That(listaAtividade.Count(), Is.EqualTo(13));
        }

        [Test]
        public void AtividadesPorIdRetornaAtividade()
        {
            var connectionFactory = new ConnectionFactory(connectionString);

            var atividades = new Atividades(connectionFactory);

            var atividade = atividades.PorId(642);

            Assert.That(atividade, Is.Not.Null);
        }
    }
}