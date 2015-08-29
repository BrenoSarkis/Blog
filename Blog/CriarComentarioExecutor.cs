using Blog.Entidades;
using Blog.Fronteiras.Executores.CriarComentario;
using Blog.Fronteiras.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog
{
    public class CriarComentarioExecutor : ICriarComentarioExecutor
    {
        private readonly IPostRepositorio postRepositorio;

        public CriarComentarioExecutor(IPostRepositorio postRepositorio)
        {
            this.postRepositorio = postRepositorio;
        }

        public ICriarComentarioApresentador Apresentador { get; set; }

        public void Executar(CriarComentarioRequisicao requisicao)
        {
            var resultado = new CriarComentarioResultado();

            try
            {
                var post = postRepositorio.ObterPorUrl(requisicao.UrlDoPost);

                var comentario = new Comentario();
                comentario.CodigoDoPost = post.Codigo;
                comentario.Nome = requisicao.Nome;
                comentario.Email = requisicao.Email;
                comentario.Mensagem = requisicao.Mensagem;
                comentario.Data = DateTime.Now;

                postRepositorio.SalvarComentario(comentario);

                resultado.Nome = comentario.Nome;
                resultado.Email = comentario.Email;
                resultado.Mensagem = comentario.Mensagem;
                resultado.Data = comentario.Data;

            }
            catch (Exception ex)
            {
                resultado.NotificacoesDeErro.Add("Erro ao criar comentário.");
            }

            this.Apresentador.Apresentar(resultado);
        }
    }
}
