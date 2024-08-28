using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }
        public void Configure(IApplicationBuilder app)
        {
            var builderRoute = new RouteBuilder(app);

            builderRoute.MapRoute("Livros/ParaLer", LivrosParaLer);
            builderRoute.MapRoute("Livros/Lendo", LivrosLendo);
            builderRoute.MapRoute("Livros/Lidos", LivrosLidos);
            builderRoute.MapRoute("Livros/Lidos", LivrosLidos);
            builderRoute.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", NovoLivroParaLer);
            builderRoute.MapRoute("Livros/Detalhes/{id:int}", ExibeDetalhes);
            builderRoute.MapRoute("Cadastro/NovoLivro", ExibirFormulario);
            builderRoute.MapRoute("Cadastro/Incluir", ProcessaFormulario);


            var routes = builderRoute.Build();

            app.UseRouter(routes);

            //app.Run(Roteamento);
        }

        private Task ProcessaFormulario(HttpContext context)
        {
            var livro = new Livro()
            {
                Titulo = context.Request.Query["titulo"].First(),
                Autor = context.Request.Query["autor"].First()
            };
            var repository = new LivroRepositorioCSV();
            repository.Incluir(livro);
            return context.Response.WriteAsync("Livro adicionado com sucesso");
        }

        private Task ExibirFormulario(HttpContext context)
        {
            var formulario = @"
                <html>
                    <form action='/Cadastro/Incluir'>
                        <input name='titulo' />
                        <input name='autor' />
                        <button>Gravar</button>
                    </form>
                </html>";

            return context.Response.WriteAsync(formulario);
        }

        private Task ExibeDetalhes(HttpContext context)
        {
            var id = Convert.ToInt32(context.GetRouteValue("id"));
            var repository = new LivroRepositorioCSV();
            var livro = repository.Todos.First(l => l.Id == id);

            return context.Response.WriteAsync(livro.Detalhes());

            
        }

        private Task NovoLivroParaLer(HttpContext context)
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

        public Task Roteamento(HttpContext context)
        {
            var repository = new LivroRepositorioCSV();

            var validPaths = new Dictionary<string, RequestDelegate>()
            {
                { "/Livros/ParaLer", LivrosParaLer },
                { "/Livros/Lendo", LivrosLendo },
                { "/Livros/Lidos", LivrosLidos },
            };

            if(validPaths.ContainsKey(context.Request.Path))
            {
                var method = validPaths[context.Request.Path];
                return method.Invoke(context);
            }


            context.Response.StatusCode = 404;
            return context.Response.WriteAsync("Caminho não encontrado!");

        }

        public Task LivrosParaLer(HttpContext context)
        {
            var repository = new LivroRepositorioCSV();
            return context.Response.WriteAsync(repository.ParaLer.ToString());
 
        }

        public Task LivrosLendo(HttpContext context)
        {
            var repository = new LivroRepositorioCSV();
            return context.Response.WriteAsync(repository.Lendo.ToString());

        }

        public Task LivrosLidos(HttpContext context)
        {
            var repository = new LivroRepositorioCSV();
            return context.Response.WriteAsync(repository.Lidos.ToString());

        }
    }
}