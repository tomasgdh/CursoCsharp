using System;
using System.Net.Http;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Configuration;

namespace SistemaGestionUI.Cliente
{
    public partial class frmCliente : Form
    {
        private readonly string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];

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
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl+"/Cliente");

                    if (response.IsSuccessStatusCode)
                    {
                        var clientes = await response.Content.ReadFromJsonAsync<List<SistemaGestionEntities.Cliente>>(); // Ajusta el tipo según tu modelo.

                        dgClientes.AutoGenerateColumns = true;
                        dgClientes.DataSource = clientes;
                        dgClientes.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Error al listar clientes: " + response.ReasonPhrase, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
