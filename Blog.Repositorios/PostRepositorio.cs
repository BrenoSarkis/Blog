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

namespace Blog.Repositorios
{
    public class PostRepositorio : IPostRepositorio
    {
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
