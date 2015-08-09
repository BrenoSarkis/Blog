using Blog.Fronteiras.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Testes.Dublês.Repositorios
{
    public class UsuarioRepositorioMock : IUsuarioRepositorio
    {
        private string email = "teste@teste.com.br";
        private string senha = "teste";

        public bool UsuarioExiste(string email, string hashDaSenha)
        {
            return this.email == email && this.senha == hashDaSenha;
        }
    }
}
