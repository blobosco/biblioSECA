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
    public class PenalizacionDAOTestCase
    {
        private ISessionFactory SessionFactory;

        public IPenalizacionDAO PenalizacionDAO { get; set; }

        [SetUp]
        public void SetUp()
        {
            SessionFactory = (new Configuration()).Configure().BuildSessionFactory();
            ThreadStaticSessionContext.Bind(SessionFactory.OpenSession());
            PenalizacionDAO = new PenalizacionDAO(SessionFactory);
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
            Penalizacion penalizacionBase = this.GetSession().Load<Penalizacion>(20);

            IList<Penalizacion> penalizaciones = PenalizacionDAO.GetPenalizacionesByFechaInicio(new DateTime(2017, 07, 24));

            Assert.IsNotNull(penalizaciones);
            Assert.AreEqual(penalizaciones.First().FechaInicio, penalizacionBase.FechaInicio);

        }
    }
}
