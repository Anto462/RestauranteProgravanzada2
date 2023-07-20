using System.ComponentModel.DataAnnotations;

namespace ProyectoRestaurante.Models
{
    public class Reservacion
    {
        [Key]
        public int IdReservacion { get; set; }
        public int Id{ get; set; }
        public DateTime FechaReserva {get; set; }
        public DateTime HoraReserva { get; set; }
        public int CantidadPersonas { get; set; }
        public int Id_Mesa { get; set; }

    }
}
