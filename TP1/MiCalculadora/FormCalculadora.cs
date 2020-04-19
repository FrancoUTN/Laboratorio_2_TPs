using System;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
	public partial class FormCalculadora : Form
	{
		public FormCalculadora()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Vacía todos los cuadros de texto variables
		/// </summary>
		void Limpiar()
		{
			txtNumero1.Text = "";
			txtNumero2.Text = "";
			cmbOperador.Text = "";
			lblResultado.Text = "";
		}

		/// <summary>
		/// Ejecuta una limpieza
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnLimpiar_Click(object sender, EventArgs e)
		{
			Limpiar();
		}

		/// <summary>
		/// Crea dos números con los valores recibidos y ejecuta una operación entre ellos
		/// </summary>
		/// <param name="numero1"> El primer número </param>
		/// <param name="numero2"> El segundo número </param>
		/// <param name="operador"> La operación a realizar entre el primero y el segundo </param>
		/// <returns> El resultado del cálculo </returns>
		static double Operar(string numero1, string numero2, string operador)
		{
			Numero n1 = new Numero(numero1);
			Numero n2 = new Numero(numero2);

			return Calculadora.Operar(n1, n2, operador);
		}

		/// <summary>
		/// Ejecuta una operación en base a los valores actuales del formulario y muestra el resultado
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOperar_Click(object sender, EventArgs e)
		{
			double resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);

			lblResultado.Text = resultado.ToString();
		}

		/// <summary>
		/// Cierra el formulario
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCerrar_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		/// <summary>
		/// Ejecuta una conversión del resultado expuesto en el formulario de decimal a binario
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnConvertirABinario_Click(object sender, EventArgs e)
		{
			lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
		}

		/// <summary>
		/// Ejecuta una conversión del resultado expuesto en el formulario de binario a decimal
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnConvertirADecimal_Click(object sender, EventArgs e)
		{
			lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
		}
	}
}
