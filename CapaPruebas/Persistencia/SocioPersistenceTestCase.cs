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
    public class SocioPersistenceTestCase
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
        public void CreaSocioNuevo_SaveOrUpdate_GuardaBienDatos()
        {
            Socio socio = new Socio();
            socio.Nombre = "Jose";
            socio.Apellido = "Perez";
            socio.NombreUsuario = "jperez";
            socio.Estado = EstadoSocio.Activo;

            this.Session.SaveOrUpdate(socio);
            this.Session.Flush();
            this.Session.Clear();

            Socio socio2 = this.Session.Load<Socio>(socio.Id);

            Assert.IsTrue(socio.Id > 0);
            Assert.AreEqual(socio.Nombre, socio2.Nombre);
            Assert.AreEqual(socio.Apellido, socio2.Apellido);
            Assert.AreEqual(socio.NombreUsuario, socio2.NombreUsuario);
            Assert.AreEqual(socio.Estado, socio2.Estado);
        }

    }
}
