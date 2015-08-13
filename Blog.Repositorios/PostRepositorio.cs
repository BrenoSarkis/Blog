using Blog.Fronteiras.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Entidades;
using Dapper;
using Blog.Utilidades;
using System.Data.SqlClient;
using Blog.Repositorios.Entidades;

namespace Blog.Repositorios
{
    public class PostRepositorio : IPostRepositorio
    {
        public IEnumerable<Post> ListarComPaginacao(int pagina, int quantidadeDePosts, string termoDePesquisa)
        {
            using (var conexao = new SqlConnection(StringsDeConexao.SqlServer))
            {
                string filtro = !String.IsNullOrWhiteSpace(termoDePesquisa) ? @"WHERE Titulo LIKE '%@TermoDePesquisa%' OR Conteudo LIKE '%@TermoDePesquisa%'" : String.Empty;

                string consulta = String.Format(@"DECLARE @QuantidadeDePosts INT = {0}, @Pagina INT = {1}
                                                                SELECT Codigo, Titulo, Conteudo, Url, Data, CaminhoDaImagemDaCapa
                                                                FROM Post
                                                                {2}
                                                                ORDER BY Codigo DESC
                                                                OFFSET(@Pagina - 1) * @QuantidadeDePosts ROWS
                                                                FETCH NEXT @QuantidadeDePosts ROWS ONLY", quantidadeDePosts, pagina, filtro);

                var posts = Enumerable.Empty<PostBD>();

                if (String.IsNullOrWhiteSpace(filtro))
                {
                    posts = conexao.Query<PostBD>(consulta);
                }
                else
                {
                    posts = conexao.Query<PostBD>(consulta, new { TermoDePesquisa = termoDePesquisa });
                }
                
                foreach (var post in posts)
                {
                    post.Tags = conexao.Query<string>("SELECT Tag from TagsDoPost WHERE CodigoDoPost = @Codigo", new { post.Codigo }).ToArray();
                }

                return posts;
            }
        }

        public IEnumerable<Post> ListarPorTag(string tag)
        {
            using (var conexao = new SqlConnection(StringsDeConexao.SqlServer))
            {
                var codigosDosPostsComATag = conexao.Query<string>("SELECT DISTINCT CodigoDoPost FROM TagsDoPost WHERE Tag = @Tag", new { Tag = tag });

                foreach (var codigo in codigosDosPostsComATag)
                {
                    var post = conexao.Query<Post>(@"SELECT Codigo, Titulo, Conteudo, Url, Data, CaminhoDaImagemDaCapa
                                                       FROM Post
                                                       WHERE Codigo = @Codigo
                                                       ORDER BY Codigo DESC", new { Codigo = codigo }).FirstOrDefault();

                    post.Tags = conexao.Query<string>("SELECT Tag from TagsDoPost WHERE CodigoDoPost = @Codigo", new { post.Codigo }).ToArray();

                    yield return post;                 
                }
            }
        }

        public IEnumerable<string> ListarTodasAsTagsUnicas()
        {
            using (var conexao = new SqlConnection(StringsDeConexao.SqlServer))
            {
                return conexao.Query<string>("SELECT DISTINCT TAG FROM TagsDoPost");
            }
        }

        public IEnumerable<Post> ListarTodos()
        {
            using (var conexao = new SqlConnection(StringsDeConexao.SqlServer))
            {
                var posts = conexao.Query<Post>(@"SELECT Codigo, Titulo, Conteudo, Url, Data, CaminhoDaImagemDaCapa
                                                       FROM Post
                                                       ORDER BY Codigo DESC");

                foreach (var post in posts)
                {
                    post.Tags = conexao.Query<string>("SELECT Tag from TagsDoPost WHERE CodigoDoPost = @Codigo", new { post.Codigo }).ToArray();
                }

                return posts;
            }
        }

        public Post ObterPorUrl(string url)
        {
            using (var conexao = new SqlConnection(StringsDeConexao.SqlServer))
            {
                var post = conexao.Query<PostBD>(@"SELECT Codigo, Titulo, Conteudo, Url, Data, CaminhoDaImagemDaCapa
                                                             FROM Post
                                                             WHERE Url = @Url", new { url }).FirstOrDefault();
                if (post == null) return null;

                post.Tags = conexao.Query<string>("SELECT Tag from TagsDoPost WHERE CodigoDoPost = @Codigo", new { post.Codigo }).ToArray();

                return post;
            }
        }

        public void Salvar(Post post)
        {
            using (var conexao = new SqlConnection(StringsDeConexao.SqlServer))
            {
                int codigo = conexao.Query<int>(@"INSERT INTO [Post] (Titulo, Conteudo, Data, Url, CaminhoDaImagemDaCapa) values (@Titulo, @Conteudo, @Data, @Url, @CaminhoDaImagemDaCapa);
                                                  SELECT CAST(SCOPE_IDENTITY() as int)", new { post.Titulo, post.Conteudo, post.Data, post.Url, post.CaminhoDaImagemDaCapa }).Single();

                foreach (var tag in post.Tags)
                {
                    conexao.Execute("INSERT INTO [TagsDoPost] (CodigoDoPost, Tag) values(@CodigoDoPost, @Tag)", new { @CodigoDoPost = codigo, @Tag = tag });
                }
            }
        }
    }
}
