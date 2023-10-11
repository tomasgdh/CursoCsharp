using SistemaGestionBusiness;

namespace SistemaGestionUI.Producto
{
    public partial class frmAltaProducto : Form
    {
        public frmAltaProducto()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                var producto = new SistemaGestionEntities.Producto();

                producto.Descripcion = txtDescripcion.Text;
                producto.Costo = numCosto.Value;
                producto.PrecioVenta = numPrecio.Value;
                producto.Stock = (int)numStock.Value;
                producto.IdUsuario = int.Parse(txtUsuario.Text);

                try
                {
                    await Task.Run(() => ProductoBusiness.CrearProductoAsync(producto));
                    MessageBox.Show("Se grabó Correctamente");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmAltaProducto_Load(object sender, EventArgs e)
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
