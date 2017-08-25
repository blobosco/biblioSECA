using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;

namespace CapaDatos.DAO
{
    public interface IPenalizacionDAO
    {
        Penalizacion GetById(long id);

        void Save(Penalizacion penalizacion);

        IList<Penalizacion> GetPenalizacionesByFechaInicio(DateTime fechaInicio);

        IList<Penalizacion> GetPenalizacionesByFechaCumplimiento(DateTime fechaCumplimiento);

        IList<Penalizacion> GetPenalizacionesByIdPrestamo(int idPrestamo);

        IList<Penalizacion> GetAllPenalizaciones();

        IList<Penalizacion> GetAllPenalizacionesCuarentena();

        IList<Penalizacion> GetAllPenalizacionesFactura();

    }
}