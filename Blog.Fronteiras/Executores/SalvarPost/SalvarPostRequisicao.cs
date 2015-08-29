using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Fronteiras.Executores.SalvarPost
{
    public class SalvarPostRequisicao
    {
        public string Url { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public string CaminhoDaImagemDaCapa { get; set; }
        public string[] Tags { get; set; }
    }
}
