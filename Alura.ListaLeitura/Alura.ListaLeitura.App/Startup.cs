using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(LivrosParaLer);
        }

        public Task LivrosParaLer(HttpContext context)
        {
            var repository = new LivroRepositorioCSV();
            return context.Response.WriteAsync(repository.ParaLer.ToString());
 
        }
    }
}