using SistemaGestionBusiness;
using System;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace SistemaGestionUI.Cliente
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private async void frmClientes_Load(object sender, EventArgs e)
        {
            await ListarClientesAsync();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            frmCrearCliente cliente = new frmCrearCliente();
            cliente.FormClosed += Cliente_FormClosed;
            cliente.ShowDialog();
        }

        private async void Cliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            await ListarClientesAsync();
        }

        private async void dgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;

            if (this.dgClientes.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                int codigo = Convert.ToInt32(this.dgClientes.Rows[e.RowIndex].Cells["Id"].Value);
                frmModificarCliente frmModificarCliente = new frmModificarCliente(codigo);
                frmModificarCliente.FormClosed += Cliente_FormClosed;
                frmModificarCliente.ShowDialog();
            }

            if (this.dgClientes.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int codigo = Convert.ToInt32(this.dgClientes.Rows[e.RowIndex].Cells["Id"].Value);
                frmEliminarCliente frmEliminarCliente = new frmEliminarCliente(codigo);
                frmEliminarCliente.FormClosed += Cliente_FormClosed;
                frmEliminarCliente.ShowDialog();
            }
        }

        private async Task ListarClientesAsync()
        {
            try
            {
                var clientes = await Task.Run(() => ClienteBusiness.ListarClientesAsync());

                dgClientes.AutoGenerateColumns = true;
                dgClientes.DataSource = clientes;
                dgClientes.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
