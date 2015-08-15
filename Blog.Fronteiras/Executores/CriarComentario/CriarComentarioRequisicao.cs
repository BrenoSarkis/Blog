using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Fronteiras.Executores.CriarComentario
{
    public class CriarComentarioRequisicao
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Mensagem { get; set; }
        public string UrlDoPost { get; set; }
    }
}
