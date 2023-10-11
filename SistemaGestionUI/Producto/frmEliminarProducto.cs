using SistemaGestionBusiness;

namespace SistemaGestionUI.Producto
{
    public partial class frmEliminarProducto : Form
    {
        private SistemaGestionEntities.Producto _producto;

        public frmEliminarProducto(int IDProducto)
        {
            InitializeComponent();
            CargarProductoAsync(IDProducto);
        }

        private async Task CargarProductoAsync(int IDProducto)
        {
            try
            {
                this._producto = await ProductoBusiness.ObtenerProductoAsync(IDProducto);

                txtUsuario.Text = _producto.IdUsuario.ToString();
                txtDescripcion.Text = _producto.Descripcion;
                numCosto.Value = _producto.Costo;
                numPrecio.Value = _producto.PrecioVenta;
                numStock.Value = _producto.Stock;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                await ProductoBusiness.EliminarProductoAsync(_producto.Id);
                MessageBox.Show("El Producto se Eliminó Correctamente");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmEliminarProducto_Load(object sender, EventArgs e)
        {
        }


    }
}
