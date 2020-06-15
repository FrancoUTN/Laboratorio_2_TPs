using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        string apellido;
        int dni;
        ENacionalidad nacionalidad;
        string nombre;

        /// <summary>
        /// Devuelve o establece (previa validación) el apellido de la persona.
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = Persona.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Devuelve o establece (previa validación) el DNI de la persona.
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                try
                {
                    this.dni = ValidarDni(this.nacionalidad, value);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// Devuelve o establece el la nacionalidad de la persona.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Devuelve o establece (previa validación) el nombre de la persona.
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = Persona.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Establece (previa validación) el DNI de la persona, de cadena de caracteres a entero.
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = Persona.ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor que inicializa atributos básicos.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor que incluye DNI como un entero.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor que incluye DNI como una cadena de caracteres.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Brinda la información de la persona (excepto su DNI).
        /// </summary>
        /// <returns>
        /// Una cadena de caracteres con el nombre completo y la nacionalidad.
        /// </returns>
        public override string ToString()
        {
            return String.Format("NOMBRE COMPLETO: {0}, {1}\nNACIONALIDAD: {2}\n",
                this.Apellido, this.Nombre, this.Nacionalidad);
        }

        /// <summary>
        /// Comprueba que el número de DNI recibido sea acorde a la nacionalidad.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"> El DNI </param>
        /// <returns>
        /// Si es válido, el propio DNI.
        /// Si no, lanza una excepción.
        /// </returns>
        static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                        throw new NacionalidadInvalidaException();
                    break;

                case ENacionalidad.Extranjero:
                    if (dato < 89999999 || dato > 99999999)
                        throw new NacionalidadInvalidaException();
                    break;
            }

            return dato;
        }

        /// <summary>
        /// Verifica que la cadena recibida como parámetro cumpla los requisitos de un DNI.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"> El DNI </param>
        /// <returns>
        /// Si es válido, el DNI en formato entero.
        /// Si no: lanza una excepción.
        /// </returns>
        static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            dato = dato.Replace(".", "");

            if (dato.Length < 1 || dato.Length > 8)
                throw new DniInvalidoException();

            int numeroDni;

            if (!Int32.TryParse(dato, out numeroDni))
                throw new DniInvalidoException();

            return Persona.ValidarDni(nacionalidad, numeroDni);
        }

        /// <summary>
        /// Verifica que el nombre o el apellido de la persona sean cadenas
        /// de caracteres válidas para ese fin.
        /// </summary>
        /// <param name="dato"> El nombre o apellido a chequear. </param>
        /// <returns> 
        /// Si es válido: el dato recibido como parametro.
        /// Si no: Una cadena de caracteres vacía.
        /// </returns>
        static string ValidarNombreApellido(string dato)
        {            
            Match match = new Regex(@"[a-zA-Z]*").Match(dato);

            if (match.Success)
                return match.Value;

            else
                return "";
        }

        /// <summary>
        /// Enumerado de nacionalidades.
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

    }
}
