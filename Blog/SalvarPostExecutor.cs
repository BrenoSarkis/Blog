using Blog.Entidades;
using Blog.Fronteiras.Executores.SalvarPost;
using Blog.Fronteiras.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog
{
    public class SalvarPostExecutor : ISalvarPostExecutor
    {
        private readonly IPostRepositorio postRepositorio;

        public SalvarPostExecutor(IPostRepositorio postRepositorio)
        {
            this.postRepositorio = postRepositorio;
        }

        public ISalvarPostApresentador Apresentador { get; set; }


        public void Executar(SalvarPostRequisicao requisicao)
        {
            var resultado = new SalvarPostResultado();

            try
            {
                var post = new Post();
                post.Titulo = requisicao.Titulo;
                post.Conteudo = requisicao.Conteudo;
                post.Tags = requisicao.Tags;
                post.Data = DateTime.Now;
                post.CaminhoDaImagemDaCapa = requisicao.CaminhoDaImagemDaCapa;
                this.postRepositorio.Salvar(post);
                resultado.NotificacaoDeSucesso = "Post salvo com sucesso.";
            }
            catch (Exception ex)
            {
                resultado.NotificacoesDeErro.Add("Erro ao salvar o post. Mensagem: " + ex.Message);
            }

            Apresentador.Apresentar(resultado);
        }
    }
}
