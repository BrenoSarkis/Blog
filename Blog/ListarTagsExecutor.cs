using Blog.Fronteiras.Executores.ListarTags;
using Blog.Fronteiras.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog
{
    public class ListarTagsExecutor : IListarTagsExecutor
    {
        private readonly IPostRepositorio postRepositorio;

        public ListarTagsExecutor(IPostRepositorio postRepositorio)
        {
            this.postRepositorio = postRepositorio;
        }

        public IListarTagsApresentador Apresentador { get; set; }

        public void Executar()
        {
            var resultado = new ListarTagsResultado();
            var tags = this.postRepositorio.ListarTodasAsTagsUnicas();
            resultado.Tags = tags;
            Apresentador.Apresentar(resultado);    
        }
    }
}
