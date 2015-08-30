using Blog.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Fronteiras.Repositorios
{
    public interface ITagRepositorio
    {
        Tag Obter(string tag, int codigoDoPost);
        //void Salvar(Tag tag);
        void Deletar(Tag tag);
    }
}
