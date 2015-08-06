using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Models
{
    public class ArvoreDePosts
    {
        public ArvoreDePosts()
        {
            PostsAgrupadosPorMesEAno = new List<PostPorMesEAno>();
        }

        public IList<PostPorMesEAno> PostsAgrupadosPorMesEAno { get; set; }
    }

    public class PostPorMesEAno
    {
        public PostPorMesEAno()
        {
            Posts = new List<Post>();
        }

        public int Mes { get; set; }
        public int Ano { get; set; }
        public string MesEAnoFormato { get { return String.Format("{0}/{1}", Mes.ToString().PadLeft(2, '0'), Ano); } }
        public int QuantidadeDePosts { get; set; }
        public string UrlParaDetalhar { get { return MesEAnoFormato; } }
        public IList<Post> Posts { get; set; }
    }

    public class Post
    {
        public string Titulo { get; set; }
        public string UrlParaDetalhar { get; set; }
    }
}