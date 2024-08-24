using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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

            var routes = builderRoute.Build();

            app.UseRouter(routes);

            //app.Run(Roteamento);
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