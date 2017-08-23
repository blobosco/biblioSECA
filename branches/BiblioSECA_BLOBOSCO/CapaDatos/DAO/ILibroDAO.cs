using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;

namespace CapaDatos.DAO
{
    public interface ILibroDAO
    {
        Libro GetById(int id);

        void Save(Libro libro);

        Libro GetLibrosByIsbnHQL(string isbn);

        IList<Libro> GetLibrosByIdAutor(int idAutor);

        IList<Libro> GetLibrosByIdCategoria(int idCategoria);

        IList<Libro> GetLibrosByComienzoDelTituloHQL(string tituloLibro);

        IList<Libro> GetLibrosByTitulo(string tituloLibro);

        IList<Libro> GetLibrosByDescripcion(string descripcionLibro);

        IList<String> GetTitulosLibrosByIdSocioPrestamo(int idSocio);

        IList<String> GetTitulosLibrosPrestadosYPenalizados();

        IList<int> GetLibrosConMayorCantidadDePenalizaciones();

        IList<Libro> GetAllLibros();
    }
}
