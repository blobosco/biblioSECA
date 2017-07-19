using CapaNegocio;
using NHibernate;
using NHibernate.Cfg;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaPruebas.Persistencia
{
    [TestFixture]
    public class CategoriaPersistenceTestCase
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
        public void CreaCategoriaNueva_SaveOrUpdate_GuardaBienDatos()
        {
            Categoria categoria = new Categoria();
            categoria.Nombre = "Terror";

            this.Session.SaveOrUpdate(categoria);
            this.Session.Flush();
            this.Session.Clear();

            Categoria categoria2 = this.Session.Load<Categoria>(categoria.Id);

            Assert.IsTrue(categoria.Id > 0);
            Assert.AreEqual(categoria.Nombre, categoria2.Nombre);
        }

    }
}
