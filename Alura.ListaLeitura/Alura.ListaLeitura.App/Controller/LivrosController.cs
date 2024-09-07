using Alura.ListaLeitura.App.Html.HtmlUtils;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Alura.ListaLeitura.App.Logica
{
    public class LivrosController
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

            var html = new ViewResult { ViewName = "lista" };

            return html;

        }

        public string Lendo()
        {
            var repository = new LivroRepositorioCSV();
            return repository.Lendo.ToString();

        }

        public string Lidos()
        {
            var repository = new LivroRepositorioCSV();
            return repository.Lidos.ToString();

        }
    }
}
