using Blog.Fronteiras.Executores.ListarPosts;
using Blog.Fronteiras.Executores.SalvarPost;
using Blog.Repositorios;
using Blog.Web.Apresentadores;
using Blog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Blog.Web.Controllers
{
    public class PostController : ApiController
    {
        [HttpGet]
        [Route("api/ListarPosts")]
        public IEnumerable<PostResumidoViewModel> ListarPosts()
        {
            var postRepositorio = new PostRepositorio();
            var apresentador = new ListarPostsApresentador();
            var executor = new ListarPostsExecutor(apresentador, postRepositorio);
            executor.Executar(new ListarPostsRequisicao { PaginaAtual = 1, QuantidadeDePosts = 10 });
            return apresentador.PostsResumidos;
        }

        //public ActionResult Novo()
        //{
        //    //return View(new NovoPostViewModel());
        //    return null;
        //}

        public void Salvar(NovoPostViewModel novoPost)
        {
            var requisicao = new SalvarPostRequisicao
            {
                Titulo = novoPost.Titulo,
                Conteudo = novoPost.Conteudo,
                CaminhoDaImagemDaCapa = novoPost.CaminhoDaImagemDaCapa,
                Tags = novoPost.Tags
            };

            new SalvarPostExecutor(new PostRepositorio()).Executar(requisicao);
        }


    }
}