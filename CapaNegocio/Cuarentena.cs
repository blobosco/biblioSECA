using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class Cuarentena : Penalizacion
    {
        public virtual long IdCuarentena { get; set; }

        public virtual DateTime FechaFinalizacion { get; set; }

        public Cuarentena() { }

        public Cuarentena(DateTime fechaInicio, DateTime fechaFinalizacion)
        {
            this.FechaInicio = fechaInicio;
            this.FechaFinalizacion = fechaFinalizacion;
        }
    }
}
