using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        int legajo;

        /// <summary>
        /// Verifica la igualdad entre un Objeto y un Universitario.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// Si son iguales: true
        /// Si no: false
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Universitario)
                return (Universitario)obj == this;

            return false;
        }

        /// <summary>
        /// Proporciona información acerca del Universitario.
        /// </summary>
        /// <returns>
        /// Una cadena de caracteres con sus datos.
        /// </returns>
        protected virtual string MostrarDatos()
        {
            return String.Format("{0}\nLEGAJO NÚMERO: {1}\n", base.ToString(), this.legajo);
        }

        /// <summary>
        /// Comprueba si dos universitarios son distintos.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>
        /// true: si son distintos.
        /// false: si son iguales.
        /// </returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        /// <summary>
        /// Comprueba si dos universitarios comparten legajo y DNI.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>
        /// true: si son iguales.
        /// false: si son distintos.
        /// </returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI;
        }


        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Universitario()
        {

        }

        /// <summary>
        /// Constructor con parámetros.
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

    }
}
