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
    public class AutorDAOTestCase
    {
        private ISessionFactory SessionFactory;

        public IAutorDAO AutorDAO { get; set; }

        [SetUp]
        public void SetUp()
        {
            SessionFactory = (new Configuration()).Configure().BuildSessionFactory();
            ThreadStaticSessionContext.Bind(SessionFactory.OpenSession());
            AutorDAO = new AutorDAO(SessionFactory);
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
        public void TestBusquedaAutorByNombre_GetAutorByNombre_OK()
        {
            Autor autorBase = this.GetSession().Load<Autor>(50);

            IList<Autor> autores = AutorDAO.GetAutoresByNombre("Juan");

            Assert.IsNotNull(autores);
            Assert.AreEqual(autores.First().Nombre, autorBase.Nombre);

        }

        [Test]
        public void TestGetAllAutores_GetAllautores_OK()
        {
            IList<Autor> autores = AutorDAO.GetAllAutores();

            Assert.IsNotNull(autores);
            Assert.IsTrue(autores.Count > 0);
        }

    }
}
