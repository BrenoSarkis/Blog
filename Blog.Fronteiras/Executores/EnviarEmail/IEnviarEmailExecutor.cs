using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Fronteiras.Executores.EnviarEmail
{
    public interface IEnviarEmailExecutor : IExecutor<EnviarEmailRequisicao>
    {
        IEnviarEmailApresentador Apresentador { get; set; }
    }
}
