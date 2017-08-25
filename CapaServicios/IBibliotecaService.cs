using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;
using System.Collections;
using CapaServicios.DTOs;

namespace CapaServicios
{
    public interface IBibliotecaService
    {
        void RegistrarLibro(LibroDTO libroDTO);

        void CrearLibro(LibroDTO libroDTO);

        IList<LibroDTO> GetLibrosByAutor(long idAutor);

        void SetLibroFromDTO(LibroDTO libroDTO, Libro libro);
    }
}
