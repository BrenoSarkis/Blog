using Blog.Fronteiras.Executores.ObterNumeroDePaginasDePost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Apresentadores
{
    public class ObterNumeroDePaginasDePostApresentador : IObterNumeroDePaginasDePostApresentador
    {
        public void Apresentar(ObterNumeroDePaginasDePostResultado resultado)
        {
            NumeroDePaginas = resultado.Numero;
        }

        public int NumeroDePaginas { get; set; }
    }
}