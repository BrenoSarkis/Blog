using Blog.Fronteiras.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Testes.Dublês.Seguranca
{
    public class GeradorDeHashComSaltMock : IGeradorDeHashComSalt
    {
        public string Gerar(string texto)
        {
            return texto;
        }
    }
}
