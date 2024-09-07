using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Mvc
{
    public class RoteamentoPadrao
    {
        public static Task TratamentoPadrao(HttpContext context)
        {
            var classe = Convert.ToString(context.GetRouteValue("classe"));
            var nomeMetodo = Convert.ToString(context.GetRouteValue("metodo"));

            var nomeClasse = $"Alura.ListaLeitura.App.{classe}Logica";

            var tipo = Type.GetType($"{nomeClasse}");
            var metodo = tipo.GetMethods().Where(m => m.Name == nomeMetodo).First();
            var requestDelegate = (RequestDelegate)Delegate.CreateDelegate(typeof(RequestDelegate), metodo);

            return requestDelegate.Invoke(context);
        }
    }
}
