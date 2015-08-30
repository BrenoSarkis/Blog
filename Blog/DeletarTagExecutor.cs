using Blog.Fronteiras.Executores.DeletarTag;
using Blog.Fronteiras.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog
{
    public class DeletarTagExecutor : IDeletarTagExecutor
    {
        private readonly IPostRepositorio postRepositorio;

        public DeletarTagExecutor(IPostRepositorio postRepositorio)
        {
            this.postRepositorio = postRepositorio;
        }

        public IDeletarTagApresentador Apresentador { get; set; }

        public void Executar(DeletarTagRequisicao requisicao)
        {
            var resultado = new DeletarTagResultado();

            var tag = this.postRepositorio.ObterTag(requisicao.Tag, requisicao.CodigoDoPost);
            this.postRepositorio.DeletarTag(tag);

            Apresentador.Apresentar(resultado);
        }
    }
}
