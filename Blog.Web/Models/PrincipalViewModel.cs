using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Models
{
    public class PrincipalViewModel
    {
        public PrincipalViewModel()
        {
            Posts = Enumerable.Empty<PostResumidoViewModel>();        
        }

        public int PaginaAtual { get; set; }
        public int QuantidadeDePaginas { get; set; }
        public IEnumerable<PostResumidoViewModel> Posts { get; set; }
    }
}