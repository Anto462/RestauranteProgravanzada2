using System.ComponentModel.DataAnnotations;

namespace ProyectoRestaurante.Models
{
    public class Reservacion
    {
        [Key]
        public int IdReservacion { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaReserva {get; set; }
        public TimeOnly HoraReserva { get; set; }
        public int CantidadPersonas { get; set; }

    }
}
