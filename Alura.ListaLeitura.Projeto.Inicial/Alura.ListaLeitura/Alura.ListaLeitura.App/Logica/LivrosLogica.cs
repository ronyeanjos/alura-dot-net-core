﻿using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alura.ListaLeitura.App.Html;

namespace Alura.ListaLeitura.App.Logica
{
    public class LivrosLogica
    {
        public static Task ExibirDetalhes(HttpContext context)
        {
            int id = Convert.ToInt16(context.GetRouteValue("id"));
            var _repo = new LivroRepositorioCSV();
            var _livro = _repo.Todos.First(l => l.Id == id);

            return context.Response.WriteAsync(_livro.Detalhes());

        }

        public static Task LivrosParaLer(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var _conteudoArquivo = HtmlUtils.CarregarHTML("para-ler");

            foreach (var livro in _repo.ParaLer.Livros)
            {
                _conteudoArquivo = _conteudoArquivo.Replace("#NOVO-ITEM#", $"<li>{livro.Titulo} - {livro.Autor}</li>#NOVO-ITEM#");
            }
            _conteudoArquivo = _conteudoArquivo.Replace("#NOVO-ITEM#", "");

            return context.Response.WriteAsync(_conteudoArquivo);
        }

        public static Task LivrosLendo(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var _conteudoArquivo = HtmlUtils.CarregarHTML("lendo");

            foreach (var livro in _repo.Lendo.Livros)
            {
                _conteudoArquivo = _conteudoArquivo.Replace("#NOVO-ITEM#", $"<li>{livro.Titulo} - {livro.Autor}</li>#NOVO-ITEM#");
            }
            _conteudoArquivo = _conteudoArquivo.Replace("#NOVO-ITEM#", "");

            return context.Response.WriteAsync(_conteudoArquivo);
        }
        public static Task LivrosLidos(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var _conteudoArquivo = HtmlUtils.CarregarHTML("lidos");

            foreach (var livro in _repo.Lidos.Livros)
            {
                _conteudoArquivo = _conteudoArquivo.Replace("#NOVO-ITEM#", $"<li>{livro.Titulo} - {livro.Autor}</li>#NOVO-ITEM#");
            }
            _conteudoArquivo = _conteudoArquivo.Replace("#NOVO-ITEM#", "");

            return context.Response.WriteAsync(_conteudoArquivo);
        }

    }
}
