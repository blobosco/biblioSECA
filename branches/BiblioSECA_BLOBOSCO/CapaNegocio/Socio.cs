using CapaNegocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class Socio
    {
        private const int MAXIMO_PRESTAMOS = 2;

        public virtual long Id { get; set; }

        public virtual String Nombre { get; set; }

        public virtual String Apellido { get; set; }

        public virtual String NombreUsuario { get; set; }

        public virtual EstadoSocio Estado { get; set; }

        public virtual IList<Prestamo> Prestamos { get; set; }

        public Socio() { }

        public Socio(string nombre, string apellido, string usuario)
        {
            this.Prestamos = new List<Prestamo>();
            this.Estado = EstadoSocio.Activo;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.NombreUsuario = usuario;
        }

        public virtual void AddPrestamo(Prestamo prestamo)
        {
            ValidarHabilitado();
            this.Prestamos.Add(prestamo);
        }

        private void ValidarHabilitado()
        {
            if (this.Prestamos.Where(x => x.Estado == EstadoPrestamo.Activo).Count() >= MAXIMO_PRESTAMOS)
            {
                throw new SocioNoHabilitadoException();
            }
        }

        public virtual void AgregarPrestamo(Prestamo prestamo)
        {
            prestamo.Socio = this;
            this.Prestamos.Add(prestamo);
        }

    }
}
