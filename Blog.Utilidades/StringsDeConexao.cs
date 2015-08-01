using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Utilidades
{
    public static class StringsDeConexao
    {
        public static string SqlServer { get { return ConfigurationManager.ConnectionStrings["Conexao"].ToString(); } }
    }
}
