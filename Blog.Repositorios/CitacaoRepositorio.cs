using Blog.Fronteiras.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Entidades;
using Dapper;
using System.Data.SqlClient;
using Blog.Utilidades;
using Blog.Repositorios.Entidades;

namespace Blog.Repositorios
{
    public class CitacaoRepositorio : ICitacaoRepositorio
    {
        public IEnumerable<Citacao> Todos()
        {
            using (var conexao = new SqlConnection(StringsDeConexao.SqlServer))
            {
                return conexao.Query<CitacaoBD>("SELECT Codigo, Texto, Autor FROM Citacao");
            }
        }
    }
}
