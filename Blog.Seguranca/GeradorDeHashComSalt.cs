using Blog.Fronteiras.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Seguranca
{
    public class GeradorDeHashComSalt : IGeradorDeHashComSalt
    {
        public string Gerar(string texto)
        {
            Rfc2898DeriveBytes hasher = new Rfc2898DeriveBytes(texto,
    System.Text.Encoding.Default.GetBytes("sarkisbreno@gmail.com"), 10000);
            var salt = Convert.ToBase64String(hasher.GetBytes(50));

            hasher = new Rfc2898DeriveBytes(texto,
                System.Text.Encoding.Default.GetBytes(salt), 10000);
            return Convert.ToBase64String(hasher.GetBytes(50));
        }
    }
}
