using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Routing;
using System.Linq;
using Alura.ListaLeitura.App.Html.HtmlUtils;

namespace Alura.ListaLeitura.App
{
    public class LivrosLogica
    {
        public static Task Detalhes(HttpContext context)
        {
            var id = Convert.ToInt32(context.GetRouteValue("id"));
            var repository = new LivroRepositorioCSV();
            var livro = repository.Todos.First(l => l.Id == id);

            return context.Response.WriteAsync(livro.Detalhes());


        }

        

        public static Task ParaLer(HttpContext context)
        {
            var conteudo = HtmlUtils.CarregarHtml("para-ler");
            var repository = new LivroRepositorioCSV();

            foreach (var livro in repository.ParaLer.Livros)
            {
                conteudo = conteudo.Replace("#NOVO-ITEM#", $"<li>{livro.Titulo} - {livro.Autor}</li>#NOVO-ITEM#");
            }

            conteudo = conteudo.Replace("#NOVO-ITEM#", "");

            return context.Response.WriteAsync(conteudo);

        }

        

        public static Task Lendo(HttpContext context)
        {
            var repository = new LivroRepositorioCSV();
            return context.Response.WriteAsync(repository.Lendo.ToString());

        }

        public static Task Lidos(HttpContext context)
        {
            var repository = new LivroRepositorioCSV();
            return context.Response.WriteAsync(repository.Lidos.ToString());

        }
    }
}
