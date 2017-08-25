using CapaDatos.DAO;
using CapaNegocio;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaPruebas.DAO
{
    public class LibroDAOTestCase
    {
        private ISessionFactory SessionFactory;

        public ILibroDAO LibroDAO { get; set; }

        [SetUp]
        public void SetUp()
        {
            SessionFactory = (new Configuration()).Configure().BuildSessionFactory();
            ThreadStaticSessionContext.Bind(SessionFactory.OpenSession());
            LibroDAO = new LibroDAO(SessionFactory);
            SessionFactory.GetCurrentSession().BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            SessionFactory.GetCurrentSession().Transaction.Rollback();
            SessionFactory.GetCurrentSession().Close();
        }

        private ISession GetSession()
        {
            return SessionFactory.GetCurrentSession();
        }



        [Test]
        public void TestBusquedaLibrosPorISBN_GetLibrosByIsbnHQL_OK()
        {
            Libro libroBase = this.GetSession().Load<Libro>(50);

            Libro libroPrueba = LibroDAO.GetLibroByIsbnHQL("11-4566-556-1");

            Assert.IsNotNull(libroPrueba);
            Assert.AreEqual(libroBase.ISBN, libroPrueba.ISBN);
            
        }

        [Test]
        public void TestGetLibrosByIdAutor_GetLibrosByIdAutor_OK()
        {
            Autor autor = GetSession().Load<Autor>(50);

            IList<Libro> libros = LibroDAO.GetLibrosByIdAutor(autor.Id);

            Assert.IsNotNull(libros);
            Assert.AreEqual(libros.First().Autor.Id, 50);
            Assert.IsTrue(libros.Count > 0);
        }

        [Test]
        public void TestGetLibrosByIdCategoria_GetLibrosByIdCategoria_OK()
        {
            Categoria categoria = GetSession().Load<Categoria>(50);

            IList<Libro> libros = LibroDAO.GetLibrosByIdCategoria(categoria.Id);

            Assert.IsNotNull(libros);
            Assert.AreEqual(libros.First().Categoria.Id, 50);
            Assert.IsTrue(libros.Count > 0);
        }

        [Test]
        public void TestGetLibrosByUnaParteDelTitulo_GetLibrosByComienzoDelTituloHQL_OK()
        {
            Libro libro = GetSession().Load<Libro>(52);

            IList<Libro> libros = LibroDAO.GetLibrosByComienzoDelTituloHQL("Libro");

            Assert.IsNotNull(libros);
            Assert.AreEqual(libros.First().Titulo, libro.Titulo);
            Assert.IsTrue(libros.Count > 0);
        }

        [Test]
        public void TestGetLibrosByTitulo_GetLibrosByTitulo_OK()
        {
            Libro libro = GetSession().Load<Libro>(69);

            IList<Libro> libros = LibroDAO.GetLibrosByTitulo("El Libro De La Selva");

            Assert.IsNotNull(libros);
            Assert.IsTrue(libros.Count > 0);
            Assert.AreEqual(libros.First().Titulo, libro.Titulo);
        }

        [Test]
        public void TestGetLibrosByDescripcion_GetLibrosByDescripcion_OK()
        {
            Libro libro = GetSession().Load<Libro>(55);

            IList<Libro> libros = LibroDAO.GetLibrosByDescripcion("Descripcion");

            Assert.IsNotNull(libros);
            Assert.IsTrue(libros.Count > 0);
            Assert.AreEqual(libros.First().Descripcion, libro.Descripcion);
        }


        [Test]
        public void TestGetAllLibros_GetAllLibros_OK()
        {
            IList<Libro> libros = LibroDAO.GetAllLibros();

            Assert.IsNotNull(libros);
            Assert.IsTrue(libros.Count > 0);
        }

        [Test]
        public void TestGetTitulosLibrosByIdSocioPrestamo_GetTitulosLibrosByIdSocioPrestamo_OK()
        {
            Socio socio = GetSession().Load<Socio>(56);
            Libro libro = GetSession().Load<Libro>(67);

            IList<String> titulosLibros = LibroDAO.GetTitulosLibrosByIdSocioPrestamo(socio.Id);

            Assert.IsNotNull(titulosLibros);
            Assert.IsTrue(titulosLibros.Count > 0);
            Assert.AreEqual(titulosLibros.First(), libro.Titulo);
        }

        [Test]
        public void TestGetTitulosLibrosPrestadosYPenalizados_GetTitulosLibrosPrestadosYPenalizados_OK()
        {
            Libro libro = GetSession().Load<Libro>(53);

            IList<String> titulosLibros = LibroDAO.GetTitulosLibrosPrestadosYPenalizados();

            Assert.IsNotNull(titulosLibros);
            Assert.IsTrue(titulosLibros.Count > 0);
            Assert.AreEqual(titulosLibros.First(), libro.Titulo);
        }
    }

}
