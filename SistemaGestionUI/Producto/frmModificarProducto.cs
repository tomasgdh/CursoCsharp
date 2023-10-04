using SistemaGestionBusiness;
using SistemaGestionEntities;

namespace SistemaGestionUI.Producto
{
    public partial class frmModificarProducto : Form
    {
        public frmModificarProducto()
        {
            InitializeComponent();
        }

        private SistemaGestionEntities.Producto _producto;
        public frmModificarProducto(int IDProducto)
        {
            InitializeComponent();
            this._producto = ProductoBusiness.ObtenerProducto(IDProducto);
        }



        private void btnModificar_Click(object sender, EventArgs e)
        {
            _producto.Descripcion = txtDescripcion.Text;
            _producto.Costo = numCosto.Value;
            _producto.PrecioVenta = numPrecio.Value;
            _producto.Stock = (int)numStock.Value;
            _producto.IdUsuario = int.Parse(txtUsuario.Text);

            ProductoBusiness.ModificarProducto(_producto);
            MessageBox.Show("Se grabo Correctamente");
            this.Close();
        }

        private void frmMdificarProducto_Load(object sender, EventArgs e)
        {
            this.txtUsuario.Text = _producto.IdUsuario.ToString();
            this.txtDescripcion.Text = _producto.Descripcion;
            this.numCosto.Value = _producto.Costo;
            this.numPrecio.Value = _producto.PrecioVenta;
            this.numStock.Value = _producto.Stock;
        }
    }
}
