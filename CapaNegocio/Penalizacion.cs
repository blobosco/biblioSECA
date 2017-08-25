using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public abstract class Penalizacion
    {
        public virtual long Id { get; set; }

        public virtual DateTime FechaInicio { get; set; }

        public virtual DateTime? FechaCumplimiento { get; set; }

        public virtual Prestamo Prestamo { get; set; }
    }
}
