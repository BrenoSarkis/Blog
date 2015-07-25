using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Fronteiras.Executores
{
    public interface IExecutor<TRequisicao>
    {
        void Executar(TRequisicao requisicao);
    }

    public interface IExecutor
    {
        void Executar();
    }
}
