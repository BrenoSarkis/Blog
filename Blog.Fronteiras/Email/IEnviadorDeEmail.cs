using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Fronteiras.Email
{
    public interface IEnviadorDeEmail
    {
        void Enviar(string nome, string email, string assunto, string mensagem);
    }
}
