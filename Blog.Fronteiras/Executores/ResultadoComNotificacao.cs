using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Fronteiras.Executores
{
    public class ResultadoComNotificacao : IResultadoComNotificacao
    {
        public string NotificacaoDeSucesso { get; set; }
        public List<string> NotificacoesDeErro { get; set; }
    }
}
