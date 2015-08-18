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
        public ListarPostsApresentador()
        {
            Principal = new PrincipalViewModel();
            Principal.Posts = Enumerable.Empty<PostResumidoViewModel>();
        }

        public void Apresentar(ListarPostsResultado resultado)
        {
            Principal.Posts = from p in resultado.Posts
                             select new PostResumidoViewModel
                             {
                                 CaminhoDaImagemDaCapa = p.CaminhoDaImagemDaCapa,
                                 Conteudo = p.Conteudo.Substring(0, Math.Min(580, p.Conteudo.Length)) + "...",
                                 Tags = String.Join(", ", p.Tags),
                                 DataPorExtenso = p.Data.ToString("MMMM dd, yyyy", CultureInfo.CurrentCulture),
                                 Titulo = p.Titulo,
                                 Url = p.Url
                             };
            Principal.QuantidadeDePaginas = resultado.Posts.Count();
        }

        public PrincipalViewModel Principal { get; set; }
    }
}