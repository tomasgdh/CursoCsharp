namespace SistemaGestionEntities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public float Costo { get; set; }
        public float PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }

        public Producto(int id, string descripcion, float costo, float precioVenta, int stock, int idUsuario)
        {
            Id = id;
            Descripcion = descripcion;
            Costo = costo;
            PrecioVenta = precioVenta;
            Stock = stock;
            IdUsuario = idUsuario;
        }

        public Producto()
        {
            Id = 0;
            Descripcion = string.Empty;
            Costo = 0;
            PrecioVenta = 0;
            Stock = 0;
            IdUsuario = 0;
        }
    }
}
