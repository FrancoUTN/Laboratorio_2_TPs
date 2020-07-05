using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        Correo correo;

        /// <summary>
        /// Inicializa el formulario y el atributo correo.
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();

            this.correo = new Correo();
        }

        /// <summary>
        /// Actualiza las 3 listas de acuerdo con el estado actual de cada paquete.
        /// </summary>
        void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();

            foreach (Paquete paquete in this.correo.Paquetes)
                switch(paquete.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(paquete);
                        break;

                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(paquete);
                        break;

                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(paquete);
                        break;
                }
        }

        /// <summary>
        /// Añade un paquete al correo con los datos ingresados.
        /// Si algo falla, lo muestra en un MessageBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);

            paquete.InformaEstado += paq_InformaEstado;

            paquete.EventoErrorDAO += ManejarErrorDAO;

            try
            {
                correo += paquete;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Paquete repetido", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }


            this.ActualizarEstados();
        }

        /// <summary>
        /// Muestra un error con la cadena recibida como parámetro.
        /// </summary>
        /// <param name="cadena"></param>
        void ManejarErrorDAO(string cadena)
        {
            MessageBox.Show(cadena, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Muestra la información de todos los paquetes de todas las listas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Muestra los datos del elemento recibido en el richTextBox del formulario
        /// y además los guarda en un archivo llamado "salida.txt".
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento == null)
                return;
            
            string datos = elemento.MostrarDatos(elemento);

            this.rtbMostrar.Text = datos;

            if (!datos.Guardar("salida.txt"))
                MessageBox.Show("Error al guardar los datos.");
        }

        /// <summary>
        /// Muestra la información del paquete seleccionado en la lista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        /// <summary>
        /// Actualiza el formulario de acuerdo al estado actual de los paquetes.
        /// Si no tiene acceso, invoca al hilo correspondiente para que lo haga.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        /// <summary>
        /// Llama al método del correo que se ocupa de cerrar todos los hilos
        /// que sigan activos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        /// <summary>
        /// Al hacer clic derecho sobre la lista de paquetes Entregados, despliega
        /// la opción de mostrar los datos del paquete seleccionado, si es que lo hay.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstEstadoEntregado_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.cmsListas.Show(Cursor.Position);
        }
    }
}
