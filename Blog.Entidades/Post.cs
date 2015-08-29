using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entidades
{
    public class Post
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public DateTime Data { get; set; }
        public string CaminhoDaImagemDaCapa { get; set; }
        public string Url { get; set; }
        public string[] Tags { get; set; }
        public IEnumerable<Comentario> Comentarios { get; set; }
    }
}
