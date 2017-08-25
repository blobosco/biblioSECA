using CapaNegocio;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.DAO
{
    public class PrestamoDAO : IPrestamoDAO
    {
        private ISessionFactory SessionFactory { get; set; }

        public PrestamoDAO(ISessionFactory sessionFactory)
        {
            this.SessionFactory = sessionFactory;
        }

        private ISession GetSession()
        {
            return this.SessionFactory.GetCurrentSession();
        }

        public Prestamo GetById(long id)
        {
            ISession session = this.GetSession();
            return session.Load<Prestamo>(id);
        }

        public void Save(Prestamo prestamo)
        {
            this.GetSession().SaveOrUpdate(prestamo);
        }

        public IList<Prestamo> GetPrestamosByFechaInicio(DateTime fechaInicio)
        {
            ICriteria criteria = this.GetSession().CreateCriteria(typeof(Prestamo));
            criteria.Add(Restrictions.Eq("FechaInicio", fechaInicio));

            return criteria.List<Prestamo>();
        }

        public IList<Prestamo> GetPrestamosByFechaFinalizacion(DateTime fechaFinalizacion)
        {
            ICriteria criteria = this.GetSession().CreateCriteria(typeof(Prestamo));
            criteria.Add(Restrictions.Eq("FechaVencimiento", fechaFinalizacion));

            return criteria.List<Prestamo>();
        }

        public IList<Prestamo> GetPrestamosByFechaDevolucion(DateTime fechaDevolucion)
        {
            ICriteria criteria = this.GetSession().CreateCriteria(typeof(Prestamo));
            criteria.Add(Restrictions.Eq("FechaDevolucion", fechaDevolucion));

            return criteria.List<Prestamo>();
        }

        public IList<Prestamo> GetPrestamosByIdSocio(long idSocio)
        {
            ICriteria criteria = this.GetSession().CreateCriteria(typeof(Prestamo));
            criteria.Add(Restrictions.Eq("Socio.Id", idSocio));

            return criteria.List<Prestamo>();
        }

        public Prestamo GetPrestamoByIdLibro(long idLibro)
        {
            ICriteria criteria = this.GetSession().CreateCriteria(typeof(Prestamo));
            criteria.Add(Restrictions.Eq("Libro.Id", idLibro));

            return criteria.UniqueResult<Prestamo>();
        }

        public IList<Prestamo> GetAllPrestamos()
        {
            ICriteria criteria = this.GetSession().CreateCriteria(typeof(Prestamo));
            return criteria.List<Prestamo>();
        }
    }
}
