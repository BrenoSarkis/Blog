using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Utilidades
{
    public static class MapeadorDeObjetos
    {
        public static TSaida TransformarEm<TSaida>(this object instancia) where TSaida : class
        {
            return Mapper.DynamicMap<TSaida>(instancia);
        }

        public static TSaida[] TransformarEmListaDe<TSaida>(this IEnumerable<object> instancias) where TSaida : class
        {
            return instancias.Select(i => Mapper.DynamicMap<TSaida>(i)).ToArray();
        }
    }
}
