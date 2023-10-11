using SistemaGestionBusiness;

namespace SistemaGestionUI.Cliente
{
    public partial class frmModificarCliente : Form
    {
        private SistemaGestionEntities.Cliente cliente;

        public frmModificarCliente(int IDCliente)
        {
            InitializeComponent();
            CargarClienteAsync(IDCliente);
        }

        private async void CargarClienteAsync(int IDCliente)
        {
            try
            {
                this.cliente = await ClienteBusiness.ObtenerClienteAsync(IDCliente);
                txtDomicilio.Text = cliente.Domicilio;
                txtNombreApellido.Text = cliente.NombreApellido;
                txtTelefono.Text = cliente.Telefono;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                this.cliente.NombreApellido = txtNombreApellido.Text.Trim();
                this.cliente.Domicilio = txtDomicilio.Text.Trim();
                this.cliente.Telefono = txtTelefono.Text.Trim();

                try
                {
                    await ClienteBusiness.ModificarClienteAsync(this.cliente);
                    MessageBox.Show("El cliente se Modificó Correctamente");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
