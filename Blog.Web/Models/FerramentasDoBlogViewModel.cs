using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Models
{
    public class FerramentasDoBlogViewModel
    {
        public string TermoDePesquisa { get; set; }
        public ArvoreDePosts ArvoreDePosts { get; set; }
        public IEnumerable<PostResumidoViewModel> UltimosCincoPosts { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}