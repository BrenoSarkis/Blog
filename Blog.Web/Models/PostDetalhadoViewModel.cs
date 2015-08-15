using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Models
{
    public class PostDetalhadoViewModel
    {
        public PostDetalhadoViewModel()
        {
            Comentarios = Enumerable.Empty<ComentarioViewModel>();
        }

        [AllowHtml]
        public string Conteudo { get; set; }
        public string Titulo { get; set; }
        public string CaminhoDaImagemDaCapa { get; set; }
        public int ContagemDeComentarios { get { return Comentarios.Count(); } }
        public string DataPorExtenso { get; set; }
        public string Tags { get; set; }
        public IEnumerable<ComentarioViewModel> Comentarios { get; set; }
    }
}