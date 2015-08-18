using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Fronteiras.Executores.ObterNumeroDePaginasDePost
{
    public interface IObterNumeroDePaginasDePostExecutor : IExecutor
    {
        IObterNumeroDePaginasDePostApresentador Apresentador{ get; set; }
    }
}
