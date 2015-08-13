using Blog.Fronteiras.Email;
using Blog.Fronteiras.Executores.EnviarEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog
{
    public class EnviarEmailExecutor : IEnviarEmailExecutor
    {
        private readonly IEnviadorDeEmail enviadorDeEmail;

        public EnviarEmailExecutor(IEnviadorDeEmail enviadorDeEmail)
        {
            this.enviadorDeEmail = enviadorDeEmail;
        }

        public IEnviarEmailApresentador Apresentador { get; set; }

        public void Executar(EnviarEmailRequisicao requisicao)
        {
            var resultado = new EnviarEmailResultado();

            try
            {
                this.enviadorDeEmail.Enviar(requisicao.Nome, requisicao.Email, requisicao.Assunto, requisicao.Mensagem);
            }
            catch (Exception) 
            {
                resultado.Mensagem = "Erro ao enviar o e-mail.";
            }

            this.Apresentador.Apresentar(resultado);
        }
    }
}
