using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;

namespace CapaDatos.DAO
{
    public interface ILibroDAO
    {
        Libro GetById(long id);

        void Save(Libro libro);

        Libro GetLibroByIsbnHQL(string isbn);

        IList<Libro> GetLibrosByIdAutor(long idAutor);

        IList<Libro> GetLibrosByIdCategoria(long idCategoria);

        IList<Libro> GetLibrosByComienzoDelTituloHQL(string tituloLibro);

        IList<Libro> GetLibrosByTitulo(string tituloLibro);

        IList<Libro> GetLibrosByDescripcion(string descripcionLibro);

        IList<String> GetTitulosLibrosByIdSocioPrestamo(long idSocio);

        IList<String> GetTitulosLibrosPrestadosYPenalizados();

        IList<Libro> GetAllLibros();
    }
}
