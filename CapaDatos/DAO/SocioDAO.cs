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

        public Socio GetById(long id)
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


        public IList<Socio> GetLos5SociosMasPenalizados()
        {
            StringBuilder query = new StringBuilder();

            //query.Append("select p.Socio " );
            //query.Append("from Prestamo p, Penalizacion pen ");
            //query.Append("where p.Id = pen.Prestamo.Id ");
            ////query.Append("GROUP BY p.Socio.Id ");
            //query.Append("ORDER BY p.Socio.Id DESC");

            query.Append("select p.Socio, COUNT(*) totalPenalizaciones ");
            query.Append("from Prestamo p, Penalizacion pen ");
            query.Append("where p.Id = pen.Prestamo.Id ");
            //query.Append("GROUP BY p.Socio.Id ");
            query.Append("ORDER BY totalPenalizaciones DESC");

            IQuery resultado = this.GetSession().CreateQuery(query.ToString());

            //resultado.SetParameter("idSocio", idSocio);

            return resultado.List<Socio>().Take(5).ToList();
        }
    }
}
