using SistemaGestionBusiness;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGestionUI.Producto
{
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await CargarProductosAsync();
        }

        private async Task CargarProductosAsync()
        {
            try
            {
                List<SistemaGestionEntities.Producto> lista = await ProductoBusiness.ListarProductosAsync();

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = lista;
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCrear_Click(object sender, EventArgs e)
        {
            frmAltaProducto frmAltaProducto = new frmAltaProducto();
            frmAltaProducto.FormClosed += frmAltaProducto_FormClosed;
            frmAltaProducto.ShowDialog();
            await CargarProductosAsync();
        }

        private async void frmAltaProducto_FormClosed(object? sender, FormClosedEventArgs e)
        {
            await CargarProductosAsync();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;

            int id = (int)this.dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;

            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                frmModificarProducto modificar = new frmModificarProducto(id);
                modificar.FormClosed += frmAltaProducto_FormClosed;
                modificar.ShowDialog();
            }
            else if (this.dataGridView1.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                frmEliminarProducto eliminar = new frmEliminarProducto(id);
                eliminar.FormClosed += frmAltaProducto_FormClosed;
                eliminar.ShowDialog();
            }
        }
    }
}
