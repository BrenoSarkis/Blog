using Blog.Entidades;
using Blog.Fronteiras.Executores;
using Blog.Fronteiras.Executores.ObterCitacao;
using Blog.Fronteiras.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog
{
    public class ObterCitacaoExecutor : IObterCitacaoExecutor
    {
        private readonly ICitacaoRepositorio citacaoRepositorio;

        public ObterCitacaoExecutor(ICitacaoRepositorio citacaoRepositorio)
        {
            this.citacaoRepositorio = citacaoRepositorio;
        }

        public IObterCitacaoApresentador Apresentador { get; set; }

        public void Executar()
        {
            var todasAsCitacoes = this.citacaoRepositorio.Todos();
            var r = new Random();
            Citacao citacaoEscolhida = todasAsCitacoes.OrderBy(c => r.Next()).FirstOrDefault();
            this.Apresentador.Apresentar(new ObterCitacaoResultado
            { 
                Autor = citacaoEscolhida.Autor,
                Texto = citacaoEscolhida.Texto
            });
        }
    }
}
