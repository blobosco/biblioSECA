using CapaNegocio;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.DAO
{
    public class PenalizacionDAO : IPenalizacionDAO
    {
        private ISessionFactory SessionFactory { get; set; }

        public PenalizacionDAO(ISessionFactory sessionFactory)
        {
            this.SessionFactory = sessionFactory;
        }

        private ISession GetSession()
        {
            return this.SessionFactory.GetCurrentSession();
        }

        public Penalizacion GetById(long id)
        {
            ISession session = this.GetSession();
            return session.Load<Penalizacion>(id);
        }

        public void Save(Penalizacion penalizacion)
        {
            this.GetSession().SaveOrUpdate(penalizacion);
        }


        public IList<Penalizacion> GetPenalizacionesByFechaInicio(DateTime fechaInicio)
        {
            ICriteria criteria = this.GetSession().CreateCriteria(typeof(Penalizacion));
            criteria.Add(Restrictions.Eq("FechaInicio", fechaInicio));

            return criteria.List<Penalizacion>();
        }

        public IList<Penalizacion> GetPenalizacionesByFechaCumplimiento(DateTime fechaCumplimiento)
        {
            ICriteria criteria = this.GetSession().CreateCriteria(typeof(Penalizacion));
            criteria.Add(Restrictions.Eq("FechaCumplimiento", fechaCumplimiento));

            return criteria.List<Penalizacion>();
        }

        public IList<Penalizacion> GetPenalizacionesByIdPrestamo(int idPrestamo)
        {
            ICriteria criteria = this.GetSession().CreateCriteria(typeof(Penalizacion));
            criteria.Add(Restrictions.Eq("Prestamo.Id", idPrestamo));

            return criteria.List<Penalizacion>();
        }

        public IList<Penalizacion> GetAllPenalizaciones()
        {
            ICriteria criteria = this.GetSession().CreateCriteria(typeof(Penalizacion));
            return criteria.List<Penalizacion>();
        }

        public IList<Penalizacion> GetAllPenalizacionesCuarentena()
        {
            ICriteria criteria = this.GetSession().CreateCriteria(typeof(Cuarentena));
            return criteria.List<Penalizacion>();
        }

        public IList<Penalizacion> GetAllPenalizacionesFactura()
        {
            ICriteria criteria = this.GetSession().CreateCriteria(typeof(Factura));
            return criteria.List<Penalizacion>();
        }
    }
}
