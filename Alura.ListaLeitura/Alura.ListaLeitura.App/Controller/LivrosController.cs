using Alura.ListaLeitura.App.Html.HtmlUtils;
using Alura.ListaLeitura.App.Repositorio;
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

        public string ParaLer()
        {
            var conteudo = HtmlUtils.CarregarHtml("para-ler");
            var repository = new LivroRepositorioCSV();

            foreach (var livro in repository.ParaLer.Livros)
            {
                conteudo = conteudo.Replace("#NOVO-ITEM#", $"<li>{livro.Titulo} - {livro.Autor}</li>#NOVO-ITEM#");
            }

            conteudo = conteudo.Replace("#NOVO-ITEM#", "");

            return conteudo;

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
