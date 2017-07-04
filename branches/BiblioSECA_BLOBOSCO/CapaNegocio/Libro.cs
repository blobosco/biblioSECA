using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio.Exceptions;

namespace CapaNegocio
{
    public class Libro
    {
        public virtual int Id { get; set; }

        public virtual string ISBN { get; set; }

        public Libro() { }

        public Libro(string ISBN)
        {
            ValidateISBN(ISBN);

            this.ISBN = ISBN;
        }

        private void ValidateISBN(string ISBN)
        {
            foreach (char c in ISBN)
            {
                if (c < '0' || c > '9')
                    throw new InvalidISBNException();
            }
        }

    }
}
