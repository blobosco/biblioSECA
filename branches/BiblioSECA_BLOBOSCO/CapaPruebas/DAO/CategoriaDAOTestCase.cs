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
    public class CategoriaDAOTestCase
    {
        private ISessionFactory SessionFactory;

        public ICategoriaDAO CategoriaDAO { get; set; }

        [SetUp]
        public void SetUp()
        {
            SessionFactory = (new Configuration()).Configure().BuildSessionFactory();
            ThreadStaticSessionContext.Bind(SessionFactory.OpenSession());
            CategoriaDAO = new CategoriaDAO(SessionFactory);
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
        public void BusquedaCategoriaByNombre_GetCategoriaByNombre_OK()
        {
            Categoria categoriaBase = this.GetSession().Load<Categoria>(50);

            Categoria categoria = CategoriaDAO.GetCategoriaByNombre("Ciencia Ficcion");

            Assert.IsNotNull(categoria);
            Assert.AreEqual(categoriaBase.Nombre, categoria.Nombre);

        }

        [Test]
        public void TestGetAllCategorias_GetAllCategorias_OK()
        {
            IList<Categoria> categorias = CategoriaDAO.GetAllCategorias();

            Assert.IsNotNull(categorias);
            Assert.IsTrue(categorias.Count > 0);
        }

    }
}