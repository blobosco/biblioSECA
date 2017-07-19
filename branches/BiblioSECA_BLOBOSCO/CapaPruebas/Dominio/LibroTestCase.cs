using CapaNegocio;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CapaPruebas.Dominio
{
    [TestFixture]
    public class LibroTestCase
    {
        public Libro Libro { get; set; }

        [SetUp]
        public void SetUp ()
        {
            this.Libro = new Libro();
        }

        [Test]
        public void IsbnValidoPrimero_ValidarIsbn_True()
        {
            string ISBNValido = "08-1931-468-8";
            Assert.IsTrue(this.Libro.ValidarISBN(ISBNValido));
        }

        [Test]
        public void IsbnInvalido_ValidarIsbn_False()
        {
            string ISBNValido = "08-1931-468-A";
            Assert.IsFalse(this.Libro.ValidarISBN(ISBNValido));
        }

        [Test]
        public void IsbnSinGuiones_ValidarIsbn_False()
        {
            string ISBNValido = "080193104680A";
            Assert.IsFalse(this.Libro.ValidarISBN(ISBNValido));
        }

        [Test]
        public void IsbnDeMasDe13Caracteres_ValidarIsbn_False()
        {
            string ISBNValido = "08-1931-468-1-345";
            Assert.IsFalse(this.Libro.ValidarISBN(ISBNValido));
        }

        [Test]
        public void IsbnDeMenosDe13Caracteres_ValidarIsbn_False()
        {
            string ISBNValido = "08-1931-468";
            Assert.IsFalse(this.Libro.ValidarISBN(ISBNValido));
        }

        [Test]
        public void IsbnSoloDeGuiones_ValidarIsbn_False()
        {
            string ISBNValido = "-------------";
            Assert.IsFalse(this.Libro.ValidarISBN(ISBNValido));
        }

        [Test]
        public void IsbnValidoSoloDeCeros_ValidarIsbn_True()
        {
            string ISBNValido = "00-0000-000-0";
            Assert.IsTrue(this.Libro.ValidarISBN(ISBNValido));
        }

        [Test]
        public void IsbnConLetrasYGuiones_ValidarIsbn_False()
        {
            string ISBNValido = "AZ-QWER-TYU-N";
            Assert.IsFalse(this.Libro.ValidarISBN(ISBNValido));
        }

        [Test]
        public void IsbnConPuntosEnLugarDeGuiones_ValidarIsbn_False()
        {
            string ISBNValido = "84.4896.089.2";
            Assert.IsFalse(this.Libro.ValidarISBN(ISBNValido));
        }

        [Test]
        public void IsbnVacio_ValidarIsbn_False()
        {
            string ISBNValido = "";
            Assert.IsFalse(this.Libro.ValidarISBN(ISBNValido));
        }

        [Test]
        public void IsbnNull_ValidarIsbn_False()
        {
            string ISBNValido = null;
            Assert.IsFalse(this.Libro.ValidarISBN(ISBNValido));
        }
    }
}
