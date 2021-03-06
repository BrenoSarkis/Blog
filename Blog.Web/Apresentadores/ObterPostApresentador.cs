﻿using Blog.Fronteiras.Executores.ObterPost;
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
                Codigo = resultado.Codigo,
                CaminhoDaImagemDaCapa = resultado.CaminhoDaImagemDaCapa,
                Conteudo = resultado.Conteudo,
                Titulo = resultado.Titulo,
                DataPorExtenso = resultado.Data.ToString("MMMM dd, yyyy", CultureInfo.CurrentCulture),
                Tags = String.Join(", ", resultado.Tags),
                Url = resultado.Url,
                Comentarios = resultado.Comentarios.Select(c => new ComentarioViewModel
                {
                    Nome = c.Nome,
                    Email = c.Email,
                    Mensagem = c.Mensagem,
                    Data = c.Data.ToString("dd/MM/yyyy hh:mm:ss")
                }).OrderByDescending(c => c.Data)
            };
        }

        public PostDetalhadoViewModel Post { get; set; }
    }
}