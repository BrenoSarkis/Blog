using Ninject.Extensions.Conventions;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Blog.Fronteiras.Repositorios;
using Blog.Repositorios;
using Blog.Fronteiras.Executores.SalvarPost;
using Blog.Fronteiras.Executores.ListarPosts;
using Blog.Fronteiras.Executores.ListarTags;
using Blog.Fronteiras.Executores.ObterPost;
using Blog.Fronteiras.Executores.Login;
using Blog.Fronteiras.Seguranca;
using Blog.Seguranca;
using Blog.Fronteiras.Email;
using Blog.Email;
using Blog.Fronteiras.Executores.EnviarEmail;
using Blog.Fronteiras.Executores.ObterCitacao;
using Blog.Fronteiras.Executores.CriarComentario;
using Blog.Fronteiras.Executores.ObterNumeroDePaginasDePost;

namespace Blog.InversaoDeControle
{
    public static class InversorDeControle
    {
        private static IKernel kernel;

        public static void Instalar(IKernel k)
        {
            //kernel.Bind(x => 
            //    x.FromAssembliesInPath("*") // Scans currently assembly
            //     .SelectAllClasses() // Retrieve all non-abstract classes
            //     .BindDefaultInterface() // Binds the default interface to them;
            //);
            kernel = k;

            k.Bind<IPostRepositorio>().To<PostRepositorio>();
            k.Bind<ISalvarPostExecutor>().To<SalvarPostExecutor>();
            k.Bind<IListarPostsExecutor>().To<ListarPostsExecutor>();
            k.Bind<IListarTagsExecutor>().To<ListarTagsExecutor>();
            k.Bind<IObterPostExecutor>().To<ObterPostExecutor>();
            k.Bind<IUsuarioRepositorio>().To<UsuarioRepositorio>();
            k.Bind<ILoginExecutor>().To<LoginExecutor>();
            k.Bind<IGeradorDeHashComSalt>().To<GeradorDeHashComSalt>();
            k.Bind<IEnviadorDeEmail>().To<EnviadorDeEmail>();
            k.Bind<IEnviarEmailExecutor>().To<EnviarEmailExecutor>();
            k.Bind<IObterCitacaoExecutor>().To<ObterCitacaoExecutor>();
            k.Bind<ICitacaoRepositorio>().To<CitacaoRepositorio>();
            k.Bind<ICriarComentarioExecutor>().To<CriarComentarioExecutor>();
            k.Bind<IObterNumeroDePaginasDePostExecutor>().To<ObterNumeroDePaginasDePostExecutor>();
        }

        public static T Resolver<T>()
        {
            return kernel.Get<T>();
        }
    }
}
