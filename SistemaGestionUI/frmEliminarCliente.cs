using SistemaGestionBusiness;
using SistemaGestionEntities;

namespace SistemaGestionUI
{
    public partial class frmEliminarCliente : Form
    {
        private Cliente cliente;
       
        public frmEliminarCliente(int IDCliente)
        {
            InitializeComponent();

            this.cliente = ClienteBusiness.ObtenerCliente(IDCliente);

            txtDomicilio.Text = cliente.Domicilio;
            txtNombreApellido.Text = cliente.NombreApellido;
            txtTelefono.Text = cliente.Telefono;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ClienteBusiness.EliminarCliente(this.cliente);
            MessageBox.Show("El cliente se Elimino Correctamente");
            this.Close();
        }
    }
}
