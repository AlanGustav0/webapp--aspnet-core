using Alura.ListaLeitura.App.Html.HtmlUtils;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class CadastroLogica
    {
        public static Task Incluir(HttpContext context)
        {
            var livro = new Livro()
            {
                Titulo = context.Request.Form["titulo"].First(),
                Autor = context.Request.Form["autor"].First()
            };
            var repository = new LivroRepositorioCSV();
            repository.Incluir(livro);
            return context.Response.WriteAsync("Livro adicionado com sucesso");
        }

        public static Task ExibeFormulario(HttpContext context)
        {
            var formulario = HtmlUtils.CarregarHtml("formulario");

            return context.Response.WriteAsync(formulario);
        }

        public static Task NovoLivro(HttpContext context)
        {
            var livro = new Livro()
            {
                Titulo = context.GetRouteValue("nome").ToString(),
                Autor = context.GetRouteValue("autor").ToString()
            };
            var repository = new LivroRepositorioCSV();
            repository.Incluir(livro);
            return context.Response.WriteAsync("Livro adicionado com sucesso");
        }
    }
}
