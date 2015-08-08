using Blog.Fronteiras.Repositorios;
using Blog.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace Blog.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public bool UsuarioExiste(string email, string hashDaSenha)
        {
            using (var conexao = new SqlConnection(StringsDeConexao.SqlServer))
            {
                return conexao.Query<string>("SELECT Email FROM Usuario WHERE Email = @Email AND Senha = @Senha", new { Email = email, Senha = hashDaSenha }).Any();
            }
        }
    }
}
