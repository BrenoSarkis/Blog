using Blog.Fronteiras.Executores.CriarComentario;
using Blog.Fronteiras.Executores.ListarPosts;
using Blog.Fronteiras.Executores.ListarTags;
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

        public BlogController(IListarPostsExecutor listarPostsExecutor, ISalvarPostExecutor salvarPostExecutor,
                              IObterPostExecutor obterPostExecutor, IListarTagsExecutor listarTagsExecutor,
                              ICriarComentarioExecutor criarComentarioExecutor)
        {
            this.listarPostsExecutor = listarPostsExecutor;
            this.salvarPostExecutor = salvarPostExecutor;
            this.obterPostExecutor = obterPostExecutor;
            this.listarTagsExecutor = listarTagsExecutor;
            this.criarComentarioExecutor = criarComentarioExecutor;
        }

        public ActionResult Index(int? paginaAtual)
        {
            var requisicao = new ListarPostsRequisicao { PaginaAtual = paginaAtual.HasValue? paginaAtual.Value : 1, QuantidadeDePosts = 5 };
            var apresentador = new ListarPostsApresentador();
            listarPostsExecutor.Apresentador = apresentador;
            listarPostsExecutor.Executar(requisicao);
            return View(apresentador.Principal);
        }

        [Authorize]
        public ActionResult NovoPost()
        {
            return View(new NovoPostViewModel());
        }

        [Authorize]
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

        public ActionResult Detalhar(string ano, string mes, string dia, string titulo)
        {
            var requisicao = new ObterPostRequisicao();
            requisicao.Url = String.Format("{0}/{1}/{2}/{3}", ano, mes.ToString().PadLeft(2, '0'), dia.ToString().PadLeft(2, '0'), titulo);
            var apresentador = new ObterPostApresentador();
            this.obterPostExecutor.Apresentador = apresentador;
            this.obterPostExecutor.Executar(requisicao);
            return View("PostDetalhado", apresentador.Post);
        }

        public ActionResult ListarPostsPorTag(string tag)
        {
            var requisicao = new ListarPostsRequisicao { Tag = tag };
            var apresentador = new ListarPostsApresentador();
            listarPostsExecutor.Apresentador = apresentador;
            listarPostsExecutor.Executar(requisicao);
            return View("Index", apresentador.Principal);
        }

        [HttpPost]
        public ActionResult Pesquisar(FerramentasDoBlogViewModel viewModel)
        {
            var requisicao = new ListarPostsRequisicao { PaginaAtual = 1, QuantidadeDePosts = 10, TermoDePesquisa = viewModel.TermoDePesquisa };
            var apresentador = new ListarPostsApresentador();
            listarPostsExecutor.Apresentador = apresentador;
            listarPostsExecutor.Executar(requisicao);
            return View("Index", apresentador.Principal);
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