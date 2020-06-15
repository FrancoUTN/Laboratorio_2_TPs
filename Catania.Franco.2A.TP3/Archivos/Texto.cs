using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Graba los datos recibidos como parámetro en la dirección de archivo de texto
        /// </summary>
        /// <param name="archivo"> La ruta de acceso al archivo </param>
        /// <param name="datos"></param>
        /// <returns>
        /// true si salió bien.
        /// Si no, lanza una excepción
        /// </returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo))
                {
                    sw.Write(datos);
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return true;
        }


        /// <summary>
        /// Carga el parámetro out con la información contenida en un archivo de texto
        /// </summary>
        /// <param name="archivo"> La ruta de acceso al archivo </param>
        /// <param name="datos"> La variable a ser rellenada </param>
        /// <returns>
        /// true si salió bien.
        /// Si no, lanza una excepción
        /// </returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    datos = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return true;
        }

    }
}
