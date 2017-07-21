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

    }
}
