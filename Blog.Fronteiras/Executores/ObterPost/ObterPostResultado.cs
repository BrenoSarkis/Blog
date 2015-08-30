using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Fronteiras.Executores.ObterPost
{
    public class ObterPostResultado
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public DateTime Data { get; set; }
        public string CaminhoDaImagemDaCapa { get; set; }
        public string Url { get; set; }
        public string[] Tags { get; set; }
        public IEnumerable<Comentario> Comentarios { get; set; }

        public class Comentario
        {
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Mensagem { get; set; }
            public DateTime Data { get; set; }
        }
    }
}
