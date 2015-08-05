using Blog.Entidades;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Testes.Entidades
{
    [TestFixture]
    public class PostTestes
    {
        [Test]
        public void Url_QuandoTodasAsInformacoesEstaoPreenchidas_MontaAUrlCorretamente()
        {
            var post = new Post();
            post.Data = new DateTime(2015, 01, 01);
            post.Titulo = "Um titulo de teste";

            string urlEsperada = "2015/01/01/Um-titulo-de-teste/";

            Assert.AreEqual(urlEsperada, post.Url);
        }

        [Test]
        public void Url_QuandoOTituloContemAcento_MontaAUrlSemAcento()
        {
            var post = new Post();
            post.Data = new DateTime(2015, 01, 01);
            post.Titulo = "í á ê";

            string urlEsperada = "2015/01/01/i-a-e/";

            Assert.AreEqual(urlEsperada, post.Url);
        }
    }
}
