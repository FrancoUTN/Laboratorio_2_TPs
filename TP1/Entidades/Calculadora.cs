namespace Entidades
{
	public class Calculadora
	{
		/// <summary>
		/// Ejecuta la operación recibida para dos números
		/// </summary>
		/// <param name="num1"> El primer número </param>
		/// <param name="num2"> El segundo número </param>
		/// <param name="operador"> El operador </param>
		/// <returns>
		/// El resultado en caso de ser un operador válido
		/// La suma en caso de ser cualquier otra cosa
		/// </returns>
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

		/// <summary>
		/// Devuelve el operador recibido, o "+" si no es uno de los 4 operadores aritméticos básicos
		/// </summary>
		/// <param name="operador"> El operador en cuestión </param>
		/// <returns>
		/// El operador en caso de ser válido
		/// "+" en caso de no serlo
		/// </returns>
		static string ValidarOperador(string operador)
		{
			if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
				operador = "+";

			return operador;
		}
	}
}
