using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CoreMvc.Models;
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
            var listaDeAtividades = new List<Atividade>
            {
                new Atividade { Nome = "Atividade 1", Descricao = "Descrição da Atividade 1", Pontos = 3, Quantidade = 3 },
                new Atividade { Nome = "Atividade 2", Descricao = "Descrição da Atividade 2", Pontos = 1.1F, Quantidade = 4 },
                new Atividade { Nome = "Atividade 3", Descricao = "Descrição da Atividade 3", Pontos = 10, Quantidade = 1 },
                new Atividade { Nome = "Atividade 4", Descricao = "Descrição da Atividade 4", Pontos = 1.7F, Quantidade = 5 },
                new Atividade { Nome = "Atividade 5", Descricao = "Descrição da Atividade 5", Pontos = 5, Quantidade = 2 }
            };

            return View(listaDeAtividades);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}