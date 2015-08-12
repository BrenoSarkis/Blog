using Blog.Fronteiras.Executores.ObterCitacao;
using Blog.Web.App_Start;
using Blog.Web.Controllers;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Blog.Web
{
    public class MvcApplication : HttpApplication
    {
        private IObterCitacaoExecutor obterCitacaoExecutor;

        public MvcApplication()
        {

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            this.obterCitacaoExecutor = InversaoDeControle.InversorDeControle.Resolver<IObterCitacaoExecutor>();
            var apresentador = new ObterCitacaoApresentador();
            this.obterCitacaoExecutor.Apresentador = apresentador;
            this.obterCitacaoExecutor.Executar();
            HttpContext.Current.Session["Citacao"] = apresentador.Citacao;
        }
    }
}
