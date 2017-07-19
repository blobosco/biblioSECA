using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class Cuarentena : Penalizacion
    {
        public virtual DateTime FechaFinalizacion { get; set; }

        public Cuarentena() { }

        public Cuarentena(DateTime fechaInicio, int dias)
        {
            this.FechaInicio = fechaInicio;
            
        }

        public void AsignarFechaFinalizacion(DateTime fechaFinalizacion)
        {
            this.FechaFinalizacion = fechaFinalizacion;
        }

        public bool CuarentenaCumplida (DateTime fechaDeHoy)
        {
            return (this.FechaFinalizacion < fechaDeHoy);
        }
    }
}
