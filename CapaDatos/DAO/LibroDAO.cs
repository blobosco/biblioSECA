﻿using System;
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

        public Libro GetLibrosByIsbnHQL(string ISBN)
        {
            StringBuilder query = new StringBuilder();

            query.Append("FROM Libro l WHERE l.ISBN =  :ISBN");

            IQuery resultado = this.GetSession().CreateQuery(query.ToString());

            resultado.SetParameter("ISBN", ISBN);

            return resultado.UniqueResult<Libro>();
        }

        public IList<Libro> GetLibrosByIdAutor(int idAutor)
        {
            ICriteria criteria = this.GetSession().CreateCriteria(typeof(Libro));
            criteria.Add(Restrictions.Eq("Autor.Id", idAutor));

            return criteria.List<Libro>();
        }

        public IList<Libro> GetLibrosByIdCategoria(int idCategoria)
        {
            ICriteria criteria = this.GetSession().CreateCriteria(typeof(Libro));
            criteria.Add(Restrictions.Eq("Categoria.Id", idCategoria));

            return criteria.List<Libro>();
        }

        public IList<Libro> GetLibrosByComienzoDelTituloHQL(string tituloLibro)
        {
            StringBuilder query = new StringBuilder();

            query.Append("FROM Libro l WHERE l.Titulo like :tituloLibro");

            IQuery resultado = this.GetSession().CreateQuery(query.ToString());

            resultado.SetParameter("tituloLibro", "Libro%");

            return resultado.List<Libro>();
        }

        public IList<Libro> GetLibrosByTitulo(string tituloLibro)
        {
            ICriteria criteria = this.GetSession().CreateCriteria(typeof(Libro));
            criteria.Add(Restrictions.Eq("Titulo", tituloLibro));

            return criteria.List<Libro>();
        }

        public IList<Libro> GetLibrosByDescripcion(string descripcionLibro)
        {
            ICriteria criteria = this.GetSession().CreateCriteria(typeof(Libro));
            criteria.Add(Restrictions.Eq("Descripcion", descripcionLibro));

            return criteria.List<Libro>();
        }

        public IList<Libro> GetAllLibros()
        {
            ICriteria criteria = this.GetSession().CreateCriteria(typeof(Libro));
            return criteria.List<Libro>();
        }

    }
}
