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
            libro.ISBN = "111";

            this.Session.SaveOrUpdate(libro);
            this.Session.Flush();
            this.Session.Clear();

            Libro libro2 = this.Session.Load<Libro>(libro.Id);

            Assert.IsTrue(libro.Id > 0);
            Assert.AreEqual(libro.ISBN, libro2.ISBN);
        }

    }
}
