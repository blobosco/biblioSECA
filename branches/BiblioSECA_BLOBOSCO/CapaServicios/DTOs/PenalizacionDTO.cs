using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaServicios.DTOs
{
    public class PenalizacionDTO
    {
        public long Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaCumplimiento { get; set; }
        public Prestamo Prestamo { get; set; }
    }
}
