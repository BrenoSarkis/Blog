﻿using Blog.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Fronteiras.Repositorios
{
    public interface ITagRepositorio
    {
        void Salvar(Tag tag);
    }
}
