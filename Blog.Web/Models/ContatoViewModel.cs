﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Models
{
    public class ContatoViewModel
    {
        public ContatoViewModel()
        {
            MensagemDeErro = new MensagemViewModel();
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }

        public MensagemViewModel MensagemDeErro { get; set; }
    }
}