using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        List<Thread> mockPaquetes;
        List<Paquete> paquetes;

        /// <summary>
        /// Obtiene o establece la lista de paquetes.
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }

            set
            {
                this.paquetes = value;
            }
        }

        /// <summary>
        /// Constructor que inicializa las listas de hilos y de paquetes.
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        /// <summary>
        /// Cierra todos los hilos activos.
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread hilo in this.mockPaquetes)
                if (hilo.IsAlive)
                    hilo.Abort();
        }

        /// <summary>
        /// Devuelve un texto con toda la información de cada paquete
        /// presente en la lista del correo recibido.
        /// </summary>
        /// <param name="elementos"> Un correo. </param>
        /// <returns> El texto. </returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            string datos = "";

            foreach (Paquete p in ((Correo)elementos).Paquetes)
                datos += String.Format("{0} ({1})\n", p.ToString(), p.Estado.ToString());

            return datos;
        }

        /// <summary>
        /// Agrega un nuevo paquete a la lista del correo.
        /// </summary>
        /// <param name="c"> Un correo. </param>
        /// <param name="p"> El paquete a agregar. </param>
        /// <returns>
        /// Si existe en la lista otro paquete con el mismo ID de seguimiento,
        /// lanza la excepción TrackingIdRepetidoException.
        /// Si no, devuelve el correo con el paquete ya añadido a su lista.
        /// </returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete paquete in c.Paquetes)
                if (p == paquete)
                    throw new TrackingIdRepetidoException
                        ("El Tracking ID " + p.TrackingID + " ya figura en la lista de envíos.");

            c.Paquetes.Add(p);

            Thread hilo = new Thread(new ThreadStart(p.MockCicloDeVida));

            c.mockPaquetes.Add(hilo);

            hilo.Start();

            return c;
        }

    }
}
