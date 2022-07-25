using Alura.ListaLeitura.App.Logica;
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
    public class StartUp
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();

        }

        public void Configure(IApplicationBuilder app)
        {
            var _builder = new RouteBuilder(app);
            
            _builder.MapRoute("Livros/ParaLer", LivrosLogica.LivrosParaLer);
            _builder.MapRoute("Livros/Lendo", LivrosLogica.LivrosLendo);
            _builder.MapRoute("Livros/Lidos", LivrosLogica.LivrosLidos);
            _builder.MapRoute("Livros/ExibeDetalhes/{id:int}", LivrosLogica.ExibirDetalhes);

            _builder.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", CadastroLogica.NovoLivroParaLer);
            _builder.MapRoute("Cadastro/NovoLivro", CadastroLogica.ExibeFormulario);
            _builder.MapRoute("Cadastro/Incluir", CadastroLogica.ProcessaFormulario);

            var _rotas = _builder.Build();
            app.UseRouter(_rotas);
        }



        


        

        


    }
}