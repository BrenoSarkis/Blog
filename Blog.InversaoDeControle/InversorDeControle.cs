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

namespace Blog.InversaoDeControle
{
    public static class InversorDeControle
    {
        public static void Instalar(IKernel kernel)
        {
            //kernel.Bind(x => 
            //    x.FromAssembliesInPath("*") // Scans currently assembly
            //     .SelectAllClasses() // Retrieve all non-abstract classes
            //     .BindDefaultInterface() // Binds the default interface to them;
            //);
            kernel.Bind<IPostRepositorio>().To<PostRepositorio>();
            kernel.Bind<ISalvarPostExecutor>().To<SalvarPostExecutor>();
            kernel.Bind<IListarPostsExecutor>().To<ListarPostsExecutor>();
            kernel.Bind<IListarTagsExecutor>().To<ListarTagsExecutor>();
            kernel.Bind<IObterPostExecutor>().To<ObterPostExecutor>();
            kernel.Bind<IUsuarioRepositorio>().To<UsuarioRepositorio>();
            kernel.Bind<ILoginExecutor>().To<LoginExecutor>();
            kernel.Bind<IGeradorDeHashComSalt>().To<GeradorDeHashComSalt>();
        }
    }
}
