using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

using SendGrid;
using Blog.Fronteiras.Email;

namespace Blog.Email
{
    public class EnviadorDeEmail : IEnviadorDeEmail
    {
        public void Enviar(string nome, string email, string assunto, string mensagem)
        {
            var myMessage = new SendGridMessage();

            myMessage.From = new MailAddress(email, nome);
            myMessage.AddTo("sarkisbreno@gmail.com");
            myMessage.Subject = assunto;
            myMessage.Text = mensagem;

            var username = "azure_f3c07672dc65ab85ffa8bdd9d6f40fee@azure.com";
            var pswd = "20LTaus55pBSA3m";

            /* Alternatively, you may store these credentials via your Azure portal
               by clicking CONFIGURE and adding the key/value pairs under "app settings".
               Then, you may access them as follows: 
               var username = System.Environment.GetEnvironmentVariable("SENDGRID_USER"); 
               var pswd = System.Environment.GetEnvironmentVariable("SENDGRID_PASS");
               assuming you named your keys SENDGRID_USER and SENDGRID_PASS */

            var credentials = new NetworkCredential(username, pswd); 
            var transportWeb = new Web(credentials);

            // Send the email.
            // You can also use the **DeliverAsync** method, which returns an awaitable task.
            transportWeb.DeliverAsync(myMessage);
        }
    }
}