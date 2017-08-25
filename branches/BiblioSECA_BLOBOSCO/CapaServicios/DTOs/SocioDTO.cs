using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaServicios.DTOs
{
    public class SocioDTO
    {
        public long Id { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String NombreUsuario { get; set; }
        public EstadoSocio Estado { get; set; }
    }
}
