using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Fronteiras.Executores.ObterCitacao
{
    public interface IObterCitacaoExecutor : IExecutor
    {
        IObterCitacaoApresentador Apresentador { get; set; }
    }
}
