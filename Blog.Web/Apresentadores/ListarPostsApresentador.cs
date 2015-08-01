using Blog.Fronteiras.Executores.ListarPosts;
using Blog.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Blog.Web.Apresentadores
{
    public class ListarPostsApresentador : IListarPostsApresentador
    {
        public void Apresentar(ListarPostsResultado resultado)
        {
            PostsResumidos = from p in resultado.Posts
                             select new PostResumidoViewModel
                             {
                                 CaminhoDaImagemDaCapa = p.CaminhoDaImagemDaCapa,
                                 Conteudo = p.Conteudo.Substring(0, Math.Min(150, p.Conteudo.Length)) + "...",
                                 Tags = String.Join(",", p.Tags),
                                 DataPorExtenso = p.Data.ToString("MMM dd, yyyy", CultureInfo.InvariantCulture),
                                 Titulo = p.Titulo
                             };
        }

        public IEnumerable<PostResumidoViewModel> PostsResumidos { get; set; }
    }
}