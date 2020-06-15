using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        List<Alumno> alumnos;
        Universidad.EClases clase;
        Profesor instructor;

        /// <summary>
        /// Devuelve o establece la lista de alumnos de la Jornada.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }

            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Devuelve o establece la clase de la Jornada.
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }

            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Devuelve o establece el Profesor de la Jornada.
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }

            set
            {
                this.instructor = value;
            }
        }

        /// <summary>
        /// Guarda la información de la Jornada en un archivo de texto "jornada.txt"
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>
        /// true si funcionó correctamente.
        /// Si no: lanza una excepción
        /// </returns>
        public static bool Guardar(Jornada jornada)
        {
            try
            {
                new Texto().Guardar("jornada.txt", jornada.ToString());
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        /// <summary>
        /// Construye una Jornada e inicializa su lista de alumnos.
        /// </summary>
        Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }


        /// <summary>
        /// Construye una Jornada e inicializa todos su atributos.
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        /// <summary>
        /// Devuelve una cadena de caracteres con los datos de un documneto de texto
        /// "jornada.txt"
        /// </summary>
        /// <returns>
        /// Retorna la cadena si no ha habido problemas.
        /// Lanza una excepción si ha habido errores.
        /// </returns>
        public static string Leer()
        {
            string lectura;

            try
            {
                new Texto().Leer("jornada.txt", out lectura);
            }
            catch (Exception)
            {
                throw;
            }

            return lectura;
        }

        /// <summary>
        /// Comprueba que un alumno NO forme parte de la Jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>
        /// false si está
        /// true si no está
        /// </returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un Alumno a la jornada si aún no forma parte de ella.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>
        /// Devuelve la misma Jornada con el Alumno
        /// ó
        /// Lanza una excepción si el Alumno ya existe.
        /// </returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j == a)
                throw new AlumnoRepetidoException();

            j.Alumnos.Add(a);

            return j;
        }

        /// <summary>
        /// Comprueba que un alumno forme parte de la Jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>
        /// true si está
        /// false si no está
        /// </returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno al in j.Alumnos)
                if (a == al)
                    return true;

            return false;
        }

        /// <summary>
        /// Publica la información de una Jornada.
        /// </summary>
        /// <returns>
        /// Una cadena de caracteres con todos los datos.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CLASE DE {0} POR {1}", this.Clase, this.Instructor);
            sb.AppendLine("ALUMNOS:");

            foreach (Alumno alumno in this.Alumnos)
                sb.AppendLine(alumno.ToString());

            sb.AppendLine("<-------------------------------------->");

            return sb.ToString();
        }

    }
}
