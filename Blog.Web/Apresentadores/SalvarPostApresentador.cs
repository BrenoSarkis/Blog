using Blog.Fronteiras.Executores.SalvarPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Fronteiras.Executores;
using Blog.Web.Models;

namespace Blog.Web.Apresentadores
{
    public class SalvarPostApresentador : ISalvarPostApresentador
    {
        public void Apresentar(IResultadoComNotificacao resultado)
        {
            Notificacoes = new NotificacaoViewModel
            {
                NotificacaoDeSucesso = resultado.NotificacaoDeSucesso,
                NotificacoesDeErro = resultado.NotificacoesDeErro
            };
        }

        public NotificacaoViewModel Notificacoes { get; set; }
    }
}