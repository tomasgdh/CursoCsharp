using SistemaGestionBusiness;

namespace SistemaGestionUI.Producto
{
    public partial class frmModificarProducto : Form
    {
        private SistemaGestionEntities.Producto _producto;

        public frmModificarProducto(int IDProducto)
        {
            InitializeComponent();
            CargarProductoAsync(IDProducto);
        }

        private async void CargarProductoAsync(int IDProducto)
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
                this.Close();
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                _producto.Descripcion = txtDescripcion.Text;
                _producto.Costo = numCosto.Value;
                _producto.PrecioVenta = numPrecio.Value;
                _producto.Stock = (int)numStock.Value;
                _producto.IdUsuario = int.Parse(txtUsuario.Text);

                try
                {
                    await Task.Run(() => ProductoBusiness.ModificarProductoAsync(_producto));
                    MessageBox.Show("Se grabó Correctamente");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void frmModificarProducto_Load(object sender, EventArgs e)
        {
        }

        private bool Validar()
        {
            bool resultado = true;
            string mensaje = string.Empty;

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                resultado = false;
                mensaje = "- La Descripción no puede estar vacía" + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                resultado = false;
                mensaje = "- El ID de Usuario no puede estar vacío" + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(mensaje))
                MessageBox.Show("Error: " + Environment.NewLine + mensaje);
            return resultado;
        }
    }
}
