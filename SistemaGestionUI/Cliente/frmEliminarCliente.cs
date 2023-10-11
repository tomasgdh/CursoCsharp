using SistemaGestionBusiness;
using SistemaGestionEntities;

namespace SistemaGestionUI.Cliente
{
    public partial class frmEliminarCliente : Form
    {
        private SistemaGestionEntities.Cliente cliente;

        public frmEliminarCliente(int IDCliente)
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
            try
            {
                await ClienteBusiness.EliminarClienteAsync(this.cliente.Id);
                MessageBox.Show("El cliente se Eliminó Correctamente");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
