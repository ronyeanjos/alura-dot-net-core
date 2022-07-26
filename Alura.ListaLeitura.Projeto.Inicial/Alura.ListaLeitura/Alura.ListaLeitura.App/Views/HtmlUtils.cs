using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Alura.ListaLeitura.App.Html
{
    public class HtmlUtils
    {
        public static string CarregarHTML(string nomeArquivo)
        {
            var _nomeCompletoArquivo = $"Html/{nomeArquivo}.html";
            using (var _arquivo = File.OpenText(_nomeCompletoArquivo))
            {
                return _arquivo.ReadToEnd();
            }
        }
    }
}
