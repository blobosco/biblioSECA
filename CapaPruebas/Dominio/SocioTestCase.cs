using CapaNegocio;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaPruebas.Dominio
{
    [TestFixture]
    public class SocioTestCase
    {
        public Socio Socio { get; set; }

        private Libro libroUno { get; set; }

        private Libro libroDos { get; set; }

        private Libro libroTres { get; set; }

        [SetUp]
        public void SetUp()
        {
            this.Socio = new Socio("Barbara", "Lobosco", "blobosco");
            this.libroUno = new Libro("00-0001-002-3");
            this.libroDos = new Libro("00-0002-003-4");
        }

        [Test]
        public void SocioHabilitado_ValidarHabilitado_AgregaPrestamo()
        {
            DateTime FechaVencimiento = DateTime.Now.AddDays(2);
            Prestamo primerPrestamo = new Prestamo(libroUno, Socio, FechaVencimiento);
            Prestamo segundoPrestamo = new Prestamo(libroDos, Socio, FechaVencimiento);

            this.Socio.AgregarPrestamo(primerPrestamo);
            this.Socio.AgregarPrestamo(segundoPrestamo);

            Assert.AreEqual(primerPrestamo.Socio, Socio);
            Assert.AreEqual(segundoPrestamo.Socio, Socio);
        }
    }
}
