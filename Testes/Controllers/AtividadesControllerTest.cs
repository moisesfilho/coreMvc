using CoreMvc.Controllers;
using CoreMvc.Models.Repositories.Interfaces;
using NUnit.Framework;
using NSubstitute;

namespace Tests.Controllers
{
    public class AtividadesControllerTest
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void IndexSempreRetornaUmaView()
        {
            var metas = Substitute.For<IMetas>();

            var atividadesController = new MetasRealizadasController(metas);

            var result = atividadesController.Index();

            Assert.That(result, Is.Not.Null);
        }
    }
}