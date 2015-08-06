using Blog.Fronteiras.Executores.ObterPost;
using Blog.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                Titulo = resultado.Titulo,
                DataPorExtenso = resultado.Data.ToString("MMMM dd, yyyy", CultureInfo.CurrentCulture),
            };
        }

        public PostDetalhadoViewModel Post { get; set; }
    }
}