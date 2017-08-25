using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class Categoria
    {
        public virtual long Id { get; set; }

        public virtual String Nombre { get; set; }

        public Categoria() { }
    }
}
