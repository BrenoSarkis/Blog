using Blog.Fronteiras.Executores;
using Blog.Fronteiras.Executores.EnviarEmail;
using Blog.Fronteiras.Executores.ObterCitacao;
using Blog.Web.Apresentadores;
using Blog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEnviarEmailExecutor enviarEmailExecutor;

        public HomeController(IEnviarEmailExecutor enviarEmailExecutor)
        {
            this.enviarEmailExecutor = enviarEmailExecutor;
        }

        public ActionResult Index()
        {
            //var apresentador = new ObterCitacaoApresentador();
            //var executor = new ObterCitacaoExecutor(new CitacaoRepositorio(), apresentador);
            //executor.Executar();
            //ViewBag.Citacao = apresentador.Citacao;
            return View();
        }

        public ActionResult Sobre()
        {
            return View();
        }

        public ActionResult Contato()
        {
            return View(new ContatoViewModel());
        }

        [HttpPost]
        public ActionResult Contato(ContatoViewModel viewModel)
        {
            var requisicao = new EnviarEmailRequisicao();
            requisicao.Nome = viewModel.Nome;
            requisicao.Email = viewModel.Email;
            requisicao.Assunto = viewModel.Assunto;
            requisicao.Mensagem = viewModel.Mensagem;

            var apresentador = new EnviarEmailApresentador();

            this.enviarEmailExecutor.Apresentador = apresentador;
            this.enviarEmailExecutor.Executar(requisicao);

            viewModel.MensagemDeErro.Texto = apresentador.Mensagem.Texto;

            return View(viewModel);
        }
    }

    public class ObterCitacaoApresentador : IObterCitacaoApresentador
    {
        public string Citacao { get; private set; }

        public void Apresentar(ObterCitacaoResultado resultado)
        {
            Citacao = String.Format(@"""{0}"" - {1}", resultado.Texto, resultado.Autor);
        }
    }
}