using CapaNegocio;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaPruebas.Dominio
{
    [TestFixture]
    public class PrestamoTestCase
    {
        public Libro libro { get; set; }

        public Socio socio { get; set; }

        [SetUp]
        public void SetUp()
        {
            Socio socio = new Socio("Barbara", "Lobosco", "blobosco");
            Libro libro = new Libro("00-0001-002-3");
        }

        [Test]
        public void FechaVencimientoEsHoy_EstaVencido_True()
        {
            DateTime FechaVencimiento = DateTime.Now;

            Prestamo primerPrestamo = new Prestamo(libro, socio, FechaVencimiento);

            Assert.IsTrue(primerPrestamo.EstaVencido());
        }

        [Test]
        public void FechaVencimientoEsManiana_EstaVencido_False()
        {
            DateTime FechaVencimiento = new DateTime(2017, 7, 21);

            Prestamo primerPrestamo = new Prestamo(libro, socio, FechaVencimiento);

            Assert.IsFalse(primerPrestamo.EstaVencido());
        }

        [Test]
        public void FechaVencimientoFueAyer_EstaVencido_True()
        {
            DateTime FechaVencimiento = new DateTime(2017, 7, 4);

            Prestamo primerPrestamo = new Prestamo(libro, socio, FechaVencimiento);

            Assert.IsTrue(primerPrestamo.EstaVencido());
        }

        [Test]
        public void FechaDeDevolucionEsNull_EstaDevuelto_False()
        {
            DateTime FechaVencimiento = new DateTime(2017, 7, 6);

            Prestamo primerPrestamo = new Prestamo(libro, socio, FechaVencimiento);

            Assert.IsFalse(primerPrestamo.EstaDevuelto());
        }
    }
}
