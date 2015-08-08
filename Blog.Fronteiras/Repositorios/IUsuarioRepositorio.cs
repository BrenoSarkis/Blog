using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Fronteiras.Repositorios
{
    public interface IUsuarioRepositorio
    {
        bool UsuarioExiste(string email, string hashDaSenha);
    }
}
