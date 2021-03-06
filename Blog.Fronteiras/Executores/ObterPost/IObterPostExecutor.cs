﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Fronteiras.Executores.ObterPost
{
    public interface IObterPostExecutor : IExecutor<ObterPostRequisicao>
    {
        IObterPostApresentador Apresentador { get; set; }
    }
}
