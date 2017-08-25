using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class Prestamo
    {
        public virtual long Id { get; set; }

        public virtual DateTime FechaInicio { get; set; }

        public virtual DateTime FechaVencimiento { get; set; }

        public virtual DateTime? FechaDevolucion { get; set; }

        public virtual Libro Libro { get; set; }

        public virtual Socio Socio { get; set; }

        public virtual EstadoPrestamo Estado { get; set; }

        public virtual IList<Penalizacion> Penalizaciones { get; set; }

        public Prestamo() { }

        public Prestamo(Libro libro, Socio socio, DateTime fechaVencimiento)
        {
           this.Libro = libro;
           this.Socio = socio;
           this.FechaInicio = DateTime.Now;
           this.FechaVencimiento = fechaVencimiento;
           this.FechaDevolucion = null; 
           this.Penalizaciones = new List<Penalizacion>();
           this.Estado = EstadoPrestamo.Activo;
        }

        public virtual int CantidadDeDiasTrascurridos ()
        {
            TimeSpan diferenciaDeDias = FechaVencimiento - FechaInicio;
            return diferenciaDeDias.Days;
        }

        public virtual Boolean EstaVencido()
        {
            if (this.FechaVencimiento > DateTime.Now)
            {
                return false;
            }
            return true;
        }

        public virtual Boolean EstaDevuelto()
        {
            if (this.FechaDevolucion == null)
            {
                return false;
            }
            return true;
        }

        public virtual void AgregarPenalizacion(Penalizacion penalizacion)
        {
            penalizacion.Prestamo = this;
            this.Penalizaciones.Add(penalizacion);
        }

    }
}
