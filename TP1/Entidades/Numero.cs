using System;

namespace Entidades
{
	public class Numero
	{
		double numero;

		string SetNumero
		{
			set
			{
				numero = ValidarNumero(value);
			}
		}

		public Numero()
		{
			numero = 0;
		}

		public Numero(double numero)
		{
			SetNumero = numero.ToString();
		}

		public Numero(string strNumero)
		{
			SetNumero = strNumero;
		}

		private static double ValidarNumero(string strNumero)
		{
			double.TryParse(strNumero, out double number);

			return number;
		}


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

		public static string DecimalBinario(string numero)
		{
			if (double.TryParse(numero, out double num))
				return DecimalBinario(num);

			return "Valor inválido";
		}

		public static double operator -(Numero n1, Numero n2)
		{
			return n1.numero - n2.numero;
		}

		public static double operator *(Numero n1, Numero n2)
		{
			return n1.numero * n2.numero;
		}

		public static double operator /(Numero n1, Numero n2)
		{
			if (n2.numero == 0)
				return double.MinValue;

			return n1.numero / n2.numero;
		}

		public static double operator +(Numero n1, Numero n2)
		{
			return n1.numero + n2.numero;
		}
	}
}
