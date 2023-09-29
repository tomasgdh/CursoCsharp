namespace CursoCsharp.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string NombreApellido { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }

        public Cliente(int id, string nombreApellido, string domicilio, string telefono)
        {
            Id = id;
            NombreApellido = nombreApellido;
            Domicilio = domicilio;
            Telefono = telefono;
        }

        public Cliente()
        {
            Id = 0;
            NombreApellido = string.Empty;
            Domicilio = string.Empty;
            Telefono = string.Empty;
        }
    }
}
