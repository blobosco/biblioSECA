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
    public class AutorPersistenceTestCase
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
        public void CreaAutorNuevo_SaveOrUpdate_GuardaBienDatos()
        {
            Autor autor = new Autor();
            autor.Nombre   = "Juan";

            this.Session.SaveOrUpdate(autor);
            this.Session.Flush();
            this.Session.Clear();

            Autor autor2 = this.Session.Load<Autor>(autor.Id);

            Assert.IsTrue(autor.Id > 0);
            Assert.AreEqual(autor.Nombre, autor2.Nombre);
        }

    }
}
