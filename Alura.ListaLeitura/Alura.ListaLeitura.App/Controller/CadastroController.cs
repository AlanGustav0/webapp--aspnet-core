using Alura.ListaLeitura.App.Html.HtmlUtils;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;

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

        public string ExibeFormulario()
        {
            var formulario = HtmlUtils.CarregarHtml("formulario");

            return formulario;
        }

    }
}
