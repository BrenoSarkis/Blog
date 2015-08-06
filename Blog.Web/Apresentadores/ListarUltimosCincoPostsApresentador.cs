using Blog.Fronteiras.Executores.ListarPosts;
using Blog.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Blog.Web.Apresentadores
{
    public class ListarUltimosCincoPostsApresentador : IListarPostsApresentador
    {
        public void Apresentar(ListarPostsResultado resultado)
        {
            PostsResumidos = from p in resultado.Posts.Take(5)
                             select new PostResumidoViewModel
                             {
                                 CaminhoDaImagemDaCapa = p.CaminhoDaImagemDaCapa,
                                 Conteudo = p.Conteudo.Substring(0, Math.Min(150, p.Conteudo.Length)) + "...",
                                 Tags = String.Join(",", p.Tags),
                                 DataPorExtenso = p.Data.ToString("MMMM dd, yyyy", CultureInfo.CurrentCulture),
                                 Titulo = p.Titulo,
                                 Url = p.Url
                             };
        }

        public IEnumerable<PostResumidoViewModel> PostsResumidos { get; set; }
    }
}