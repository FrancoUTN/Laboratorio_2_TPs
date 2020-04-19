﻿using System;
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

		void Limpiar()
		{
			txtNumero1.Text = "";
			txtNumero2.Text = "";
			cmbOperador.Text = "";
			lblResultado.Text = "";
		}

		private void btnLimpiar_Click(object sender, EventArgs e)
		{
			Limpiar();
		}

		double Operar(string numero1, string numero2, string operador)
		{
			Numero n1 = new Numero(numero1);
			Numero n2 = new Numero(numero2);

			return Calculadora.Operar(n1, n2, operador);
		}

		private void btnOperar_Click(object sender, EventArgs e)
		{
			double resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);

			lblResultado.Text = resultado.ToString();
		}

		private void btnCerrar_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		private void btnConvertirABinario_Click(object sender, EventArgs e)
		{
			lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
		}

		private void btnConvertirADecimal_Click(object sender, EventArgs e)
		{
			lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
		}
	}
}
