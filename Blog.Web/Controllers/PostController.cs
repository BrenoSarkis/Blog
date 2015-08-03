using Blog.Fronteiras.Executores.ListarPosts;
using Blog.Fronteiras.Executores.SalvarPost;
using Blog.Web.Apresentadores;
using Blog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IListarPostsExecutor listarPostsExecutor;
        private readonly ISalvarPostExecutor salvarPostExecutor;

        public PostController(IListarPostsExecutor listarPostsExecutor, ISalvarPostExecutor salvarPostExecutor)
        {
            this.listarPostsExecutor = listarPostsExecutor;
            this.salvarPostExecutor = salvarPostExecutor;
        }

        public ActionResult Index()
        {
            var requisicao = new ListarPostsRequisicao { PaginaAtual = 1, QuantidadeDePosts = 10 };
            var apresentador = new ListarPostsApresentador();
            listarPostsExecutor.Apresentador = apresentador;
            listarPostsExecutor.Executar(requisicao);
            return View(apresentador.PostsResumidos);
        }

        public ActionResult Novo()
        {
            return View(new NovoPostViewModel());
        }

        public void Salvar(NovoPostViewModel novoPost)
        {
            var requisicao = new SalvarPostRequisicao
            {
                Titulo = novoPost.Titulo,
                Conteudo = novoPost.Conteudo,
                CaminhoDaImagemDaCapa = novoPost.CaminhoDaImagemDaCapa,
                Tags = novoPost.Tags
            };

            salvarPostExecutor.Executar(requisicao);
        }


    }
}