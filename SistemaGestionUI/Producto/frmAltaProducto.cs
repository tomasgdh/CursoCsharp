using SistemaGestionBusiness;

namespace SistemaGestionUI.Producto
{
    public partial class frmAltaProducto : Form
    {
        public frmAltaProducto()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SistemaGestionEntities.Producto producto = new SistemaGestionEntities.Producto();

            producto.Descripcion = txtDescripcion.Text;
            producto.Costo = numCosto.Value;
            producto.PrecioVenta = numPrecio.Value;
            producto.Stock = (int)numStock.Value;
            producto.IdUsuario = int.Parse(txtUsuario.Text);

            ProductoBusiness.CrearProducto(producto);
            MessageBox.Show("Se grabo Correctamente");
            this.Close();

        }

        private void frmAltaProducto_Load(object sender, EventArgs e)
        {

        }

    }
}
