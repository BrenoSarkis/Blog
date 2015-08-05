using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Entidades.Extensoes;

namespace Blog.Entidades
{
    public class Post
    {
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public DateTime Data { get; set; }
        public string CaminhoDaImagemDaCapa { get; set; }
        public string Url { get { return String.Format(@"{0}/{1}/{2}/{3}/", Data.Year, Data.Month.ToString().PadLeft(2, '0'),
                                                                             Data.Day.ToString().PadLeft(2, '0'),
                                                                             Titulo.Replace(" ", "-")).RemoverAcentos(); } }
        public string[] Tags { get; set; }
    }
}
