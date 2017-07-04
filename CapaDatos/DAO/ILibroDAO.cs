using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;

namespace CapaDatos.DAO
{
    public interface ILibroDAO
    {
        Libro GetById(int id);

        void Save(Libro libro);
    }
}
