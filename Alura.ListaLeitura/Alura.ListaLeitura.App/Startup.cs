using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
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

            builderRoute.MapRoute("Livros/ParaLer", LivrosLogica.LivrosParaLer);
            builderRoute.MapRoute("Livros/Lendo", LivrosLogica.LivrosLendo);
            builderRoute.MapRoute("Livros/Lidos", LivrosLogica.LivrosLidos);
            builderRoute.MapRoute("Livros/Lidos", LivrosLogica.LivrosLidos);
            builderRoute.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", CadastroLogica.NovoLivroParaLer);
            builderRoute.MapRoute("Livros/Detalhes/{id:int}", LivrosLogica.ExibeDetalhes);
            builderRoute.MapRoute("Cadastro/NovoLivro", CadastroLogica.ExibirFormulario);
            builderRoute.MapRoute("Cadastro/Incluir", CadastroLogica.ProcessaFormulario);


            var routes = builderRoute.Build();

            app.UseRouter(routes);
        }

    }
}