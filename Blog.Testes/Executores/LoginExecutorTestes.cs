using Blog.Fronteiras.Executores.Login;
using Blog.Fronteiras.Repositorios;
using Blog.Fronteiras.Seguranca;
using Blog.Seguranca;
using Blog.Testes.Dublês.Apresentadores;
using Blog.Testes.Dublês.Repositorios;
using Blog.Testes.Dublês.Seguranca;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Testes.Executores
{
    [TestFixture]
    public class LoginExecutorTestes
    {
        private LoginExecutor executor;
        private LoginApresentadorSpy apresentador;
        private LoginRequisicao requisicao;

        [SetUp]
        public void SetUp()
        {
            executor = new LoginExecutor(new UsuarioRepositorioMock(), new GeradorDeHashComSaltMock());
            apresentador = new LoginApresentadorSpy();
            executor.Apresentador = apresentador;
            requisicao = new LoginRequisicao();
        }

        [Test]
        public void Executar_SemSenha_UsuarioNaoExiste()
        {
            requisicao.Senha = "";

            executor.Executar(requisicao);

            Assert.IsFalse(apresentador.UsuarioExiste);
        }

        [Test]
        public void Executar_ComDadosValidos_UsuarioExiste()
        {
            requisicao.Senha = "teste";
            requisicao.Email = "teste@teste.com.br";

            executor.Executar(requisicao);

            Assert.IsTrue(apresentador.UsuarioExiste);
        }
    }
}
