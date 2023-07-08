using System.ComponentModel.DataAnnotations;

namespace ProyectoRestaurante.Models
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }
        public string Nombre { get; set; }

    }
}
