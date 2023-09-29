using CursoCsharp.Data;
using CursoCsharp.Models;

namespace MayoristaEstrellaUI
{
    public partial class frmEliminarCliente : Form
    {
        private Cliente cliente;
       
        public frmEliminarCliente(int IDCliente)
        {
            InitializeComponent();

            this.cliente = ClienteData.ObtenerCliente(IDCliente);

            txtDomicilio.Text = cliente.Domicilio;
            txtNombreApellido.Text = cliente.NombreApellido;
            txtTelefono.Text = cliente.Telefono;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ClienteData.EliminarCliente(this.cliente);
            MessageBox.Show("El cliente se Elimino Correctamente");
            this.Close();
        }
    }
}
