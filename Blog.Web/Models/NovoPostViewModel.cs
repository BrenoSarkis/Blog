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
            Tags = new List<string>();
        }

        [AllowHtml]
        public string Conteudo { get; set; }
        public string Titulo { get; set; }
        public string CaminhoDaImagemDaCapa { get; set; }
        public IList<string> Tags { get; set; }
        public string Url { get; set; }
        public string Tag { get; set; }
        public int Codigo { get; set; }
    }
}