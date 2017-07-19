using CapaNegocio;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaPruebas.Dominio
{
    [TestFixture]
    public class CuarentenaTestCase
    {
        public Cuarentena Cuarentena;
        public DateTime fechaDeHoy;

        [SetUp]
        public void SetUp ()
        {
            this.Cuarentena = new Cuarentena ();
            this.fechaDeHoy = DateTime.Now;
        }

        [Test]
        public void FechaFinalizacionFueAyer_CuarentenaCumplida_True ()
        {
            DateTime fechaFinalizacion = new DateTime(2017, 07, 05);
            Cuarentena.AsignarFechaFinalizacion(fechaFinalizacion); 
            Assert.IsTrue(Cuarentena.CuarentenaCumplida(fechaDeHoy));
        }

        [Test]
        public void FechaFinalizacionEsHoy_CuarentenaCumplida_False()
        {
            DateTime fechaFinalizacion = new DateTime(2017, 07, 06, 18, 00, 00);
            Cuarentena.AsignarFechaFinalizacion(fechaFinalizacion);
            Assert.IsFalse(Cuarentena.CuarentenaCumplida(fechaDeHoy));
        }

        [Test]
        public void FechaFinalizacionEsManiana_CuarentenaCumplida_False()
        {
            DateTime fechaFinalizacion = new DateTime(2017, 07, 07);
            Cuarentena.AsignarFechaFinalizacion(fechaFinalizacion);
            Assert.IsFalse(Cuarentena.CuarentenaCumplida(fechaDeHoy));
        }
    }
}
