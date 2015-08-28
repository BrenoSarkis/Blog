using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Fronteiras.Executores
{
    public interface IResultadoComNotificacao
    {
        List<string> NotificacoesDeErro { get; set; }
        string NotificacaoDeSucesso { get; set; }
    }
}
