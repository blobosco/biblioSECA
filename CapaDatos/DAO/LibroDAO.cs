using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;
using NHibernate;
using NHibernate.Criterion;

namespace CapaDatos.DAO
{
    public class LibroDAO : ILibroDAO
    {
        private ISessionFactory SessionFactory { get; set; }

        public LibroDAO(ISessionFactory sesssionFactory)
        {
            this.SessionFactory = sesssionFactory;
        }

        public Libro GetById(int id)
        {
            ISession session = this.GetSession();
            return session.Load<Libro>(id);
        }

        public void Save(Libro libro)
        {
            this.GetSession().SaveOrUpdate(libro);
        }

        private ISession GetSession()
        {
            return this.SessionFactory.GetCurrentSession();
        }

    }
}
