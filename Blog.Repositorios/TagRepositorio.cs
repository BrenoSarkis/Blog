using Blog.Fronteiras.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Blog.Utilidades;
using Blog.Entidades;

namespace Blog.Repositorios
{
    public class TagRepositorio : ITagRepositorio
    {
        public void Salvar(Tag tag)
        {
            using (var conexao = new SqlConnection(StringsDeConexao.SqlServer))
            {
                conexao.Execute("INSERT INTO (Nome) TAG values (@nome)", new { tag.Nome });
            }
        }
    }
}
