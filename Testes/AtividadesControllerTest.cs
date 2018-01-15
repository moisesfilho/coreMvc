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
            var atividadesController = new AtividadesControllerTest();

            var result = atividadesController.Index();

            Assert.That(result, IsNot.Null);
        }
    }
}