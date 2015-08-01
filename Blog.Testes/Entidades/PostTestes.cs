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
        public void Link_QuandoTodasAsInformacoesEstaoPreenchidas_MontaOLinkCorretamente()
        {
            var post = new Post();
            post.Data = new DateTime(2015, 01, 01);
            post.Titulo = "Um titulo de teste";

            string linkEsperado = "2015-01-01/Um-titulo-de-teste/";

            Assert.AreEqual(linkEsperado, post.Link);
        }

        [Test]
        public void Link_QuandoOTituloContemAcento_MontaOLinkSemAcento()
        {
            var post = new Post();
            post.Data = new DateTime(2015, 01, 01);
            post.Titulo = "í á ê";

            string linkEsperado = "2015-01-01/i-a-e/";

            Assert.AreEqual(linkEsperado, post.Link);
        }
    }
}
