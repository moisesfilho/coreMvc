using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using CoreMvc.Models;
using CoreMvc.Models.Entities;
using CoreMvc.Models.Repositories.Interfaces;
using CoreMvc.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvc.Controllers
{
    public class MetasRealizadasController : Controller
    {
        private readonly IMetas metas;
        public MetasRealizadasController(IMetas metas)
        {
            this.metas = metas;
        }

        public IActionResult Index()
        {
            var metas = this.metas.Todas();

            var metasRealizadas = new List<MetaRealizadaView>();

            foreach (var meta in metas)
            {
                metasRealizadas.Add(new MetaRealizadaView { Nome = meta.Nome, Descricao = meta.Descricao, Pontos = meta.Pontos });
            }

            return View(metasRealizadas);
        }

        [HttpPost]
        public IActionResult Salvar(IEnumerable<MetaRealizadaView> metasRealizadasView)
        {
            var teste = new StringBuilder();

            foreach (var meta in metasRealizadasView)
            {
                teste.AppendLine(meta.Descricao);
            }

            return Content(teste.ToString());
        }

        public IActionResult ResetDados()
        {
            this.metas.DeletarTodos();

            var metas = new List<Meta>
            {
                new Meta { Nome = "Atividade 1", Descricao = "Descrição da Atividade 1", Pontos = 3 },
                new Meta { Nome = "Atividade 2", Descricao = "Descrição da Atividade 2", Pontos = 1.1F },
                new Meta { Nome = "Atividade 3", Descricao = "Descrição da Atividade 3", Pontos = 10 },
                new Meta { Nome = "Atividade 4", Descricao = "Descrição da Atividade 4", Pontos = 1.7F },
                new Meta { Nome = "Atividade 5", Descricao = "Descrição da Atividade 5", Pontos = 5 }
            };

            foreach (var meta in metas)
            {
                this.metas.Salvar(meta);
            }

            return Content("Carregado!");
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