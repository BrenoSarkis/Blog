using Blog.Fronteiras.Executores.ListarPosts;
using Blog.Fronteiras.Executores.ObterPost;
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
        private readonly IObterPostExecutor obterPostExecutor;

        public PostController(IListarPostsExecutor listarPostsExecutor, ISalvarPostExecutor salvarPostExecutor, IObterPostExecutor obterPostExecutor)
        {
            this.listarPostsExecutor = listarPostsExecutor;
            this.salvarPostExecutor = salvarPostExecutor;
            this.obterPostExecutor = obterPostExecutor;
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

        public void Obter(int ano, int mes, int dia, string titulo)
        {
            var requisicao = new ObterPostRequisicao();
            requisicao.Url = String.Format("{0}/{1}/{2}/{3}", ano, mes.ToString().PadLeft(2, '0'), dia.ToString().PadLeft(2, '0'), titulo);
            var apresentador = new ObterPostApresentador();
            this.obterPostExecutor.Apresentador = apresentador;
            this.obterPostExecutor.Executar(requisicao);
        }

    }
}