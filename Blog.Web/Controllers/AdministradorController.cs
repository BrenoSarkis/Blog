using Blog.Fronteiras.Executores.Login;
using Blog.Web.Apresentadores;
using Blog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Blog.Web.Controllers
{
    public class AdministradorController : Controller
    {
        private readonly ILoginExecutor loginExecutor;

        public AdministradorController(ILoginExecutor loginExecutor)
        {
            this.loginExecutor = loginExecutor;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {
            var apresentador = new LoginApresentador();
            var requisicao = new LoginRequisicao
            {
                Email = viewModel.Email,
                Senha = viewModel.Senha
            };

            this.loginExecutor.Apresentador = apresentador;
            this.loginExecutor.Executar(requisicao);

            if (apresentador.UsuarioExiste)
            {
                //create the authentication ticket
                var authTicket = new FormsAuthenticationTicket(
                  1,
                  viewModel.Email,  //user id
                  DateTime.Now,
                  DateTime.Now.AddMinutes(20),  // expiry
                  true,  //true to remember
                  "", //roles 
                  "/"
                );

                //encrypt the ticket and add it to a cookie
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "Blog");
            }

            return View();
        }
    }
}