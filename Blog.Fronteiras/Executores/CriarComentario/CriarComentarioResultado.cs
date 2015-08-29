using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Fronteiras.Executores.CriarComentario
{
    public class CriarComentarioResultado : IResultadoComNotificacao
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Mensagem { get; set; }
        public DateTime Data { get; set; }
        public List<string> NotificacoesDeErro { get; set; }
        public string NotificacaoDeSucesso { get; set; }
    }
}
