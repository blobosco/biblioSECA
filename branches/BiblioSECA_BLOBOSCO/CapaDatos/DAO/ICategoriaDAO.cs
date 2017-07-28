using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;

namespace CapaDatos.DAO
{
    public interface ICategoriaDAO
    {
        Categoria GetById(int id);

        void Save(Categoria categoria);

        Categoria GetCategoriaByNombre(string nombreCategoria);

        IList<Categoria> GetAllCategorias();

    }

}
