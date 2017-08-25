using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;

namespace CapaDatos.DAO
{
    public interface IPrestamoDAO
    {
        Prestamo GetById(long id);

        void Save(Prestamo prestamo);

        IList<Prestamo> GetPrestamosByFechaInicio(DateTime fechaInicio);

        IList<Prestamo> GetPrestamosByFechaFinalizacion(DateTime fechaFinalizacion);

        IList<Prestamo> GetPrestamosByFechaDevolucion(DateTime fechaDevolucion);

        IList<Prestamo> GetPrestamosByIdSocio(long idSocio);

        Prestamo GetPrestamoByIdLibro(long idLibro);

        IList<Prestamo> GetAllPrestamos();
    }

}
