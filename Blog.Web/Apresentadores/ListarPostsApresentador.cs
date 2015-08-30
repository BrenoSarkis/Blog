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
            Posts = from p in resultado.Posts
                             select new PostResumidoViewModel
                             {
                                 Codigo = p.Codigo,
                                 CaminhoDaImagemDaCapa = p.CaminhoDaImagemDaCapa,
                                 Conteudo = p.Conteudo.Substring(0, Math.Min(400, p.Conteudo.Length)) + "...",
                                 Tags = String.Join(", ", p.Tags),
                                 DataPorExtenso = p.Data.ToString("MMMM dd, yyyy", CultureInfo.CurrentCulture),
                                 Titulo = p.Titulo,
                                 Url = p.Url
                             };
        }

        public IEnumerable<PostResumidoViewModel> Posts { get; set; }
    }
}