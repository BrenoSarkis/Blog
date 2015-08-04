using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Fronteiras.Executores.ListarTags
{
    public interface IListarTagsExecutor : IExecutor
    {
        IListarTagsApresentador Apresentador { get; set; }
    }
}
