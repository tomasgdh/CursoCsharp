using SistemaGestionBusiness;
using SistemaGestionEntities;

namespace SistemaGestionUI.Producto
{
    public partial class frmEliminarProducto : Form
    {
        public frmEliminarProducto()
        {
            InitializeComponent();
        }
        private SistemaGestionEntities.Producto _producto;
        public frmEliminarProducto(int IDProducto)
        {
            InitializeComponent();
            this._producto = ProductoBusiness.ObtenerProducto(IDProducto);

            this.txtUsuario.Text = _producto.IdUsuario.ToString();
            this.txtDescripcion.Text = _producto.Descripcion;
            this.numCosto.Value = _producto.Costo;
            this.numPrecio.Value = _producto.PrecioVenta;
            this.numStock.Value = _producto.Stock;
        }
        private void frmEliminarProducto_Load(object sender, EventArgs e)
        {
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ProductoBusiness.EliminarProducto(this._producto);
            MessageBox.Show("El Producto se Elimino Correctamente");
            this.Close();
        }
    }
}
