﻿using Blog.Fronteiras.Executores.CriarComentario;
using Blog.Fronteiras.Executores.DeletarTag;
using Blog.Fronteiras.Executores.ListarPosts;
using Blog.Fronteiras.Executores.ListarTags;
using Blog.Fronteiras.Executores.ObterNumeroDePaginasDePost;
using Blog.Fronteiras.Executores.ObterPost;
using Blog.Fronteiras.Executores.SalvarPost;
using Blog.Web.Apresentadores;
using Blog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IListarPostsExecutor listarPostsExecutor;
        private readonly ISalvarPostExecutor salvarPostExecutor;
        private readonly IObterPostExecutor obterPostExecutor;
        private readonly IListarTagsExecutor listarTagsExecutor;
        private readonly ICriarComentarioExecutor criarComentarioExecutor;
        private readonly IObterNumeroDePaginasDePostExecutor obterNumeroDePaginasDePostExecutor;
        private readonly IDeletarTagExecutor deletarTagExecutor;

        public BlogController(IListarPostsExecutor listarPostsExecutor, ISalvarPostExecutor salvarPostExecutor,
                              IObterPostExecutor obterPostExecutor, IListarTagsExecutor listarTagsExecutor,
                              ICriarComentarioExecutor criarComentarioExecutor, IObterNumeroDePaginasDePostExecutor obterNumeroDePaginasDePostExecutor,
                              IDeletarTagExecutor deletarTagExecutor)
        {
            this.listarPostsExecutor = listarPostsExecutor;
            this.salvarPostExecutor = salvarPostExecutor;
            this.obterPostExecutor = obterPostExecutor;
            this.listarTagsExecutor = listarTagsExecutor;
            this.criarComentarioExecutor = criarComentarioExecutor;
            this.obterNumeroDePaginasDePostExecutor = obterNumeroDePaginasDePostExecutor;
            this.deletarTagExecutor = deletarTagExecutor;
        }

        public ActionResult Index()
        {
            var requisicao = new ListarPostsRequisicao { PaginaAtual = 1, QuantidadeDePosts = 5 };
            var listarPostsApresentador = new ListarPostsApresentador();
            listarPostsExecutor.Apresentador = listarPostsApresentador;
            listarPostsExecutor.Executar(requisicao);
            var obterNumeroDePaginasDePostApresentador = new ObterNumeroDePaginasDePostApresentador();
            this.obterNumeroDePaginasDePostExecutor.Apresentador = obterNumeroDePaginasDePostApresentador;
            this.obterNumeroDePaginasDePostExecutor.Executar();
            var blogViewModel = new BlogViewModel();
            blogViewModel.Posts = listarPostsApresentador.Posts;
            blogViewModel.QuantidadeDePaginas = obterNumeroDePaginasDePostApresentador.NumeroDePaginas;
            blogViewModel.PaginaAtual = 1;
            return View("Index", blogViewModel);
        }

        public PartialViewResult Posts(int paginaAtual)
        {
            var requisicao = new ListarPostsRequisicao { PaginaAtual = paginaAtual, QuantidadeDePosts = 5 };
            var listarPostsApresentador = new ListarPostsApresentador();
            listarPostsExecutor.Apresentador = listarPostsApresentador;
            listarPostsExecutor.Executar(requisicao);
            return PartialView("Posts", listarPostsApresentador.Posts);
        }

        [Authorize]
        public ActionResult NovoPost()
        {
            return View(new NovoPostViewModel());
        }

        [Authorize]
        [HttpPost]
        public void Salvar(NovoPostViewModel novoPost)
        {
            var apresentador = new SalvarPostApresentador();
            var requisicao = new SalvarPostRequisicao
            {
                Codigo = novoPost.Codigo,
                Titulo = novoPost.Titulo,
                Conteudo = novoPost.Conteudo,
                CaminhoDaImagemDaCapa = novoPost.CaminhoDaImagemDaCapa,
                Tags = novoPost.Tags.ToArray()
            };
            salvarPostExecutor.Apresentador = apresentador;
            salvarPostExecutor.Executar(requisicao);
        }

        public ActionResult Detalhar(string ano, string mes, string dia, string titulo)
        {
            var requisicao = new ObterPostRequisicao();
            requisicao.Url = String.Format("{0}/{1}/{2}/{3}", ano, mes.ToString().PadLeft(2, '0'), dia.ToString().PadLeft(2, '0'), titulo);
            var apresentador = new ObterPostApresentador();
            this.obterPostExecutor.Apresentador = apresentador;
            this.obterPostExecutor.Executar(requisicao);
            return View("PostDetalhado", apresentador.Post);
        }

        [HttpPost]
        public void DeletarTag(string tag, int codigoDoPost)
        {
            var requisicao = new DeletarTagRequisicao { Tag = tag, CodigoDoPost = codigoDoPost };
            var apresentador = new DeletarTagApresentador();
            this.deletarTagExecutor.Apresentador = apresentador;
            this.deletarTagExecutor.Executar(requisicao);
        }

        public ActionResult ListarPostsPorTag(string tag)
        {
            var requisicao = new ListarPostsRequisicao { Tag = tag };
            var listarPostsApresentador = new ListarPostsApresentador();
            listarPostsExecutor.Apresentador = listarPostsApresentador;
            listarPostsExecutor.Executar(requisicao);
            var obterNumeroDePaginasDePostApresentador = new ObterNumeroDePaginasDePostApresentador();
            this.obterNumeroDePaginasDePostExecutor.Apresentador = obterNumeroDePaginasDePostApresentador;
            this.obterNumeroDePaginasDePostExecutor.Executar();
            var blogViewModel = new BlogViewModel();
            blogViewModel.Posts = listarPostsApresentador.Posts;
            blogViewModel.QuantidadeDePaginas = obterNumeroDePaginasDePostApresentador.NumeroDePaginas;
            return View("Index", blogViewModel);
        }

        [HttpPost]
        public ActionResult Pesquisar(FerramentasDoBlogViewModel viewModel)
        {
            var requisicao = new ListarPostsRequisicao { PaginaAtual = 1, QuantidadeDePosts = 10, TermoDePesquisa = viewModel.TermoDePesquisa };
            var listarPostsApresentador = new ListarPostsApresentador();
            listarPostsExecutor.Apresentador = listarPostsApresentador;
            listarPostsExecutor.Executar(requisicao);
            var obterNumeroDePaginasDePostApresentador = new ObterNumeroDePaginasDePostApresentador();
            this.obterNumeroDePaginasDePostExecutor.Apresentador = obterNumeroDePaginasDePostApresentador;
            this.obterNumeroDePaginasDePostExecutor.Executar();
            var blogViewModel = new BlogViewModel();
            blogViewModel.Posts = listarPostsApresentador.Posts;
            blogViewModel.QuantidadeDePaginas = obterNumeroDePaginasDePostApresentador.NumeroDePaginas;
            return View("Index", blogViewModel);
        }

        [HttpGet]
        public PartialViewResult Comentario(ComentarioViewModel viewModel)
        {
            return PartialView("Comentario", viewModel);
        }

        [HttpPost]
        public ActionResult Comentar(ComentarioViewModel viewModel)
        {
            var requisicao = new CriarComentarioRequisicao();
            requisicao.Nome = viewModel.Nome;
            requisicao.Email = viewModel.Email;
            requisicao.Mensagem = viewModel.Mensagem;
            requisicao.UrlDoPost = viewModel.UrlDoPost;
            var apresentador = new CriarComentarioApresentador();
            this.criarComentarioExecutor.Apresentador = apresentador;
            this.criarComentarioExecutor.Executar(requisicao);
            var urlDividida = viewModel.UrlDoPost.Split('/');
            string dia = urlDividida[2];
            string mes = urlDividida[1];
            string ano = urlDividida[0];
            string titulo = urlDividida[3];
            return RedirectToAction("Detalhar", new { ano = ano, mes = mes, dia = dia, titulo = titulo });
        }

        public ActionResult Editar(int codigo)
        {
            var requisicao = new ObterPostRequisicao();
            requisicao.Codigo = codigo;
            var apresentador = new ObterPostApresentador();
            this.obterPostExecutor.Apresentador = apresentador;
            this.obterPostExecutor.Executar(requisicao);
            var viewModel = new NovoPostViewModel();
            viewModel.CaminhoDaImagemDaCapa = apresentador.Post.CaminhoDaImagemDaCapa;
            viewModel.Conteudo = apresentador.Post.Conteudo;
            viewModel.Tags = String.IsNullOrWhiteSpace(apresentador.Post.Tags) ? new List<string>() : apresentador.Post.Tags.Split(',').ToList();
            viewModel.Titulo = apresentador.Post.Titulo;
            viewModel.Url = apresentador.Post.Url;
            viewModel.Codigo = apresentador.Post.Codigo;
            return View("NovoPost", viewModel);
        }

        [ChildActionOnly]
        public PartialViewResult BarraLateral()
        {
            var ferramentasDoBlog = new FerramentasDoBlogViewModel();

            var arvoreDePostsApresentador = new ArvoreDePostsApresentador();
            this.listarPostsExecutor.Apresentador = arvoreDePostsApresentador;
            this.listarPostsExecutor.Executar(new ListarPostsRequisicao { PaginaAtual = 1, QuantidadeDePosts = 200 });
            ferramentasDoBlog.ArvoreDePosts = arvoreDePostsApresentador.Arvore;

            var listarUltimosCincoPostsApresentador = new ListarUltimosCincoPostsApresentador();
            this.listarPostsExecutor.Apresentador = listarUltimosCincoPostsApresentador;
            this.listarPostsExecutor.Executar(new ListarPostsRequisicao { PaginaAtual = 1, QuantidadeDePosts = 200 });
            ferramentasDoBlog.UltimosCincoPosts = listarUltimosCincoPostsApresentador.UltimosCincoPostsResumidos;

            var listarTagsApresentador = new ListarTagsApresentador();
            this.listarTagsExecutor.Apresentador = listarTagsApresentador;
            this.listarTagsExecutor.Executar();
            ferramentasDoBlog.Tags = listarTagsApresentador.Tags;

            return PartialView("BarraLateral", ferramentasDoBlog);
        }
    }
}