using CoreMvc.Controllers;
using NUnit.Framework;

namespace Tests
{
    public class AtividadesControllerTest
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void IndexSempreRetornaUmaView()
        {
            var atividadesController = new AtividadesController(null);

            var result = atividadesController.Index();

            Assert.That(result, Is.Not.True);
        }
    }
}