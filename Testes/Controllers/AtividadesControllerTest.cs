using CoreMvc.Controllers;
using NUnit.Framework;

namespace Tests.Controllers
{
    public class AtividadesControllerTest
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void IndexSempreRetornaUmaView()
        {
            var atividadesController = new MetasRealizadasController(null);

            var result = atividadesController.Index();

            Assert.That(result, Is.Not.True);
        }
    }
}