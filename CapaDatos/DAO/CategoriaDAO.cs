using CapaNegocio;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.DAO
{
    public class CategoriaDAO : ICategoriaDAO
    {
        private ISessionFactory SessionFactory { get; set; }

        public CategoriaDAO(ISessionFactory sesssionFactory)
        {
            this.SessionFactory = sesssionFactory;
        }

        private ISession GetSession()
        {
            return this.SessionFactory.GetCurrentSession();
        }

        public Categoria GetById(long id)
        {
            ISession session = this.GetSession();
            return session.Load<Categoria>(id);
        }

        public void Save(Categoria categoria)
        {
            this.GetSession().SaveOrUpdate(categoria);
        }

        public Categoria GetCategoriaByNombre(string nombreCategoria)
        {
            ICriteria criteria = this.GetSession().CreateCriteria(typeof(Categoria));
            criteria.Add(Restrictions.Eq("Nombre", nombreCategoria));

            return criteria.UniqueResult<Categoria>();
        }

        public IList<Categoria> GetAllCategorias()
        {
            ICriteria criteria = this.GetSession().CreateCriteria(typeof(Categoria));
            return criteria.List<Categoria>();
        }
    }
}
