using Blog.Entidades;
using Blog.Fronteiras.Executores.ListarPosts;
using Blog.Fronteiras.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog
{
    public class ListarPostsExecutor : IListarPostsExecutor
    {
        private readonly IPostRepositorio postRepositorio;

        public ListarPostsExecutor(IPostRepositorio postRepositorio)
        {
            this.postRepositorio = postRepositorio;
        }

        public IListarPostsApresentador Apresentador { get; set; }

        public void Executar(ListarPostsRequisicao requisicao)
        {
            var resultado = new ListarPostsResultado();
            var posts = Enumerable.Empty<Post>();

            bool listarPorTag = !String.IsNullOrWhiteSpace(requisicao.Tag);
            bool listarComPaginacao = requisicao.PaginaAtual.HasValue && requisicao.QuantidadeDePosts.HasValue;
            bool listarTodos = !listarPorTag && !listarComPaginacao;

            if (listarPorTag)
            {
                posts = ListarPorTag(requisicao.Tag);
            }

            if (listarComPaginacao)
            {
                posts = ListarComPaginacao(requisicao.PaginaAtual.Value, requisicao.QuantidadeDePosts.Value, requisicao.TermoDePesquisa);
            }
            
            if(listarTodos)
            {
                posts = ListarTodos();
            }
             
            resultado.Posts = from p in posts
                              select new ListarPostsResultado.Post
                              {
                                  Codigo = p.Codigo,
                                  CaminhoDaImagemDaCapa = p.CaminhoDaImagemDaCapa,
                                  Conteudo = p.Conteudo,
                                  Tags = p.Tags,
                                  Titulo = p.Titulo,
                                  Data = p.Data,
                                  Url = p.Url
                              };

            Apresentador.Apresentar(resultado);
        }

        private IEnumerable<Post> ListarPorTag(string tag)
        {
            return this.postRepositorio.ListarPorTag(tag);
        }

        private IEnumerable<Post> ListarComPaginacao(int paginaAtual, int quantidadeDePosts, string termoDePesquisa)
        {
            return this.postRepositorio.ListarComPaginacao(paginaAtual, quantidadeDePosts, termoDePesquisa);
        }

        private IEnumerable<Post> ListarTodos()
        {
            return this.postRepositorio.ListarTodos();
        }
    }
}