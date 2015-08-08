using Blog.Fronteiras.Executores.Login;
using Blog.Fronteiras.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blog
{
    public class LoginExecutor : ILoginExecutor
    {
        private readonly IUsuarioRepositorio usuarioRepositorio;

        public LoginExecutor(IUsuarioRepositorio usuarioRepositorio)
        {
            this.usuarioRepositorio = usuarioRepositorio;
        }

        public ILoginApresentador Apresentador { get; set; }

        public void Executar(LoginRequisicao requisicao)
        {
            var resultado = new LoginResultado();
            var hashDaSenha = PasswordHash.GerarHash(PasswordHash.CriarSalt(requisicao.Senha), requisicao.Senha);

            resultado.UsuarioExiste = this.usuarioRepositorio.UsuarioExiste(requisicao.Email, hashDaSenha);

            Apresentador.Apresentar(resultado);
        }
    }

    public static class Teste
    {
        public static string CreateSalt(int size)
        {
            //Generate a cryptographic random number.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number.
            return Convert.ToBase64String(buff);
        }

        public static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }
    }

    public static class PasswordHash
    {
        public static string CriarSalt(string senha)
        {
            Rfc2898DeriveBytes hasher = new Rfc2898DeriveBytes(senha,
                System.Text.Encoding.Default.GetBytes("sarkisbreno@gmail.com"), 10000);
            return Convert.ToBase64String(hasher.GetBytes(50));
        }

        public static string GerarHash(string salt, string senha)
        {
            Rfc2898DeriveBytes Hasher = new Rfc2898DeriveBytes(senha,
                System.Text.Encoding.Default.GetBytes(salt), 10000);
            return Convert.ToBase64String(Hasher.GetBytes(50));
        }
    }
}
