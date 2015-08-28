using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Fronteiras.Executores.SalvarPost
{
    public class SalvarPostResultado : IResultadoComNotificacao
    {
        public List<string> NotificacoesDeErro { get; set; }
        public string NotificacaoDeSucesso { get; set; }
    }
}
