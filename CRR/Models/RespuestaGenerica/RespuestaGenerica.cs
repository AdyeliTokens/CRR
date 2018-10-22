﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRR.Models.RespuestaGenerica
{
    public interface IRespuestaServicio<T>
    {

        bool EjecucionCorrecta { get; }


        string Mensaje { get; set; }


        T Respuesta { get; set; }

    }
}
