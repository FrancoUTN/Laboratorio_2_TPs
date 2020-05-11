using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda
        }
        protected enum ETamanio
        {
            Chico, Mediano, Grande
        }

        EMarca marca;
        string chasis;
        ConsoleColor color;

        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio { get; }

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        public abstract string Mostrar();

        /// <summary>
        /// Obtiene los datos básicos del vehículo
        /// </summary>
        /// <param name="p"> El vehículo </param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CHASIS: {0}\r\n", p.chasis);
            sb.AppendFormat("MARCA : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR : {0}\r\n", p.color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"> El primer vehículo </param>
        /// <param name="v2"> El segundo vehículo </param>
        /// <returns> 'True' si son iguales. 'False' si no lo son </returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }

        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"> El primer vehículo </param>
        /// <param name="v2"> El segundo vehículo </param>
        /// <returns> 'True' si son distintos. 'False' si son iguales </returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return ! (v1 == v2);
        }

        /// <summary>
        /// Inicializa los atributos de un vehículo
        /// </summary>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }

        /// <summary>
        /// Imita la sobrecarga del operador '=='
        /// </summary>
        public override bool Equals(object obj)
        {
            return this == (Vehiculo)obj;
        }

        /// <summary>
        /// Implementa lo mismo que el método GetHashCode de la súper clase Object
        /// </summary>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
