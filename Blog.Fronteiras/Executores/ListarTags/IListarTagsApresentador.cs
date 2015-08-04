using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Fronteiras.Executores.ListarTags
{
    public interface IListarTagsApresentador : IApresentador<ListarTagsResultado>
    {
        IEnumerable<string> Tags { get; set; }
    }
}
