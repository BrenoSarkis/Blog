using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Fronteiras.Executores.ListarPosts
{
    public class ListarPostsResultado
    {
        public ListarPostsResultado()
        {
            Posts = Enumerable.Empty<ListarPostsResultado.Post>();
        }

        public IEnumerable<ListarPostsResultado.Post> Posts { get; set; }

        public class Post
        {
            public string Conteudo { get; set; }
            public string Titulo { get; set; }
            public string CaminhoDaImagemDaCapa { get; set; }
            public int ContagemDeComentarios { get; set; }
            public string[] Tags { get; set; }
        }
    }
}
