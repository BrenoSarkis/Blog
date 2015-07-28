using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Fronteiras.Executores
{
    public interface IApresentador<TResultado> where TResultado : class
    {
        void ApresentarResultado(TResultado resultado);
    }
}
