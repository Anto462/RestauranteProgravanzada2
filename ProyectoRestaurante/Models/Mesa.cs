using System.ComponentModel.DataAnnotations;

namespace ProyectoRestaurante.Models
{
    public class Mesa
    {
        [Key]
        public int IdMesa { get; set; }
        public int Capacidad { get; set; }
        public string Estado { get; set; }

    }
}
