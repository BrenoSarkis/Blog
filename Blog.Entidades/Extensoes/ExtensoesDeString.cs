using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entidades.Extensoes
{
    public static class ExtensoesDeString
    {
        public static string RemoverAcentos(this string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return texto;

            texto = texto.Normalize(NormalizationForm.FormD);
            var chars = texto.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray();
            return new string(chars).Normalize(NormalizationForm.FormC);
        }
    }
}
