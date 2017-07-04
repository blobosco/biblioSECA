using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;
using CapaServicios.Factory;
using System.Collections;
using CapaServicios.DTOs;
using CapaDatos.DAO;

namespace CapaServicios
{
    public class BibliotecaService : IBibliotecaService
    {
        private ILibroDAO LibroDAO { get; set; }

        public BibliotecaService(ILibroDAO libroDAO)
        {
            this.LibroDAO = libroDAO;
        }

        public void RegistrarLibro(string isbn)
        {
            Libro libro = new Libro(isbn);

            LibroDAO.Save(libro);
        }

    }
}
