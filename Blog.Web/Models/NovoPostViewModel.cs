using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Models
{
    public class NovoPostViewModel
    {
        public NovoPostViewModel()
        {
            Tags = Enumerable.Empty<string>().ToArray();
        }

        [AllowHtml]
        public string Conteudo { get; set; }
        public string Titulo { get; set; }
        public string CaminhoDaImagemDaCapa { get; set; }
        public string[] Tags { get; set; }
        public string Url { get; set; }
    }
}