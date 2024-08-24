using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(Roteamento);
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