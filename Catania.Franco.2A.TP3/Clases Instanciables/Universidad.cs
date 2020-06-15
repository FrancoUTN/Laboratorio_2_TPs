using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using System.Xml.Serialization;
using System.Xml;

namespace Clases_Instanciables
{
    public class Universidad
    {
        List<Alumno> alumnos;
        List<Jornada> jornadas;
        List<Profesor> profesores;


        /// <summary>
        /// Devuelve o establece la lista de alumnos de la Universidad.
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
        /// Devuelve o establece la lista de profesores de la Universidad.
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }

            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Devuelve o establece la lista de jornadas de la Universidad.
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornadas;
            }

            set
            {
                this.jornadas = value;
            }
        }

        /// <summary>
        /// Devuelve o establece la jornada ubicada en el índice señalado de la lista.
        /// </summary>
        public Jornada this[int i]
        {
            get
            {
                return this.jornadas[i];
            }

            set
            {
                this.jornadas[i] = value;
            }
        }

        /// <summary>
        /// Guarda la información de la Universidad en un documento XML
        /// "universidad.xml"
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>
        /// Retorna true si no ha habido problemas.
        /// Lanza una excepción si ha habido errores.
        /// </returns>
        public static bool Guardar(Universidad uni)
        {
            try
            {
                new Xml<Universidad>().Guardar("universidad.xml", uni);
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        /// <summary>
        /// Devuelve un objeto Universidad cargado con los datos de un documneto XML
        /// "universidad.xml"
        /// </summary>
        /// <returns>
        /// Retorna true si no ha habido problemas.
        /// Lanza una excepción si ha habido errores.
        /// </returns>
        public static Universidad Leer()
        {
            Universidad uni = new Universidad();

            try
            {
                new Xml<Universidad>().Leer("universidad.xml", out uni);
            }
            catch (Exception)
            {
                throw;
            }

            return uni;
        }

        /// <summary>
        /// Otorga la información de la Universidad.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>
        /// Los datos en una cadena de caracteres.
        /// </returns>
        static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");

            foreach (Jornada j in uni.Jornadas)
                sb.AppendLine(j.ToString());

            return sb.ToString();                
        }

        /// <summary>
        /// Verifica si un Alumno NO forma parte de la Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>
        /// true si no está
        /// false si está
        /// </returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Verifica si un Profesor NO forma parte de la Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns>
        /// true si no está
        /// false si está
        /// </returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }


        /// <summary>
        /// Comprueba que haya un Profesor incapaz de dar la clase recibida.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns>
        /// Retorna el primer Profesor incapaz de dar la clase
        /// Si lo hay: Lanza una excepción.
        /// </returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor instructor in u.Instructores)
                if (instructor != clase)
                    return instructor;

            // return null;
            throw new SinProfesorException();
        }

        /// <summary>
        /// Genera y agrega una nueva Jornada indicando la clase,
        /// un Profesor que pueda darla y la lista de alumnos que la toman.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns>
        /// La misma universidad modificada.
        /// </returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor profesor;

            try
            {
                profesor = g == clase;
            }
            catch (Exception)
            {
                throw;
            }

            Jornada jornada = new Jornada(clase, profesor);

            foreach (Alumno alumno in g.Alumnos)
                if (alumno == clase)
                    jornada += alumno;

            g.Jornadas.Add(jornada);

            return g;
        }

        /// <summary>
        /// Agrega un Alumno a la Universidad en caso de no estar repetido.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns>
        /// Devuelve la misma Universidad con el Alumno
        /// ó
        /// Lanza una excepción si el Alumno ya existe.
        /// </returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u == a)
                throw new Excepciones.AlumnoRepetidoException();

            u.Alumnos.Add(a);

            return u;
        }

        /// <summary>
        /// Agrega un Profesor a la Universidad en caso de no estar repetido.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns>
        /// Devuelve la misma Universidad con el Profesor
        /// ó
        /// Lanza una excepción si el Profesor ya existe.
        /// </returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u == i)
            {    
                Console.WriteLine("Profesor repetido.");
                
                return u;
            }

            u.Instructores.Add(i);

            return u;
        }

        /// <summary>
        /// Verifica si un Alumno forma parte de la Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>
        /// true si está
        /// false si no está
        /// </returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno alumno in g.Alumnos)
                if (a == alumno)
                    return true;

            return false;
        }

        /// <summary>
        /// Verifica si un Profesor forma parte de la Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns>
        /// true si está
        /// false si no está
        /// </returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor profesor in g.Instructores)
                if (i == profesor)
                    return true;
                        
            return false;
        }
        
        /// <summary>
        /// Comprueba que haya un Profesor capaz de dar la clase recibida.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns>
        /// Retorna el primer Profesor capaz de dar la clase
        /// Si no lo hay: Lanza una excepción.
        /// </returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor instructor in g.Instructores)
                if (instructor == clase)
                    return instructor;

            throw new SinProfesorException();
        }

        /// <summary>
        /// Publica los datos de la Universidad.
        /// </summary>
        /// <returns>
        /// Una cadena de caracteres con su información.
        /// </returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        /// <summary>
        /// Constructor por defecto.
        /// Inicializa las 3 listas que forman parte de toda Universidad.
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
        }

        /// <summary>
        /// Enumerado que contiene las distintas clases
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

    }
}
