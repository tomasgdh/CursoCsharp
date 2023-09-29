
using CursoCsharp.Data;
using CursoCsharp.Models;
using System.Windows.Forms;

namespace MayoristaEstrellaUI
{
    public partial class frmCrearCliente : Form
    {
        public frmCrearCliente()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar()) {
                var cliente = new Cliente
                {
                    NombreApellido = txtNombreApellido.Text.Trim(),
                    Domicilio = txtDomicilio.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim()
                };
                ClienteData.CrearCliente(cliente);
                MessageBox.Show("El cliente se Guardo Correctamente");
                this.Close();
            }
        }
        private bool validar() {
            bool resultado = true;
            string mensaje = string.Empty;
            
            if (String.IsNullOrEmpty(txtNombreApellido.Text)) { 
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
            if(!String.IsNullOrEmpty(mensaje))
                MessageBox.Show("Error: " + Environment.NewLine + mensaje);
            return resultado;
        }
    }
}
