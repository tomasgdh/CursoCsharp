
using SistemaGestionBusiness;

namespace SistemaGestionUI.Cliente
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            listarClientes();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmCrearCliente cliente = new frmCrearCliente();
            cliente.FormClosed += Cliente_FormClosed;
            cliente.ShowDialog();
        }

        private void Cliente_FormClosed(object? sender, FormClosedEventArgs e)
        {
            listarClientes();
        }

        private void dgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
            if (this.dgClientes.Columns[e.ColumnIndex].Name == "btnEditar")
            {
               int codigo = (int)this.dgClientes.Rows[e.RowIndex].Cells["Id"].Value;

                frmModificarCliente  frmModificarCliente = new frmModificarCliente(codigo);
                frmModificarCliente.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Cliente_FormClosed);

                frmModificarCliente.ShowDialog();
            }
            
            if (this.dgClientes.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int codigo = (int)this.dgClientes.Rows[e.RowIndex].Cells["Id"].Value;

                frmEliminarCliente frmEliminarCliente = new frmEliminarCliente(codigo);
                frmEliminarCliente.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Cliente_FormClosed);

                frmEliminarCliente.ShowDialog();
            }
        }

        private void listarClientes()
        {
            var clientes = ClienteBusiness.ListarClientes();

            dgClientes.AutoGenerateColumns = true;
            dgClientes.DataSource = clientes;
            dgClientes.Refresh();
        }

      
    }
}
