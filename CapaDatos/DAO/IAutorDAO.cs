using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;

namespace CapaDatos.DAO
{
    public interface IAutorDAO
    {
        Autor GetById(long id);

        void Save(Autor autor);

        IList<Autor> GetAutoresByNombre(string nombreAutor);

        IList<Autor> GetAllAutores();
    }

}

