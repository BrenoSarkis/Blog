using Blog.Fronteiras.Executores.CriarComentario;
using Blog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Apresentadores
{
    public class CriarComentarioApresentador : ICriarComentarioApresentador
    {
        public void Apresentar(CriarComentarioResultado resultado)
        {
            Comentario = new ComentarioViewModel
            {
                Nome = resultado.Nome,
                Data = resultado.Data,
                Email = resultado.Email,
                Mensagem = resultado.Mensagem
            };
        }

        public ComentarioViewModel Comentario { get; set; }
    }
}