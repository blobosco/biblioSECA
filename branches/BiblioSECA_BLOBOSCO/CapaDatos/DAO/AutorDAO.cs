using CapaNegocio;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.DAO
{
    public class AutorDAO : IAutorDAO
    {
        private ISessionFactory SessionFactory { get; set; }

        public AutorDAO(ISessionFactory sesssionFactory)
        {
            this.SessionFactory = sesssionFactory;
        }

        private ISession GetSession()
        {
            return this.SessionFactory.GetCurrentSession();
        }

        public Autor GetById(long id)
        {
            ISession session = this.GetSession();
            return session.Load<Autor>(id);
        }

        public void Save(Autor autor)
        {
            this.GetSession().SaveOrUpdate(autor);
        }

        public IList<Autor> GetAutoresByNombre(string nombreAutor)
        {
            ICriteria criteria = this.GetSession().CreateCriteria(typeof(Autor));
            criteria.Add(Restrictions.Eq("Nombre", nombreAutor));

            return criteria.List<Autor>();
        }

        public IList<Autor> GetAllAutores()
        {
            ICriteria criteria = this.GetSession().CreateCriteria(typeof(Autor));
            return criteria.List<Autor>();
        }
    }
}
