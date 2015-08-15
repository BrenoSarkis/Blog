using Blog.Fronteiras.Executores.CriarComentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Testes.Dublês.Apresentadores
{
    public class CriarComentarioApresentadorSpy : ICriarComentarioApresentador
    {
        public void Apresentar(CriarComentarioResultado resultado)
        {
            
        }

        public bool AutorEhOCriador { get; set; }
    }
}
