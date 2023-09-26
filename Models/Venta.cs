﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoCsharp.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public string Comentarios { get; set; }
        public int IdUsuario { get; set; }

        public Venta(int id, string comentarios, int idUsuario)
        {
            Id = id;
            Comentarios = comentarios;
            IdUsuario = idUsuario;
        }

        public Venta()
        {
            Id = 0;
            Comentarios = string.Empty;
            IdUsuario = 0;
        }
    }

}
