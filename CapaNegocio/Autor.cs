﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class Autor
    {
        public virtual int Id { get; set; }

        public virtual String Nombre { get; set; }

        //public List<Libro> librosEscritos;

        public Autor() { }
    }
}