using Blog.Fronteiras.Executores.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Apresentadores
{
    public class LoginApresentador : ILoginApresentador
    {
        public void Apresentar(LoginResultado resultado)
        {
            UsuarioExiste = resultado.UsuarioExiste;
        }

        public bool UsuarioExiste { get; set; }
    }
}