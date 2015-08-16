using Blog.Fronteiras.Executores.ObterPost;
using Blog.Fronteiras.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog
{
    public class ObterPostExecutor : IObterPostExecutor
    {
        private readonly IPostRepositorio postRepositorio;

        public ObterPostExecutor(IPostRepositorio postRepositorio)
        {
            this.postRepositorio = postRepositorio;
        }

        public IObterPostApresentador Apresentador { get; set; }

        public void Executar(ObterPostRequisicao requisicao)
        {
            var resultado = new ObterPostResultado();

            var post = this.postRepositorio.ObterPorUrl(requisicao.Url);

            resultado.CaminhoDaImagemDaCapa = post.CaminhoDaImagemDaCapa;
            resultado.Conteudo = post.Conteudo;
            resultado.Data = post.Data;
            resultado.Tags = post.Tags;
            resultado.Titulo = post.Titulo;
            resultado.Url = post.Url;
            resultado.Comentarios = post.Comentarios.Select(c => new ObterPostResultado.Comentario
            {
                Nome = c.Nome,
                Email = c.Email,
                Data = c.Data,
                Mensagem = c.Mensagem
            });
            Apresentador.Apresentar(resultado);
        }
    }
}
