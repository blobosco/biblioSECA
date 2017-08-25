using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio;

namespace CapaDatos.DAO
{
    public interface ISocioDAO
    {
        Socio GetById(long id);

        void Save(Socio socio);

        IList<Socio> GetSociosByNombre(string nombreSocio);

        IList<Socio> GetSociosByApellido(string apellidoSocio);

        Socio GetSocioByNombreUsuario(string nombreUsuarioSocio);

        IList<Socio> GetAllSocios();

        IList<Socio> GetLos5SociosMasPenalizados();
    }

}
