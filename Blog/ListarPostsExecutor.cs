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
        private readonly IListarPostsApresentador apresentador;
        private readonly IPostRepositorio postRepositorio;

        public ListarPostsExecutor(IListarPostsApresentador apresentador, IPostRepositorio postRepositorio)
        {
            this.apresentador = apresentador;
            this.postRepositorio = postRepositorio;
        }

        public void Executar(ListarPostsRequisicao requisicao)
        {
            var resultado = new ListarPostsResultado();
            var posts = this.postRepositorio.ListarComPaginacao(requisicao.PaginaAtual, requisicao.QuantidadeDePosts);

            resultado.Posts = from p in posts
                              select new ListarPostsResultado.Post
                              {
                                  CaminhoDaImagemDaCapa = p.CaminhoDaImagemDaCapa,
                                  Conteudo = p.Conteudo,
                                  Tags = p.Tags,
                                  Titulo = p.Titulo
                              };

            this.apresentador.Apresentar(resultado);
        }
    }
}
