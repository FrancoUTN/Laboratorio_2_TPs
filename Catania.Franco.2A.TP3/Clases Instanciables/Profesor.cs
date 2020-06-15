using EntidadesAbstractas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        Queue<Universidad.EClases> clasesDelDia;
        static Random random;

        /// <summary>
        /// Establece dos clases al azar para un Profesor.
        /// </summary>
        void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(4));
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(4));
        }

        /// <summary>
        /// Muestra la información del profesor.
        /// </summary>
        /// <returns>
        /// Una cadena con sus datos.
        /// </returns>
        protected override string MostrarDatos()
        {
            return String.Format("{0}{1}\n",
                base.MostrarDatos(), this.ParticiparEnClase());
        }

        /// <summary>
        /// Comprueba que el Profesor recibido NO pueda dar la clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>
        /// false si puede darla
        /// true si no
        /// </returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Comprueba que el Profesor recibido pueda dar la clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>
        /// true si puede darla
        /// false si no
        /// </returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases c in i.clasesDelDia)
                if (clase == c)
                    return true;

            return false;
        }

        /// <summary>
        /// Devuelve las clases del Profesor en el día.
        /// </summary>
        /// <returns>
        /// Una cadena con sus clases.
        /// </returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DÍA:");

            foreach (Universidad.EClases clase in clasesDelDia)
                sb.AppendLine(clase.ToString());

            return sb.ToString();
        }

        /// <summary>
        /// Inicializa la cola de clases del Profesor.
        /// </summary>
        public Profesor()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();

            this._randomClases();
        }

        /// <summary>
        /// Inicializa la variable aleatoria estática.
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Construye a un Profesor completo.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Profesor().clasesDelDia;
        }

        /// <summary>
        /// Publica los datos de un Profesor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

    }
}
