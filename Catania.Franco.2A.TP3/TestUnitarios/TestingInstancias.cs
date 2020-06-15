using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using EntidadesAbstractas;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class TestingInstancias
    {
        /// <summary>
        /// Chequea que la lista de Alumnos se inicialice al crear una nueva Jornada
        /// </summary>
        [TestMethod]
        public void AlumnosDeJornada()
        {
            Jornada jornada = new Jornada(Universidad.EClases.Laboratorio, new Profesor());

            Assert.IsNotNull(jornada.Alumnos);
        }

        /// <summary>
        /// Verifica que la lista de Jornadas se inicialice al crear una Universidad por defecto
        /// </summary>
        [TestMethod]
        public void JornadasDeUniversidad()
        {
            Universidad universidad = new Universidad();

            Assert.IsNotNull(universidad.Jornadas);
        }
    }
}
