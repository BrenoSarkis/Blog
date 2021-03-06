﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Models
{
    public class ComentarioViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Mensagem { get; set; }
        public string UrlDoPost { get; set; }
        public string Data { get; set; }
        public NotificacaoViewModel Notificacao { get; set; }
    }
}