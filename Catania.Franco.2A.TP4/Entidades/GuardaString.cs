using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Guarda el archivo recibido en el escritorio del usuario.
        /// Si existe, le concatena el texto.
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns>
        /// true si lo guardó correctamente.
        /// false si falla.
        /// </returns>
        public static bool Guardar(this string texto, string archivo)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            try
            {
                using(StreamWriter sw = new StreamWriter(desktop + @"\" + archivo, true))
                {
                    sw.WriteLine(texto);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

    }
}
