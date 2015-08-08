using Blog.Fronteiras.Executores.ListarPosts;
using Blog.Fronteiras.Executores.ListarTags;
using Blog.Web.Apresentadores;
using Blog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blog.Web.ApiControllers
{
    public class PostController : ApiController
    {
        private readonly IListarPostsExecutor listarPostsExecutor;
        private readonly IListarTagsExecutor listarTagsExecutor;

        public PostController(IListarPostsExecutor listarPostsExecutor, IListarTagsExecutor listarTagsExecutor)
        {
            this.listarPostsExecutor = listarPostsExecutor;
            this.listarTagsExecutor = listarTagsExecutor;
        }

        [HttpGet]
        [Route("api/ListarPosts")]
        public IEnumerable<PostResumidoViewModel> ListarPosts()
        {
            var requisicao = new ListarPostsRequisicao { PaginaAtual = 1, QuantidadeDePosts = 10 };
            var apresentador = new ListarPostsApresentador();
            listarPostsExecutor.Apresentador = apresentador;
            listarPostsExecutor.Executar(requisicao);
            return apresentador.PostsResumidos;
        }

        [HttpGet]
        [Route("api/ListarTags")]
        public IEnumerable<string> ListarTags()
        {
            var apresentador = new ListarTagsApresentador();
            listarTagsExecutor.Apresentador = apresentador;
            listarTagsExecutor.Executar();
            return apresentador.Tags;
        }

        [HttpGet]
        [Route("api/{ano}/{mes}/{dia}/{titulo}")]
        public void Obter(int ano, int mes, int dia, string titulo)
        {

        }
    }
}
