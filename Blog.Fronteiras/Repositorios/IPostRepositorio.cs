using Blog.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Fronteiras.Repositorios
{
    public interface IPostRepositorio
    {
        void Salvar(Post post);
        IEnumerable<Post> ListarComPaginacao(int pagina, int quantidadeDePosts);
        IEnumerable<string> ListarTodasAsTagsUnicas();
        Post ObterPorUrl(string url);
    }
}
