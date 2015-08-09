using Blog.Fronteiras.Executores.Login;
using Blog.Fronteiras.Repositorios;
using Blog.Fronteiras.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blog
{
    public class LoginExecutor : ILoginExecutor
    {
        private readonly IUsuarioRepositorio usuarioRepositorio;
        private readonly IGeradorDeHashComSalt geradorDeHashComSalt;

        public LoginExecutor(IUsuarioRepositorio usuarioRepositorio, IGeradorDeHashComSalt geradorDeHashComSalt)
        {
            this.usuarioRepositorio = usuarioRepositorio;
            this.geradorDeHashComSalt = geradorDeHashComSalt;
        }

        public ILoginApresentador Apresentador { get; set; }

        public void Executar(LoginRequisicao requisicao)
        {
            var resultado = new LoginResultado();

            if (String.IsNullOrWhiteSpace(requisicao.Senha))
            {
                resultado.UsuarioExiste = false;
            }
            else
            {
                var hashDaSenha = geradorDeHashComSalt.Gerar(requisicao.Senha);
                resultado.UsuarioExiste = this.usuarioRepositorio.UsuarioExiste(requisicao.Email, hashDaSenha);
            }

            Apresentador.Apresentar(resultado);
        }
    }
}
