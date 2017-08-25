using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaServicios.DTOs
{
    public class PrestamoDTO
    {
        public long Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public Libro Libro { get; set; }
        public Socio Socio { get; set; }
        public EstadoPrestamo Estado { get; set; }
    }
}
