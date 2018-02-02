using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using CoreMvc.Models;
using CoreMvc.Models.Business;
using CoreMvc.Models.Entities;
using CoreMvc.Models.Repositories.Interfaces;
using CoreMvc.Models.Views;
using CoreMvc.Models.Viwes;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvc.Controllers
{
    public class AtividadesRealizadasController : Controller
    {
        private readonly AtividadesRealizadas atividades;
        public AtividadesRealizadasController(AtividadesRealizadas atividades)
        {
            this.atividades = atividades;
        }

        public IActionResult Diario()
        {
            var listaAtividadesRealizadas = atividades.Todas();
            return PartialView("_Diario", listaAtividadesRealizadas);
        }

        [HttpPost]
        public IActionResult Salvar(IEnumerable<AtividadeRealizadaView> atividadesRealizadasView)
        {
            var listaRequisitos = new StringBuilder();

            foreach (var atividade in atividadesRealizadasView)
            {
                listaRequisitos.AppendLine(atividade.Requisitos);
            }

            return Content(listaRequisitos.ToString());
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}