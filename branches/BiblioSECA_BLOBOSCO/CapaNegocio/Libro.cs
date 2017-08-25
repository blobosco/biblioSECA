using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio.Exceptions;
using System.Text.RegularExpressions;

namespace CapaNegocio
{
    public class Libro
    {
        public virtual long Id { get; set; }

        public virtual string ISBN { get; set; }

        public virtual string Titulo { get; set; }

        public virtual Autor Autor { get; set; }

        public virtual string Descripcion { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual EstadoLibro Estado { get; set; }

        public virtual IList<Prestamo> Prestamos { get; set; }

        public Libro()
        {
            this.Prestamos = new List<Prestamo>();
            this.Estado = EstadoLibro.Disponible;
        }

        public Libro(string isbn)
        {
            ValidarISBN(isbn);
            this.ISBN = isbn;
            this.Prestamos = new List<Prestamo>();
            this.Estado = EstadoLibro.Disponible;
        }

        //XX-XXXX-XXX-X
        public virtual bool ValidarISBN(string isbn)
        {
            if (isbn == null)
                return false;

            Regex rgx = new Regex(@"^\d{2}(-\d{3})\d{1}(-\d{3})(-\d{1})$");
            return rgx.IsMatch(isbn);
        }

        public virtual void AgregarPrestamo(Prestamo prestamo)
        {
            prestamo.Libro = this;
            this.Prestamos.Add(prestamo);
        }
    }
}
