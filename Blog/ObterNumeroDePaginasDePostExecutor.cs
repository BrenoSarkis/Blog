using Blog.Fronteiras.Executores.ObterNumeroDePaginasDePost;
using Blog.Fronteiras.Repositorios;
using System;

namespace Blog
{
    public class ObterNumeroDePaginasDePostExecutor : IObterNumeroDePaginasDePostExecutor
    {
        private readonly IPostRepositorio postRepositorio;

        public ObterNumeroDePaginasDePostExecutor(IPostRepositorio postRepositorio)
        {
            this.postRepositorio = postRepositorio;
        }

        public IObterNumeroDePaginasDePostApresentador Apresentador { get; set; }

        public void Executar()
        {
            var resultado = new ObterNumeroDePaginasDePostResultado();
            resultado.Numero =  (int)Math.Ceiling((double)this.postRepositorio.ContagemDePosts() / 5);
            this.Apresentador.Apresentar(resultado);
        }
    }
}