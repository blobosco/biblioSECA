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
    public class PrestamoDAOTestCase
    {
        private ISessionFactory SessionFactory;

        public IPrestamoDAO PrestamoDAO { get; set; }

        [SetUp]
        public void SetUp()
        {
            SessionFactory = (new Configuration()).Configure().BuildSessionFactory();
            ThreadStaticSessionContext.Bind(SessionFactory.OpenSession());
            PrestamoDAO = new PrestamoDAO(SessionFactory);
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
        public void TestBusquedaPrestamosByFechaInicio_GetPrestamosByFechaInicio_OK()
        {
            Prestamo prestamoBase = this.GetSession().Load<Prestamo>(46);

            IList<Prestamo> prestamos = PrestamoDAO.GetPrestamosByFechaInicio(new DateTime(2017, 07, 26));

            Assert.IsNotNull(prestamos);
            Assert.AreEqual(prestamos.First().FechaInicio, prestamoBase.FechaInicio);

        }

        [Test]
        public void TestBusquedaPrestamosByFechaFinalizacion_GetPrestamosByFechaFinalizacion_OK()
        {
            Prestamo prestamoBase = this.GetSession().Load<Prestamo>(48);

            IList<Prestamo> prestamos = PrestamoDAO.GetPrestamosByFechaFinalizacion(new DateTime(2017, 07, 28));

            Assert.IsNotNull(prestamos);
            Assert.AreEqual(prestamos.First().FechaVencimiento, prestamoBase.FechaVencimiento);

        }

        [Test]
        public void TestBusquedaPrestamosByFechaDevolucion_GetPrestamosByFechaDevolucion_OK()
        {
            Prestamo prestamoBase = this.GetSession().Load<Prestamo>(52);

            IList<Prestamo> prestamos = PrestamoDAO.GetPrestamosByFechaDevolucion(new DateTime(2017, 07, 28));

            Assert.IsNotNull(prestamos);
            Assert.AreEqual(prestamos.First().FechaDevolucion, prestamoBase.FechaDevolucion);

        }

        [Test]
        public void TestGetPrestamosByIdSocio_GetPrestamosByIdSocio_OK()
        {
            Socio socio = GetSession().Load<Socio>(56);

            IList<Prestamo> prestamos = PrestamoDAO.GetPrestamosByIdSocio(socio.Id);

            Assert.IsNotNull(prestamos);
            Assert.AreEqual(prestamos.First().Socio.Id, 56);
            Assert.IsTrue(prestamos.Count > 0);
        }

        [Test]
        public void TestGetPrestamoByIdLibro_GetPrestamoByIdLibro_OK()
        {
            Libro libro = GetSession().Load<Libro>(66);

            Prestamo prestamo = PrestamoDAO.GetPrestamoByIdLibro(libro.Id);

            Assert.IsNotNull(prestamo);
            Assert.AreEqual(prestamo.Libro.Id, 66);
        }

        [Test]
        public void TestGetAllPrestamos_GetAllPrestamos_OK()
        {
            IList<Prestamo> prestamos = PrestamoDAO.GetAllPrestamos();

            Assert.IsNotNull(prestamos);
            Assert.IsTrue(prestamos.Count > 0);
        }
    }
}