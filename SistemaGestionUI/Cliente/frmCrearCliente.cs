using SistemaGestionBusiness;
using System;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace SistemaGestionUI.Cliente
{
    public partial class frmCrearCliente : Form
    {
        public frmCrearCliente()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                var cliente = new SistemaGestionEntities.Cliente
                {
                    NombreApellido = txtNombreApellido.Text.Trim(),
                    Domicilio = txtDomicilio.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim()
                };

                try
                {
                    await Task.Run(() => ClienteBusiness.CrearClienteAsync(cliente));
                    MessageBox.Show("El cliente se Guardó Correctamente");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool Validar()
        {
            bool resultado = true;
            string mensaje = string.Empty;

            if (string.IsNullOrEmpty(txtNombreApellido.Text))
            {
                resultado = false;
                mensaje = "- El Nombre y Apellido no pueden estar vacíos" + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(txtDomicilio.Text))
            {
                resultado = false;
                mensaje = "- El Domicilio no puede estar vacío" + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                resultado = false;
                mensaje = "- El Teléfono no puede estar vacío" + Environment.NewLine;
            }
            if (!string.IsNullOrEmpty(mensaje))
                MessageBox.Show("Error: " + Environment.NewLine + mensaje);
            return resultado;
        }
    }
}
