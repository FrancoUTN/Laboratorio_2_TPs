using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public class Numero
	{
		double numero;

		string SetNumero
		{
			set
			{
				double num = Numero.ValidarNumero(value);

				if (num != 0) // Querrán que, si no, quede en Null?
					this.numero = num;
			}
		}

		public Numero()
		{
			this.numero = 0;
		}

		public Numero(double numero)
		{
			this.SetNumero = numero.ToString();
		}

		public Numero(string strNumero)
		{
			this.SetNumero = strNumero;
		}

		private static double ValidarNumero(string strNumero)
		{
			double.TryParse(strNumero, out double number);

			return number;
		}


		public static string BinarioDecimal(string binario)
		{
			if (true)
				return "";
			else
				return "Valor inválido";
		}

		public static string DecimalBinario(double numero)
		{
			string bin = "";

			int entero = (int) Math.Abs(numero);

			for (int i = 0; entero >= 2; i++)
			{
				bin = (entero % 2).ToString() + bin;

				entero /= 2;
			}

			bin = entero + bin;

			return bin;
		}

		public static string DecimalBinario(string numero)
		{
			if (double.TryParse(numero, out double num))
				return Numero.DecimalBinario(num);
			else
				return "Valor inválido";
		}
	}
}
