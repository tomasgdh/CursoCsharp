using Microsoft.EntityFrameworkCore;
using PrimerosPasos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoCsharp
{
    public class SistemaGEstionContext:DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        //public DbSet<ProductoVendido> ProductosVendidos { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=SistemaGestionEF;Trusted_Connection=true;");
            //optionsBuilder.UseSqlServer(@"Server=LAPTOP-H5E6U200\TOMAS;\mssqllocaldb;Database=SistemaGestionEF;Trusted_Connection=true;");
        }
    }
}
