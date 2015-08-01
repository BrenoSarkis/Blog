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
        private readonly IApresentador<ObterCitacaoResultado> apresentador;

        public ObterCitacaoExecutor(ICitacaoRepositorio citacaoRepositorio, IApresentador<ObterCitacaoResultado> apresentador)
        {
            this.citacaoRepositorio = citacaoRepositorio;
            this.apresentador = apresentador;
        }

        public void Executar()
        {
            var todasAsCitacoes = this.citacaoRepositorio.Todos();
            var r = new Random();
            Citacao citacaoEscolhida = todasAsCitacoes.OrderBy(c => r.Next()).FirstOrDefault();
            this.apresentador.Apresentar(new ObterCitacaoResultado
            { 
                Autor = citacaoEscolhida.Autor,
                Texto = citacaoEscolhida.Texto
            });
        }
    }
}
