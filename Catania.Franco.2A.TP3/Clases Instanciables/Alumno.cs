using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        Universidad.EClases claseQueToma;
        EEstadoCuenta estadoCuenta;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Construye e inicializa todo un Alumno (excepto el estado de su cuenta)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni,
            ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Construye e inicializa a un Alumno completo.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni,
            ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Otorga la información de un Alumno
        /// </summary>
        /// <returns>
        /// Cadena con sus datos
        /// </returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.Append("ESTADO DE CUENTA: ");

            switch (this.estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    sb.AppendLine("Cuota al día");
                    break;
                case EEstadoCuenta.Becado:
                    sb.AppendLine("Alumno becado");
                    break;
                case EEstadoCuenta.Deudor:
                    sb.AppendLine("Debe cuota(s)");
                    break;
            }

            sb.Append(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Verifica si un alumno NO toma una clase o si debe cuotas.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>
        /// true si no la toma o es deudor.
        /// false si toma la clase y no debe cuotas.
        /// </returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }

        /// <summary>
        /// Verifica si un alumno toma una clase y si no debe cuotas.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>
        /// true si la toma y no es deudor.
        /// false si no la toma o debe cuotas.
        /// </returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor;
        }

        /// <summary>
        /// Indica qué clase toma el Alumno
        /// </summary>
        /// <returns>
        /// Cadena de caracteres con la clase que toma.
        /// </returns>
        protected override string ParticiparEnClase()
        {
            return String.Format("TOMA CLASES DE {0}", this.claseQueToma);
        }

        /// <summary>
        /// Publica los datos de un Alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Enumeración de los posibles estados de la cuenta de un Alumno
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

    }
}
