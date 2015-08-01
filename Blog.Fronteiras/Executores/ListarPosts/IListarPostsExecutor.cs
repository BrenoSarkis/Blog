using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Fronteiras.Executores.ListarPosts
{
    public interface IListarPostsExecutor : IExecutor<ListarPostsRequisicao>
    {
        IListarPostsApresentador Apresentador { get; set; }
    }
}
