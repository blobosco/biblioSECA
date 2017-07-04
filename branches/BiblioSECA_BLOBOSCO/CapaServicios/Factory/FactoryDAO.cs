using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using CapaDatos.DAO;

namespace CapaServicios.Factory
{
    public class FactoryDAO
    {
        private static FactoryDAO instance;

        private static ISessionFactory SessionFactory { get; set; }

        private FactoryDAO() { }

        public static FactoryDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    SessionFactory = (new Configuration()).Configure().BuildSessionFactory();

                    instance = new FactoryDAO();
                }

                return instance;
            }
        }

        public ILibroDAO GetLibroDAO()
        {
            return new LibroDAO(SessionFactory);
        }

        public ISessionFactory GetSessionFactory()
        {
            return SessionFactory;
        }

    }
}
