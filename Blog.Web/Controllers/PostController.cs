using Blog.Fronteiras.Executores.SalvarPost;
using Blog.Repositorios;
using Blog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class PostController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Novo()
        {
            return View(new NovoPostViewModel());
        }

        public void Salvar(NovoPostViewModel novoPost)
        {
            var requisicao = new SalvarPostRequisicao
            {
                Titulo = novoPost.Titulo,
                Conteudo = novoPost.Conteudo,
                CaminhoDaImagemDaCapa = novoPost.CaminhoDaImagemDaCapa,
                Tags = novoPost.Tags
            };

            new SalvarPostExecutor(new PostRepositorio()).Executar(requisicao);
        }


    }
}