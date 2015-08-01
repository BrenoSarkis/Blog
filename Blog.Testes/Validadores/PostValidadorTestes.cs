//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Blog.Testes.Validadores
//{
//    [TestFixture]
//    public class PostValidadorTestes
//    {
//        private CentralDeNotificacao centralDeNotificacao;

//        [SetUp]
//        public void SetUp()
//        {
//            centralDeNotificacao = new CentralDeNotificacao();
//        }

//        [Test]
//        public void Criar_PostSemTitulo_GeraNotificacao()
//        {
//            var post = new Post(titulo: "", data: DateTime.Today);
//            var validador = new PostValidador(post, this.centralDeNotificacao);

//            validador.Validar();

//            Assert.True(this.centralDeNotificacao.ErrosContemCodigo("ERR001"));
//        }


//        [Test]
//        public void Criar_PostSemData_GeraNotificacao()
//        {
//            var post = new Post(titulo: "Teste", autor: "Breno", data: DateTime.MinValue);
//            var validador = new PostValidador(post, this.centralDeNotificacao);

//            validador.Validar();

//            Assert.True(this.centralDeNotificacao.ErrosContemCodigo("ERR003"));
//        }
//    }

//    public class Post
//    {
//        public Post(string titulo,DateTime data)
//        {
//            Titulo = titulo;
//            Data = data;
//        }

//        public string Titulo { get; set; }
//        public string CorpoNaoFormatado { get; set; }
//        public string CorpoEmHtml { get; set; }
//        public DateTime Data { get; set; }
//    }

//    public class PostValidador
//    {
//        private readonly Post post;
//        private readonly CentralDeNotificacao centralDeNotificacao;

//        public PostValidador(Post post, CentralDeNotificacao centralDeNotificacao)
//        {
//            this.post = post;
//            this.centralDeNotificacao = centralDeNotificacao;
//        }

//        public void Validar()
//        {
//            TituloFoiInformado();
//            DataFoiInformada();
//        }

//        public void TituloFoiInformado()
//        {
//            if (String.IsNullOrWhiteSpace(post.Titulo)) this.centralDeNotificacao.AdicionarErro("ERR001");
//        }

//        public void DataFoiInformada()
//        {
//            if (post.Data == DateTime.MinValue) this.centralDeNotificacao.AdicionarErro("ERR003");
//        }

//    }

//    public class CentralDeNotificacao: ICentralDeNotificacao
//    {
//        private readonly List<Tuple<string, string[]>> alertas;
//        private readonly List<Tuple<string, string[]>> erros;
//        private readonly List<Tuple<string, string[]>> sucessos;

//        public CentralDeNotificacao()
//        {
//            alertas = new List<Tuple<string, string[]>>();
//            erros = new List<Tuple<string, string[]>>();
//            sucessos = new List<Tuple<string, string[]>>();
//        }

//        public void AdicionarAlerta(string codigoDaNotificacao, params string[] valoresParaIncluirNaNotificacao)
//        {
//            if (!AlertasContemCodigo(codigoDaNotificacao))
//                alertas.Add(new Tuple<string, string[]>(codigoDaNotificacao, valoresParaIncluirNaNotificacao));
//        }

//        public void AdicionarErro(string codigoDaNotificacao, params string[] valoresParaIncluirNaNotificacao)
//        {
//            if (!ErrosContemCodigo(codigoDaNotificacao))
//                erros.Add(new Tuple<string, string[]>(codigoDaNotificacao, valoresParaIncluirNaNotificacao));
//        }

//        public void AdicionarSucesso(string codigoDaNotificacao, params string[] valoresParaIncluirNaNotificacao)
//        {
//            if (!SucessosContemCodigo(codigoDaNotificacao))
//                sucessos.Add(new Tuple<string, string[]>(codigoDaNotificacao, valoresParaIncluirNaNotificacao));
//        }

//        public bool AlertasContemCodigo(string codigoDaNotificacao)
//        {
//            return alertas.Select(a => a.Item1).Contains(codigoDaNotificacao);
//        }

//        public bool AlertasContemCodigos(params string[] codigosDeNotificacao)
//        {
//            return alertas.Any(a => codigosDeNotificacao.Contains(a.Item1));
//        }

//        public bool ErrosContemCodigo(string codigoDaNotificacao)
//        {
//            return erros.Select(a => a.Item1).Contains(codigoDaNotificacao);
//        }

//        public bool ErrosContemCodigos(params string[] codigosDeNotificacao)
//        {
//            return erros.Any(a => codigosDeNotificacao.Contains(a.Item1));
//        }

//        public bool PossuiAlertas()
//        {
//            return alertas.Any();
//        }

//        public bool PossuiErros()
//        {
//            return erros.Any();
//        }

//        public bool PossuiSucessos()
//        {
//            return sucessos.Any();
//        }

//        public bool SucessosContemCodigo(string codigoDaNotificacao)
//        {
//            return sucessos.Select(a => a.Item1).Contains(codigoDaNotificacao);
//        }

//        public bool SucessosContemCodigos(params string[] codigosDeNotificacao)
//        {
//            return sucessos.Any(a => codigosDeNotificacao.Contains(a.Item1));
//        }
//    }

//    public interface ICentralDeNotificacao
//    {
//        void AdicionarAlerta(string codigoDaNotificacao, params string[] valoresParaIncluirNaNotificacao);
//        void AdicionarErro(string codigoDaNotificacao, params string[] valoresParaIncluirNaNotificacao);
//        void AdicionarSucesso(string codigoDaNotificacao, params string[] valoresParaIncluirNaNotificacao);

//        bool AlertasContemCodigo(string codigoDaNotificacao);
//        bool AlertasContemCodigos(params string[] codigosDeNotificacao);

//        bool ErrosContemCodigo(string codigoDaNotificacao);
//        bool ErrosContemCodigos(params string[] codigosDeNotificacao);

//        bool PossuiAlertas();
//        bool PossuiErros();
//        bool PossuiSucessos();

//        bool SucessosContemCodigo(string codigoDaNotificacao);
//        bool SucessosContemCodigos(params string[] codigosDeNotificacao);
//    }
//}
