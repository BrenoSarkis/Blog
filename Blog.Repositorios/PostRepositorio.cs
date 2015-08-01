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
        public IEnumerable<Post> ListarComPaginacao(int pagina, int quantidadeDePosts)
        {
            using (var conexao = new SqlConnection(StringsDeConexao.SqlServer))
            {
                var posts = conexao.Query<PostBD>(String.Format(@"DECLARE @QuantidadeDePosts INT = {0}, @Pagina INT = {1}
                                                                SELECT Titulo, Conteudo, Link, Data, CaminhoDaImagemDaCapa
                                                                FROM Post
                                                                ORDER BY Codigo
                                                                OFFSET(@Pagina - 1) * @QuantidadeDePosts ROWS
                                                                FETCH NEXT @QuantidadeDePosts ROWS ONLY", quantidadeDePosts, pagina));

                foreach (var post in posts)
                {
                    post.Tags = conexao.Query<string>("SELECT Tag from TagsDoPost WHERE CodigoDoPost = @Codigo", new { post.Codigo }).ToArray();
                }

                return posts;
            }
        }

        public void Salvar(Post post)
        {
            using (var conexao = new SqlConnection(StringsDeConexao.SqlServer))
            {
                int codigo = conexao.Query<int>(@"INSERT INTO [Post] (Titulo, Conteudo, Data, Link) values (@Titulo, @Conteudo, @Data, @Link);
                                                  SELECT CAST(SCOPE_IDENTITY() as int)", new { post.Titulo, post.Conteudo, post.Data, post.Link }).Single();

                foreach (var tag in post.Tags)
                {
                    conexao.Execute("INSERT INTO [TagsDoPost] (CodigoDoPost, Tag) values(@CodigoDoPost, @Tag)", new { @CodigoDoPost = codigo, @Tag = tag });
                }
            }
        }
    }
}
