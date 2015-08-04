using Blog.Fronteiras.Executores.ListarTags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Apresentadores
{
    public class ListarTagsApresentador : IListarTagsApresentador
    {
        public void Apresentar(ListarTagsResultado resultado)
        {
            Tags = resultado.Tags;
        }

        public IEnumerable<string> Tags { get; set; }
    }
}