using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CapaNegocio;
using NHibernate;
using NHibernate.Cfg;
using CapaServicios.Factory;

namespace CapaPruebas.Persistencia
{
    [TestFixture]
    public class LibroPersistenceTestCase
    {
        private ISessionFactory SessionFactory;

        private ISession Session;

        private ITransaction Transaction;

        [SetUp]
        public void SetUp()
        {
            SessionFactory = (new Configuration()).Configure().BuildSessionFactory();
            this.Session = this.SessionFactory.OpenSession();
            this.Transaction = this.Session.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            this.Transaction.Rollback();
            this.Session.Close();
        }

        [Test]
        public void CreaLibroNuevo_SaveOrUpdate_GuardaBienDatos()
        {
            Libro libro = new Libro();
            libro.Titulo = "Harry Potter";
            libro.Descripcion = "Harry es un mago que estudia en Hogwart";
            libro.Estado = EstadoLibro.Disponible;
            libro.ISBN = "11-4566-556-1";

            Autor autor = new Autor();
            autor.Nombre = "Juan";
            this.Session.SaveOrUpdate(autor);
            libro.Autor = autor;

            Categoria categoria = new Categoria();
            categoria.Nombre = "Terror";
            this.Session.SaveOrUpdate(categoria);
            libro.Categoria = categoria;

            this.Session.SaveOrUpdate(libro);
            this.Session.Flush();
            this.Session.Clear();

            Libro libro2 = this.Session.Load<Libro>(libro.Id);

            Assert.IsTrue(libro.Id > 0);
            Assert.AreEqual(libro.ISBN, libro2.ISBN);
        }

    }
}
