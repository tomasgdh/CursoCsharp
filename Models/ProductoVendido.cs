using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoCsharp.Models
{
    public class ProductoVendido
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int Stock { get; set; }
        public int Idventa { get; set; }

        public ProductoVendido(int id, int idProducto, int stock, int idventa)
        {
            Id = id;
            IdProducto = idProducto;
            Stock = stock;
            Idventa = idventa;
        }

        public ProductoVendido()
        {
            Id = 0;
            IdProducto = 0;
            Stock = 0;
            Idventa = 0;
        }


    }
}
