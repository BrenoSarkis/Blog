using Blog.Fronteiras.Executores.ListarPosts;
using Blog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Apresentadores
{
    public class ArvoreDePostsApresentador : IListarPostsApresentador
    {
        public ArvoreDePostsApresentador()
        {
            Arvore = new ArvoreDePosts();
        }
         
        public void Apresentar(ListarPostsResultado resultado)
        {
            var postsDoMes = (from p in resultado.Posts
                              group p by new
                              {
                                  Mes = p.Data.Month,
                                  Ano = p.Data.Year,
                              } into pdm
                              let posts = pdm.Select(p => p)
                              select new PostPorMesEAno
                              {
                                  Ano = pdm.Key.Ano,
                                  Mes = pdm.Key.Mes,
                                  QuantidadeDePosts = posts.Count(),
                                  Posts = posts.Select(p => new Post { Titulo = p.Titulo, UrlParaDetalhar = p.Url }).ToList()
                              }).OrderByDescending(p => p.Ano).ThenByDescending(p => p.Mes);

            Arvore.PostsAgrupadosPorMesEAno = postsDoMes.ToList();
        }

        public ArvoreDePosts Arvore { get; set; }
    }
}