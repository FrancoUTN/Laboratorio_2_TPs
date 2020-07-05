using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        string direccionEntrega;
        EEstado estado;
        string trackingID;

        public delegate void DelegadoEstado(object obj, EventArgs eventArgs);

        public event DelegadoEstado InformaEstado;
        
        /// <summary>
        /// Obtiene o establece la dirección de entrega.
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }

            set
            {
                this.direccionEntrega = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el estado del envío.
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }

            set
            {
                this.estado = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el ID de seguimiento.
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }

            set
            {
                this.trackingID = value;
            }
        }


        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }


        public delegate void DelegadoErrorDAO(string mensajeError);

        public event DelegadoErrorDAO EventoErrorDAO;

        /// <summary>
        /// Cambia progresivamente el estado del paquete cada 4 segundos, informándolo,
        /// hasta ser entregado. Entonces lo inserta en una base de datos. Si esto falla,
        /// lo avisa mediante el evento local EventoErrorDAO conteniendo el mensaje de
        /// la excepción.
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);

                this.estado++;

                this.InformaEstado(this.Estado, new EventArgs());
            }

            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception e)
            {
                this.EventoErrorDAO(e.Message);
            }
        }

        /// <summary>
        /// Devuelve un texto con el id de seguimiento
        /// y la dirección de entrega del paquete recibido.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns> El texto. </returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete)elemento;

            return String.Format("{0} para {1}", p.trackingID, p.direccionEntrega);
        }

        /// <summary>
        /// Chequea la desigualdad entre dos paquetes.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>
        /// true si son distintos.
        /// false si no.
        /// </returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        /// <summary>
        /// Comprueba la igualdad entre dos paquetes.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>
        /// true si comparten el ID de seguimiento.
        /// false si no.
        /// </returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.trackingID == p2.trackingID;
        }

        /// <summary>
        /// Constructor que inicializa la dirección de entrega
        /// y el ID de seguimiento del paquete.
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }

        /// <summary>
        /// Devuelve un texto con el id de seguimiento
        /// y la dirección de entrega del paquete recibido.
        /// </summary>
        /// <returns> El texto. </returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

    }
}
