using System;

namespace Entidades
{
	public class Numero
	{
		double numero;

		/// <summary>
		/// Valida el número antes de asignarlo
		/// </summary>
		string SetNumero
		{
			set
			{
				numero = ValidarNumero(value);
			}
		}

		/// <summary>
		/// Constructor que inicializa el atributo numero en 0.
		/// </summary>
		public Numero()
		{
			numero = 0;
		}

		/// <summary>
		/// Constructor que setea el atributo numero con el valor recibido como parámetro
		/// </summary>
		/// <param name="numero"> Valor </param>
		public Numero(double numero)
		{
			SetNumero = numero.ToString();
		}

		/// <summary>
		/// Constructor que setea el atributo numero con el valor recibido como parámetro
		/// </summary>
		/// <param name="strNumero"> Valor en string </param>
		public Numero(string strNumero)
		{
			SetNumero = strNumero;
		}

		/// <summary>
		/// Chequea que un número en formato string pueda convertirse en double
		/// </summary>
		/// <param name="strNumero"> El valor en formato string </param>
		/// <returns> El valor double, o 0 si no pudo transformarse </returns>
		private static double ValidarNumero(string strNumero)
		{
			double.TryParse(strNumero, out double number);

			return number;
		}

		/// <summary>
		/// En caso de existir y ser binario, convierte un número a decimal
		/// </summary>
		/// <param name="binario"> El número binario </param>
		/// <returns>
		/// "Sin valor" si está vacío 
		/// "Valor inválido" si no es un número binario
		/// Número decimal en formato string
		/// </returns>
		public static string BinarioDecimal(string binario)
		{
			int ent = 0;
			int exp = binario.Length - 1;

			if (exp < 0)
				return "Sin valor";

			for (int i = 0; i < binario.Length; i++, exp--)

				if (binario[i] == '1')
					ent += (int)Math.Pow(2, exp);

				else if (binario[i] != '0')
					return "Valor inválido";

			return ent.ToString();
		}

		/// <summary>
		/// Convierte un número decimal a su correspondiente binario
		/// </summary>
		/// <param name="numero"> El número decimal </param>
		/// <returns> El número binario </returns>
		public static string DecimalBinario(double numero)
		{
			string bin = "";

			int entero = (int)Math.Abs(numero);

			for (int i = 0; entero >= 2; i++)
			{
				bin = (entero % 2).ToString() + bin;

				entero /= 2;
			}

			bin = entero + bin;

			return bin;
		}

		/// <summary>
		/// Recibe un string: en caso de ser un número, lo hace convertir a binario
		/// </summary>
		/// <param name="numero"> El número en formato string </param>
		/// <returns> Si es decimal, el correspondiente binario. Si no: "Valor inválido" </returns>
		public static string DecimalBinario(string numero)
		{
			if (double.TryParse(numero, out double num))
				return DecimalBinario(num);

			return "Valor inválido";
		}


		/// <summary>
		/// Le resta el segundo número al primero
		/// </summary>
		/// <param name="n1"> El primer número </param>
		/// <param name="n2"> El segundo número </param>
		/// <returns> El resultado </returns>
		public static double operator -(Numero n1, Numero n2)
		{
			return n1.numero - n2.numero;
		}

		/// <summary>
		/// Multiplica dos números
		/// </summary>
		/// <param name="n1"> El primer número </param>
		/// <param name="n2"> El segundo número </param>
		/// <returns> El resultado </returns>
		public static double operator *(Numero n1, Numero n2)
		{
			return n1.numero * n2.numero;
		}

		/// <summary>
		/// Divide el primer número por el segundo, en caso de ser este distinto de 0 
		/// </summary>
		/// <param name="n1"> El primer número </param>
		/// <param name="n2"> El segundo número </param>
		/// <returns> El resultado, o el mínimo valor de un double si n2 es igual a 0 </returns>
		public static double operator /(Numero n1, Numero n2)
		{
			if (n2.numero == 0)
				return double.MinValue;

			return n1.numero / n2.numero;
		}

		/// <summary>
		/// Suma dos números
		/// </summary>
		/// <param name="n1"> El primer número </param>
		/// <param name="n2"> El segundo número </param>
		/// <returns> El resultado </returns>
		public static double operator +(Numero n1, Numero n2)
		{
			return n1.numero + n2.numero;
		}
	}
}
