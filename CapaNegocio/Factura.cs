using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class Factura : Penalizacion
    {
        private const int LAPSO_FACTURAS = 10;

        public virtual long IdFactura { get; set; }

        public virtual DateTime? FechaRecepcion { get; set; }

        public Factura() { }

        public Factura(DateTime fechaInicio)
        {
            this.FechaInicio = fechaInicio;
            this.FechaRecepcion = fechaInicio.AddDays(LAPSO_FACTURAS);
        }
    }
}
