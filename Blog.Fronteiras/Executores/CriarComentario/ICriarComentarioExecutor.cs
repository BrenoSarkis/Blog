using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Fronteiras.Executores.CriarComentario
{
    public interface ICriarComentarioExecutor : IExecutor<CriarComentarioRequisicao>
    {
        ICriarComentarioApresentador Apresentador { get; set; }
    }
}
