using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;

namespace CapaDatos.DAO
{
    public interface IPrestamoDAO
    {
        Prestamo GetById(int id);

        void Save(Prestamo prestamo);

        IList<Prestamo> GetPrestamosByFechaInicio(DateTime fechaInicio);

        IList<Prestamo> GetPrestamosByFechaFinalizacion(DateTime fechaFinalizacion);

        IList<Prestamo> GetPrestamosByFechaDevolucion(DateTime fechaDevolucion);

        IList<Prestamo> GetPrestamosByIdSocio(int idSocio);

        Prestamo GetPrestamoByIdLibro(int idLibro);

        IList<Prestamo> GetAllPrestamos();
    }

}
