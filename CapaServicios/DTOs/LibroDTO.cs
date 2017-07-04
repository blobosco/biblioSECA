using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaServicios.DTOs
{
    public class LibroDTO
    {
        public long IdLibro { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public string Descripcion { get; set; }
        public long IdCantegoria { get; set; }
        public string NombreCategoria { get; set; }

        public long IdAutor {get;set;}
        public string NombreAutor { get; set; }

    }
}
