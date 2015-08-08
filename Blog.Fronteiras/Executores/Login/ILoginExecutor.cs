using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Fronteiras.Executores.Login
{
    public interface ILoginExecutor : IExecutor<LoginRequisicao>
    {
        ILoginApresentador Apresentador { get; set; }
    }
}
