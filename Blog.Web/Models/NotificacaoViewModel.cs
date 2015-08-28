using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Models
{
    public class NotificacaoViewModel
    {
        public IEnumerable<string> NotificacoesDeErro { get; set; }
        public string NotificacaoDeSucesso { get; set; }
    }
}