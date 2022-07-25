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
    public class CadastroLogica
    {
        public static Task ProcessaFormulario(HttpContext context)
        {
            var _novoLivro = new Livro()
            {
                Titulo = context.Request.Form["titulo"],
                Autor = context.Request.Form["autor"]
            };

            var _repo = new LivroRepositorioCSV();
            _repo.Incluir(_novoLivro);
            return context.Response.WriteAsync("O livro foi adicionado com sucesso.");
        }

        public static Task ExibeFormulario(HttpContext context)
        {
            var _html = HtmlUtils.CarregarHTML("formulario");
            return context.Response.WriteAsync(_html);
        }

        public static Task NovoLivroParaLer(HttpContext context)
        {
            var _novoLivro = new Livro()
            {
                Titulo = context.GetRouteValue("nome").ToString(),
                Autor = context.GetRouteValue("autor").ToString()
            };

            var _repo = new LivroRepositorioCSV();
            _repo.Incluir(_novoLivro);
            return context.Response.WriteAsync("O livro foi adicionado com sucesso.");

        }

    }
}
