using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using EntidadesAbstractas;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class TestingExcepciones
    {
        /// <summary>
        /// Comprueba que se lance la excepción correcta al cargar mal el DNI y la Nacionalidad
        /// </summary>
        [TestMethod]
        public void ProbarNacionalidad()
        {
            try
            {
                Alumno alumno = new Alumno(0, "Paul", "Simon", "50.000.000",
                    Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }

        /// <summary>
        /// Comprueba que se lance la excepción correcta al intentar agregar un Alumno ya existente.
        /// </summary>
        [TestMethod]
        public void RepetirAlumno()
        {
            Alumno alumno = new Alumno(0, "Paul", "Simon", "95.000.000",
                Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);

            Alumno repetido = new Alumno(0, "Paul", "Simon", "95.000.000",
                Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);

            Universidad universidad = new Universidad();

            universidad += alumno;

            try
            {
                universidad += repetido;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }

        /// <summary>
        /// Verifica que se lance la excepción acorde a cargar mal un DNI
        /// </summary>
        [TestMethod]
        public void ProbarDni()
        {
            try
            {
                Alumno alumno = new Alumno(0, "Paul", "Simon", "Noventa millones",
                    Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

    }
}
