using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        static string basicMsg;


        static DniInvalidoException()
        {
            DniInvalidoException.basicMsg = "El DNI es inválido.";
        }


        public DniInvalidoException()
            : base(DniInvalidoException.basicMsg)
        {

        }

        public DniInvalidoException(Exception e)
            : base(DniInvalidoException.basicMsg, e)
        {

        }

        public DniInvalidoException(string message)
            : base(message)
        {

        }

        public DniInvalidoException(string message, Exception e)
            : base(message, e)
        {

        }

    }
}
