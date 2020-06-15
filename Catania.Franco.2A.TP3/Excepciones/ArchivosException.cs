using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        static string baseMsg;


        static ArchivosException()            
        {
            ArchivosException.baseMsg = "Problemas con el archivo.";
        }


        public ArchivosException()
            : base(ArchivosException.baseMsg)
        {

        }

        public ArchivosException(Exception innerException)
            : base(ArchivosException.baseMsg, innerException)
        {

        }

        public ArchivosException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
