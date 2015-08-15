using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entidades
{
    public class Comentario
    {
        public int Codigo { get; set; }
        public int CodigoDoPost { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Mensagem { get; set; }
        public DateTime Data { get; set; }
    }
}
