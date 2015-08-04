using Blog.Fronteiras.Executores.ObterPost;
using Blog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Apresentadores
{
    public class ObterPostApresentador : IObterPostApresentador
    {
        public void Apresentar(ObterPostResultado resultado)
        {
            Post = new PostDetalhadoViewModel
            {
                CaminhoDaImagemDaCapa = resultado.CaminhoDaImagemDaCapa,
                Conteudo = resultado.Conteudo,
                Titulo = resultado.Titulo
            };
        }

        public PostDetalhadoViewModel Post { get; set; }
    }
}