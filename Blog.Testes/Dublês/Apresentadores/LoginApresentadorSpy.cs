using Blog.Fronteiras.Executores.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Testes.Dublês.Apresentadores
{
    public class LoginApresentadorSpy : ILoginApresentador
    {
        public void Apresentar(LoginResultado resultado)
        {
            UsuarioExiste = resultado.UsuarioExiste;
        }

        public bool UsuarioExiste { get; set; }
    }
}
