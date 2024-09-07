using Alura.ListaLeitura.App.Html.HtmlUtils;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Alura.ListaLeitura.App.Logica
{
    public class LivrosController : Controller
    {
        public string Detalhes(int id)
        {
            var repository = new LivroRepositorioCSV();
            var livro = repository.Todos.First(l => l.Id == id);

            return livro.Detalhes();

        }

        public IActionResult ParaLer()
        {
            var repository = new LivroRepositorioCSV();

            ViewBag.Livros = repository.ParaLer.Livros;

            return View("lista");

        }

        public IActionResult Lendo()
        {
            var repository = new LivroRepositorioCSV();
            ViewBag.Livros = repository.Lendo.Livros;
            return View("lista");

        }

        public IActionResult Lidos()
        {
            var repository = new LivroRepositorioCSV();
            ViewBag.Livros = repository.Lidos.Livros;
            return View("lista");
        }
    }
}
