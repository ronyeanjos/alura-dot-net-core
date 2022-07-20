using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class StartUp
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();

        }

        public void Configure(IApplicationBuilder app)
        {
            var _builder = new RouteBuilder(app);
            
            _builder.MapRoute("Livros/ParaLer", LivrosParaLer);
            _builder.MapRoute("Livros/Lendo", LivrosLendo);
            _builder.MapRoute("Livros/Lidos", LivrosLidos);
            _builder.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", NovoLivroParaLer);
            _builder.MapRoute("Livros/ExibeDetalhes/{id:int}", ExibirDetalhes);

            var _rotas = _builder.Build();
            app.UseRouter(_rotas);

            //app.Run(Roteamento);
        }

        public Task ExibirDetalhes(HttpContext context)
        {
            int id = Convert.ToInt16(context.GetRouteValue("id"));
            var _repo = new LivroRepositorioCSV();
            var _livro = _repo.Todos.First(l => l.Id == id);

            return context.Response.WriteAsync(_livro.Detalhes());

        }

        public Task NovoLivroParaLer(HttpContext context)
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

        public Task Roteamento(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var _caminhosAtendidos = new Dictionary<string, RequestDelegate>
            {
                {"/Livros/ParaLer", LivrosParaLer },
                {"/Livros/Lendo", LivrosLendo },
                {"/Livros/Lidos", LivrosLidos }
            };

            if (_caminhosAtendidos.ContainsKey(context.Request.Path))
            {
                var _metodo = _caminhosAtendidos[context.Request.Path];
                return _metodo.Invoke(context);

            }

            context.Response.StatusCode = 404;
            return context.Response.WriteAsync("Caminho inexistente.");

        }

        public Task LivrosParaLer(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.ParaLer.ToString());
        }

        public Task LivrosLendo(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.Lendo.ToString());
        }
        public Task LivrosLidos(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.Lidos.ToString());
        }


    }
}