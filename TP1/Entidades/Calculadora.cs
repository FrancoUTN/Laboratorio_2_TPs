namespace Entidades
{
	public class Calculadora
	{
		public static double Operar(Numero num1, Numero num2, string operador)
		{
			operador = ValidarOperador(operador);

			switch (operador)
			{
				case "+":
					return num1 + num2;
				case "-":
					return num1 - num2;
				case "*":
					return num1 * num2;
				case "/":
					return num1 / num2;
				default:
					return 0;
			}
		}

		static string ValidarOperador(string operador)
		{
			if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
				operador = "+";

			return operador;
		}
	}
}
