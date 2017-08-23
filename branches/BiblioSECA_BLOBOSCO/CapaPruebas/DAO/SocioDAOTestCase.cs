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
    public class SocioDAOTestCase
    {
        private ISessionFactory SessionFactory;

        public ISocioDAO SocioDAO { get; set; }

        [SetUp]
        public void SetUp()
        {
            SessionFactory = (new Configuration()).Configure().BuildSessionFactory();
            ThreadStaticSessionContext.Bind(SessionFactory.OpenSession());
            SocioDAO = new SocioDAO(SessionFactory);
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
        public void TestBusquedaSociosByNombre_GetSociosByNombre_OK()
        {
            Socio socioBase = this.GetSession().Load<Socio>(50);

            IList<Socio> socios = SocioDAO.GetSociosByNombre("Jonathan");

            Assert.IsNotNull(socios);
            Assert.AreEqual(socios.First().Nombre, socioBase.Nombre);

        }

        [Test]
        public void TestBusquedaSociosByApellido_GetSociosByApellido_OK()
        {
            Socio socioBase = this.GetSession().Load<Socio>(52);

            IList<Socio> socios = SocioDAO.GetSociosByApellido("Lopez");

            Assert.IsNotNull(socios);
            Assert.AreEqual(socios.First().Apellido, socioBase.Apellido);

        }

        [Test]
        public void TestBusquedaSociosByNombreUsuario_GetSociosByNombreUsuario_OK()
        {
            Socio socioBase = this.GetSession().Load<Socio>(49);

            Socio socio = SocioDAO.GetSocioByNombreUsuario("rdiaz");

            Assert.IsNotNull(socio);
            Assert.AreEqual(socio.NombreUsuario, socioBase.NombreUsuario);

        }

        [Test]
        public void TestGetAllSocios_GetAllSocios_OK()
        {
            IList<Socio> socios = SocioDAO.GetAllSocios();

            Assert.IsNotNull(socios);
            Assert.IsTrue(socios.Count > 0);
        }

        [Test]
        public void TestGetLos5SociosMasPenalizados_GetLos5SociosMasPenalizados_OK()
        {
            Socio socio = GetSession().Load<Socio>(54);

            IList<Socio> socios = SocioDAO.GetLos5SociosMasPenalizados();

            Assert.IsNotNull(socios);
            Assert.IsTrue(socios.Count > 0);
            Assert.AreEqual(socios.First().Id, socio.Id);
        }

    }
}
