using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaServicios.DTOs
{
    public class LibroDTO
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public string Descripcion { get; set; }
        public Categoria Categoria { get; set; }
        public Autor Autor {get;set;}
        public EstadoLibro Estado { get; set; }
    }
}
