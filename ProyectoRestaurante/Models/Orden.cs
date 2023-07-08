using System.ComponentModel.DataAnnotations;

namespace ProyectoRestaurante.Models
{
    public class Orden
    {
        [Key]
        public int IdOrden { get; set; }
        public int IdUsuario { get; set; }
        public int IdMesa { get; set; }
        public DateTime FechaOrden { get; set; }

    }
}
