﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Fronteiras.Executores.ListarPosts
{
    public class ListarPostsRequisicao
    {
        public int? QuantidadeDePosts { get; set; }
        public int? PaginaAtual { get; set; }
        public string Tag { get; set; }
        public string TermoDePesquisa { get; set; }
    }
}
