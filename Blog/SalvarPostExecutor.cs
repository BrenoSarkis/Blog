using Blog.Entidades;
using Blog.Fronteiras.Executores.SalvarPost;
using Blog.Fronteiras.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Extensoes;

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
                if (String.IsNullOrWhiteSpace(requisicao.Url))
                {
                    var post = new Post();
                    post.Titulo = requisicao.Titulo;
                    post.Conteudo = requisicao.Conteudo;
                    post.Tags = requisicao.Tags;
                    post.Data = DateTime.Now;
                    post.Url = String.Format(@"{0}/{1}/{2}/{3}", post.Data.Year, post.Data.Month.ToString().PadLeft(2, '0'),
                                                                             post.Data.Day.ToString().PadLeft(2, '0')).Replace(" ", "-").RemoverAcentos();
                    post.CaminhoDaImagemDaCapa = requisicao.CaminhoDaImagemDaCapa;
                    this.postRepositorio.Salvar(post);
                    resultado.NotificacaoDeSucesso = "Post salvo com sucesso.";
                }
                else
                {
                    var post = this.postRepositorio.ObterPorUrl(requisicao.Url);
                    post.Titulo = requisicao.Titulo;
                    post.Conteudo = requisicao.Conteudo;
                    post.Tags = requisicao.Tags;
                    post.Data = DateTime.Now;
                    post.CaminhoDaImagemDaCapa = requisicao.CaminhoDaImagemDaCapa;
                    this.postRepositorio.Atualizar(post);
                    resultado.NotificacaoDeSucesso = "Post editado com sucesso.";
                }
            }
            catch (Exception ex)
            {
                resultado.NotificacoesDeErro.Add("Erro ao salvar o post. Mensagem: " + ex.Message);
            }

            Apresentador.Apresentar(resultado);
        }
    }
}
