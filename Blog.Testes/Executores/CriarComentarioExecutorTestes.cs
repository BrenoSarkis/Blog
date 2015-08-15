using Blog.Testes.Dublês.Repositorios;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Testes.Executores
{
    [TestFixture]
    public class CriarComentarioExecutorTestes
    {
        [Test]
        public void Executar_QuandoOCriadorNaoEhOAutor_CorDeFundoNaoEhPreenchida()
        {
            var executor = new CriarComentarioExecutor(new PostRepositorioMock());
            
        }
    }
}
