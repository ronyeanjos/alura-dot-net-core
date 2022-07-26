using Alura.ListaLeitura.App.Html;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class CadastroController
    {
        public string Incluir(Livro livro)
        {
            var _repo = new LivroRepositorioCSV();
            _repo.Incluir(livro);
            return "O livro foi adicionado com sucesso.";
        }

        public static Task ExibeFormulario(HttpContext context)
        {
            var _html = HtmlUtils.CarregarHTML("formulario");
            return context.Response.WriteAsync(_html);
        }

        }

    }
}
