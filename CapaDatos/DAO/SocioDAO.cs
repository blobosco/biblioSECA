using CapaNegocio;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.DAO
{
    public class SocioDAO : ISocioDAO
    {
        private ISessionFactory SessionFactory { get; set; }

        public SocioDAO(ISessionFactory sessionFactory)
        {
            this.SessionFactory = sessionFactory;
        }

        private ISession GetSession()
        {
            return this.SessionFactory.GetCurrentSession();
        }

        public Socio GetById(int id)
        {
            ISession session = this.GetSession();
            return session.Load<Socio>(id);
        }

        public void Save(Socio socio)
        {
            this.GetSession().SaveOrUpdate(socio);
        }

        public IList<Socio> GetSociosByNombre(string nombreSocio)
        {
            ICriteria criteria = this.GetSession().CreateCriteria(typeof(Socio));
            criteria.Add(Restrictions.Eq("Nombre", nombreSocio));

            return criteria.List<Socio>();
        }

        public IList<Socio> GetSociosByApellido(string apellidoSocio)
        {
            ICriteria criteria = this.GetSession().CreateCriteria(typeof(Socio));
            criteria.Add(Restrictions.Eq("Apellido", apellidoSocio));

            return criteria.List<Socio>();
        }

        public Socio GetSocioByNombreUsuario(string nombreUsuarioSocio)
        {
            ICriteria criteria = this.GetSession().CreateCriteria(typeof(Socio));
            criteria.Add(Restrictions.Eq("NombreUsuario", nombreUsuarioSocio));

            return criteria.UniqueResult<Socio>();
        }

        public IList<Socio> GetAllSocios()
        {
            ICriteria criteria = this.GetSession().CreateCriteria(typeof(Socio));
            return criteria.List<Socio>();
        }
    }
}
