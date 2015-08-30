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
        Post ObterCodigo(int codigo);
        Post ObterPorUrl(string url);
        IEnumerable<Post> ListarComPaginacao(int pagina, int quantidadeDePosts, string termoDePesquisa);
        IEnumerable<Post> ListarPorTag(string tag);
        IEnumerable<Post> ListarTodos();
        IEnumerable<string> ListarTodasAsTagsUnicas();
        int ContagemDePosts();
        void Salvar(Post post);
        void Atualizar(Post post);
        void SalvarComentario(Comentario comentario);
    }
}
