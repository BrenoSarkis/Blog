using Blog.Fronteiras.Executores;
using Blog.Fronteiras.Executores.ObterCitacao;
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
        public JsonResult Contato(ContatoViewModel viewModel)
        {
            return null;
        }
    }

    public class ObterCitacaoApresentador : IApresentador<ObterCitacaoResultado>
    {
        public string Citacao { get; private set; }

        public void Apresentar(ObterCitacaoResultado resultado)
        {
            Citacao = String.Format(@"""{0}"" - {1}", resultado.Texto, resultado.Autor);
        }
    }
}