﻿using SistemaGestionEntities;
using Microsoft.EntityFrameworkCore;

namespace SistemaGestionData.Context
{
    public class SistemaGestionContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<ProductoVendido> ProductosVendidos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=SistemaGestionEF;Trusted_Connection=true;");
            //optionsBuilder.UseSqlServer(@"Server=LAPTOP-H5E6U200\TOMAS;\mssqllocaldb;Database=SistemaGestionEF;Trusted_Connection=true;");
        }
    }
}
