using Blog.Fronteiras.Executores.EnviarEmail;
using Blog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Apresentadores
{
    public class EnviarEmailApresentador : IEnviarEmailApresentador
    {
        public void Apresentar(EnviarEmailResultado resultado)
        {
            Mensagem = new MensagemViewModel { Texto = resultado.Mensagem };
        }

        public MensagemViewModel Mensagem { get; set; }
    }
}