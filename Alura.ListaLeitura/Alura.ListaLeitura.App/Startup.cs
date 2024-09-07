using Alura.ListaLeitura.App.Mvc;
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
            var builder = new RouteBuilder(app);

            builder.MapRoute("{classe}/{metodo}", RoteamentoPadrao.TratamentoPadrao);

            var routes = builder.Build();

            app.UseRouter(routes);
        }

    }
}