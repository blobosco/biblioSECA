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
    public class FacturaPersistenceTestCase
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
        public void CreaPenalizacionFacturaNueva_SaveOrUpdate_GuardaBienDatos()
        {
            Autor autor = new Autor();
            autor.Nombre = "Juan";
            this.Session.SaveOrUpdate(autor);

            Categoria categoria = new Categoria();
            categoria.Nombre = "Terror";
            this.Session.SaveOrUpdate(categoria);

            Libro libro = new Libro();
            libro.Titulo = "Harry Potter";
            libro.Descripcion = "Harry es un mago que estudia en Hogwart";
            libro.Estado = EstadoLibro.Prestado;
            libro.ISBN = "11-4566-556-1";

            libro.Autor = autor;
            libro.Categoria = categoria;
            this.Session.SaveOrUpdate(libro);

            Socio socio = new Socio();
            socio.Nombre = "Juan";
            socio.Apellido = "Perez";
            socio.NombreUsuario = "jperez";
            socio.Estado = EstadoSocio.Activo;
            this.Session.SaveOrUpdate(socio);

            Prestamo prestamo = new Prestamo();
            prestamo.FechaInicio = new DateTime(2017, 07, 24);
            prestamo.FechaVencimiento = new DateTime(2017, 07, 26);
            prestamo.FechaDevolucion = null;
            prestamo.Estado = EstadoPrestamo.Activo;
            prestamo.Libro = libro;
            prestamo.Socio = socio;
            this.Session.SaveOrUpdate(prestamo);

            //Prestamo prestamoBase = this.Session.Load<Prestamo>(40);
            Factura factura = new Factura();
            factura.FechaRecepcion = new DateTime(2017, 07, 26);
            factura.FechaInicio = DateTime.Now;
            factura.FechaCumplimiento = new DateTime(2017, 07, 26);
            factura.Prestamo = prestamo;

            this.Session.SaveOrUpdate(factura);
            this.Session.Flush();
            Factura factura2 = this.Session.Load<Factura>(factura.Id);

            Assert.IsTrue(prestamo.Id > 0);
            Assert.AreEqual(factura.Id, factura2.Id);
            Assert.AreEqual(factura.FechaRecepcion, factura2.FechaRecepcion);
        }
    }
}