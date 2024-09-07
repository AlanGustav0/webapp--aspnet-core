using System.IO;

namespace Alura.ListaLeitura.App.Html.HtmlUtils
{
    public class HtmlUtils
    {
        public static string CarregarHtml(string nomeArquivo)
        {
            var nomeCompletoArquivo = $"C:\\Users\\agv_2\\Development\\webapp--aspnet-core\\Alura.ListaLeitura\\Alura.ListaLeitura.App\\Html\\{nomeArquivo}.html";
            using (var arquivo = File.OpenText(nomeCompletoArquivo))
            {
                return arquivo.ReadToEnd();
            }
        }
    }
}
