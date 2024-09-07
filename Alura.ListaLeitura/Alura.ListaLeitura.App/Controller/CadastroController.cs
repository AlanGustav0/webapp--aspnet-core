using Alura.ListaLeitura.App.Html.HtmlUtils;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Alura.ListaLeitura.App.Logica
{
    public class CadastroController
    {
        public string Incluir(Livro livro)
        {

            var repository = new LivroRepositorioCSV();
            repository.Incluir(livro);
            return "Livro adicionado com sucesso";
        }

        public IActionResult ExibeFormulario()
        {
            //var formulario = HtmlUtils.CarregarHtml("formulario");
            var html = new ViewResult { ViewName = "formulario" };
            return html;
        }

    }
}
