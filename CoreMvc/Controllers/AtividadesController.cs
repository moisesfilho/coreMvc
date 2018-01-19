using System.Collections.Generic;
using System.Diagnostics;
using CoreMvc.Models;
using CoreMvc.Models.Entities;
using CoreMvc.Models.Repositories.Interfaces;
using CoreMvc.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvc.Controllers
{
    public class AtividadesController : Controller
    {
        private readonly IMetas metas;
        public AtividadesController(IMetas metas)
        {
            this.metas = metas;
        }

        public IActionResult Index()
        {
            var metas = this.metas.Todas();

            var listaDeAtividades = new List<Atividade>();

            foreach (var meta in metas)
            {
                listaDeAtividades.Add(new Atividade { Nome = meta.Nome, Descricao = meta.Descricao});
            }

            return View(listaDeAtividades);
        }

        public IActionResult CargarInicial()
        {
            var metas = new List<Meta>
            {
                new Meta { Nome = "Atividade 1", Descricao = "Descrição da Atividade 1", Pontos = 3},
                new Meta { Nome = "Atividade 2", Descricao = "Descrição da Atividade 2", Pontos = 1.1F},
                new Meta { Nome = "Atividade 3", Descricao = "Descrição da Atividade 3", Pontos = 10},
                new Meta { Nome = "Atividade 4", Descricao = "Descrição da Atividade 4", Pontos = 1.7F},
                new Meta { Nome = "Atividade 5", Descricao = "Descrição da Atividade 5", Pontos = 5}
            };

            foreach (var meta in metas)
            {
                this.metas.Salvar(meta);
            }
            
            return Content("Carregado!");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}