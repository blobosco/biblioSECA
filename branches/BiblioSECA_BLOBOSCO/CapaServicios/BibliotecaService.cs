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
        private IAutorDAO AutorDAO { get; set; }
        private IPrestamoDAO PrestamoDAO { get; set; }
        private IPenalizacionDAO PenalizacionDAO { get; set; }
        private ICategoriaDAO CategoriaDAO { get; set; }
        private ISocioDAO SocioDAO { get; set; }

        public BibliotecaService(ILibroDAO libroDAO, IAutorDAO autorDAO, IPrestamoDAO prestamoDAO, IPenalizacionDAO penalizacionDAO, ICategoriaDAO categoriaDAO, ISocioDAO socioDAO)
        {
            this.LibroDAO = libroDAO;
            this.AutorDAO = autorDAO;
            this.PenalizacionDAO = penalizacionDAO;
            this.CategoriaDAO = CategoriaDAO;
            this.PrestamoDAO = prestamoDAO;
            this.SocioDAO = socioDAO;
        }

        private Libro GetLibroFromDTO(LibroDTO libroDTO)
        {
            Libro libro = new Libro();
            SetLibroFromDTO(libroDTO, libro);
            return libro;
        }

        public void SetLibroFromDTO(LibroDTO libroDTO, Libro libro)
        {
            libro.ISBN = libroDTO.ISBN;
            libro.Titulo = libroDTO.Titulo;
            libro.Descripcion = libroDTO.Descripcion;
            libro.Estado = libroDTO.Estado;
            libro.Categoria = CategoriaDAO.GetById(libroDTO.Categoria.Id);
            libro.Autor = AutorDAO.GetById(libroDTO.Autor.Id);
        }

        private LibroDTO GetDTOFromLibro(Libro libro)
        {
            LibroDTO libroDTO = new LibroDTO();

            libroDTO.Id = libro.Id;
            libroDTO.Autor = libro.Autor;
            libroDTO.Categoria = libro.Categoria;
            libroDTO.Descripcion = libro.Descripcion;
            libroDTO.Estado = libro.Estado;
            libroDTO.ISBN = libro.ISBN;
            libroDTO.Titulo = libro.Titulo;

            return libroDTO;
        }

        public void RegistrarLibro(LibroDTO libroDTO)
        {
            Libro libro = new Libro();
            LibroDAO.Save(libro);
            libroDTO.Id = libro.Id;
        }

        public IList<LibroDTO> GetLibrosByAutor(long idAutor)
        {
            IList<Libro> libros = this.LibroDAO.GetLibrosByIdAutor(idAutor);
            IList<LibroDTO> librosDTO = new List<LibroDTO>(); 

            foreach(Libro libro in libros)
            {
                librosDTO.Add(GetDTOFromLibro(libro));
            }

            return librosDTO;
        }

        public IList<LibroDTO> GetLibrosByCategoria(long idCategoria)
        {
            IList<Libro> libros = this.LibroDAO.GetLibrosByIdCategoria(idCategoria);
            IList<LibroDTO> librosDTO = new List<LibroDTO>();

            foreach (Libro libro in libros)
            {
                librosDTO.Add(GetDTOFromLibro(libro));
            }

            return librosDTO;
        }

        public IList<LibroDTO> GetLibrosByTitulo(string titulo)
        {
            IList<Libro> libros = this.LibroDAO.GetLibrosByTitulo(titulo);
            IList<LibroDTO> librosDTO = new List<LibroDTO>();

            foreach (Libro libro in libros)
            {
                librosDTO.Add(GetDTOFromLibro(libro));
            }

            return librosDTO;
        }

        public LibroDTO GetLibroByIsbn(string isbn)
        {
            Libro libro = this.LibroDAO.GetLibroByIsbnHQL(isbn);
            LibroDTO libroDTO = GetDTOFromLibro(libro);
            return libroDTO;
        }

        private Socio GetSocioFromDTO(SocioDTO socioDTO)
        {
            Socio socio = new Socio();
            SetSocioFromDTO(socioDTO, socio);
            return socio;
        }

        public void SetSocioFromDTO(SocioDTO socioDTO, Socio socio)
        {
            socio.Id = socioDTO.Id;
            socio.Nombre = socioDTO.Nombre;
            socio.Apellido = socioDTO.Apellido;
            socio.NombreUsuario = socioDTO.NombreUsuario;
            socio.Estado = socioDTO.Estado;
        }

        public SocioDTO GetDTOFromSocio(Socio socio)
        {
            SocioDTO socioDTO = new SocioDTO();

            socioDTO.Id = socio.Id;
            socioDTO.Nombre = socio.Nombre;
            socioDTO.Apellido = socio.Apellido;
            socioDTO.NombreUsuario = socio.NombreUsuario;
            socioDTO.Estado = socio.Estado;

            return socioDTO;
        }

        public void RegistrarSocio(SocioDTO socioDTO)
        {
            Socio socio = GetSocioFromDTO(socioDTO);
            SocioDAO.Save(socio);
            socioDTO.Id = socio.Id;
        }

        public IList<SocioDTO> GetSociosByNombre(string nombre)
        {
            IList<Socio> socios = this.SocioDAO.GetSociosByNombre(nombre);
            IList<SocioDTO> sociosDTO = new List<SocioDTO>();

            foreach (Socio socio in socios)
            {
                sociosDTO.Add(GetDTOFromSocio(socio));
            }

            return sociosDTO;
        }

        public IList<SocioDTO> GetSociosByApellido(string apellido)
        {
            IList<Socio> socios = this.SocioDAO.GetSociosByApellido(apellido);
            IList<SocioDTO> sociosDTO = new List<SocioDTO>();

            foreach (Socio socio in socios)
            {
                sociosDTO.Add(GetDTOFromSocio(socio));
            }

            return sociosDTO;
        }

        public SocioDTO GetSocioByNombreUsuario(string nombreUsuario)
        {
            Socio socio = this.SocioDAO.GetSocioByNombreUsuario(nombreUsuario);
            SocioDTO socioDTO = GetDTOFromSocio(socio);
            return socioDTO;
        }

        private Prestamo GetPrestamoFromDTO (PrestamoDTO prestamoDTO)
        {
            Prestamo prestamo = new Prestamo();
            SetPrestamoFromDTO(prestamoDTO, prestamo);
            return prestamo;
        }

        public void SetPrestamoFromDTO(PrestamoDTO prestamoDTO, Prestamo prestamo)
        {
            prestamo.FechaDevolucion = prestamoDTO.FechaDevolucion;
            prestamo.FechaInicio = prestamoDTO.FechaInicio;
            prestamo.FechaVencimiento = prestamoDTO.FechaVencimiento;
            prestamo.Socio = prestamoDTO.Socio;
            prestamo.Libro = prestamoDTO.Libro;
            prestamo.Estado = prestamoDTO.Estado;            
        }

        public PrestamoDTO GetDTOFromPrestamo(Prestamo prestamo)
        {
            PrestamoDTO prestamoDTO = new PrestamoDTO();

            prestamoDTO.FechaDevolucion = prestamo.FechaDevolucion;
            prestamoDTO.FechaInicio = prestamo.FechaInicio;
            prestamoDTO.FechaVencimiento = prestamo.FechaVencimiento;
            prestamoDTO.Socio = prestamo.Socio;
            prestamoDTO.Libro = prestamo.Libro;
            prestamoDTO.Estado = prestamo.Estado;

            return prestamoDTO;
        }

        public IList<PrestamoDTO> GetPrestamoByFechaInicio(DateTime fechaInicio)
        {
            IList<Prestamo> prestamos = this.PrestamoDAO.GetPrestamosByFechaInicio(fechaInicio);
            IList<PrestamoDTO> prestamosDTO = new List<PrestamoDTO>();

            foreach (Prestamo prestamo in prestamos)
            {
                prestamosDTO.Add(GetDTOFromPrestamo(prestamo));
            }

            return prestamosDTO;
        }
    }
}
