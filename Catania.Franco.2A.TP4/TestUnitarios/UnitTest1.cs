using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Comprueba que, al crear un nuevo correo, su lista de paquetes
        /// esté instanciada.
        /// </summary>
        [TestMethod]
        public void TestListaInstanciada()
        {
            Correo correo = new Correo();

            Assert.IsNotNull(correo.Paquetes);
        }

        /// <summary>
        /// Valida que se lance la excepción de tipo TrackingIdRepetidoException
        /// cuando se pretende agregar a un mismo correo dos paquetes iguales.
        /// </summary>
        [TestMethod]
        public void TestMismoTrackingID()
        {
            Assert.ThrowsException<TrackingIdRepetidoException>(AccionFallida);
        }

        public void AccionFallida()
        {
            Correo correo = new Correo();

            correo += new Paquete("unaDirección", "1234567890");
            correo += new Paquete("otraDirección", "1234567890");
        }
    }
}
