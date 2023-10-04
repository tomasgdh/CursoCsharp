using SistemaGestionBusiness;
using SistemaGestionEntities;

namespace SistemaGestionUI
{
    public partial class frmModificarCliente : Form
    {
        private Cliente cliente;

        public frmModificarCliente(int IDCliente)
        {
            InitializeComponent();

            this.cliente = ClienteBusiness.ObtenerCliente(IDCliente);
            txtDomicilio.Text = cliente.Domicilio;
            txtNombreApellido.Text = cliente.NombreApellido;
            txtTelefono.Text = cliente.Telefono;
        }


        private void frmModificarCliente_Load(object sender, EventArgs e)
        {

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                this.cliente.NombreApellido = txtNombreApellido.Text.Trim();
                this.cliente.Domicilio = txtDomicilio.Text.Trim();
                this.cliente.Telefono = txtTelefono.Text.Trim();
                ClienteBusiness.ModificarCliente(cliente);
                MessageBox.Show("El cliente se Modifico Correctamente");
                this.Close();
            }

        }
        private bool validar()
        {
            bool resultado = true;
            string mensaje = string.Empty;

            if (String.IsNullOrEmpty(txtNombreApellido.Text))
            {
                resultado = false;
                mensaje = "- El Nombre y Apellido no pueden estar vacios" + Environment.NewLine;
            }
            if (String.IsNullOrEmpty(txtDomicilio.Text))
            {
                resultado = false;
                mensaje = "- El Domicilio no pueden estar vacio" + Environment.NewLine;
            }
            if (String.IsNullOrEmpty(txtTelefono.Text))
            {
                resultado = false;
                mensaje = "- El Telefono no pueden estar vacio" + Environment.NewLine;
            }
            if (!String.IsNullOrEmpty(mensaje))
                MessageBox.Show("Error: " + Environment.NewLine + mensaje);
            return resultado;
        }
    }
}
