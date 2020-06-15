using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Graba los datos recibidos como parámetro en la dirección del archivo en formato XML
        /// </summary>
        /// <param name="archivo"> La ruta de acceso al archivo </param>
        /// <param name="datos"></param>
        /// <returns>
        /// true si salió bien.
        /// Si no, lanza una excepción
        /// </returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer((typeof(T)));
                    ser.Serialize(writer, datos);
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return true;
        }

        /// <summary>
        /// Carga el parámetro out con la información contenida en un archivo XML
        /// </summary>
        /// <param name="archivo"> La ruta de acceso al archivo </param>
        /// <param name="datos"> La variable a ser rellenada </param>
        /// <returns>
        /// true si salió bien.
        /// Si no, lanza una excepción
        /// </returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));

                    datos = (T)ser.Deserialize(reader);
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
