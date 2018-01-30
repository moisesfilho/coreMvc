using CoreMvc.Controllers;
using CoreMvc.Models.Repositories.Interfaces;
using NUnit.Framework;
using NSubstitute;
using CoreMvc.Models.Business;
using CoreMvc.Models.Views;
using System.Collections.Generic;

namespace Tests.Controllers
{
    public class AtividadesControllerTest
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void IndexSempreRetornaUmaView()
        {
            var atividadesRealizadas = Substitute.For<AtividadesRealizadas>((IAtividades) null);
            atividadesRealizadas.Todas().Returns(new List<AtividadeRealizadaView>());

            var atividadesController = new AtividadesRealizadasController(atividadesRealizadas);

            var result = atividadesController.Index();

            Assert.That(result, Is.Not.Null);
        }
    }
}