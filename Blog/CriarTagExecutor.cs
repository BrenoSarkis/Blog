using Blog.Entidades;
using Blog.Fronteiras.Executores.CriarTag;
using Blog.Fronteiras.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog
{
    public class CriarTagExecutor : ICriarTagExecutor
    {
        private readonly ITagRepositorio tagRepositorio;
        private readonly ICriarTagApresentador apresentador;


        public CriarTagExecutor(ITagRepositorio tagRepositorio, ICriarTagApresentador apresentador)
        {
            this.tagRepositorio = tagRepositorio;
            this.apresentador = apresentador;
        }


        public void Executar(CriarTagRequisicao requisicao)
        {
            var resultado = new CriarTagResultado();
            var novaTag = new Tag { Nome = requisicao.Nome };
            //this.tagRepositorio.Salvar(novaTag);
            resultado.Nome = novaTag.Nome;
            this.apresentador.Apresentar(resultado);
        }
    }
}
