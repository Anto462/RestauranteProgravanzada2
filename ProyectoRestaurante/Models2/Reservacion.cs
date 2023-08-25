using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProyectoRestaurante.Models2
{
    public partial class Reservacion
    {
        [Key]
        [DisplayName("Id Reservación")]
        public int IdReservacion { get; set; }
        public string Id { get; set; } = null!;

        [DisplayName("Fecha Reservación")]
        public DateTime FechaReserva { get; set; }

        [DisplayName("Hora Reserva")]
        public TimeSpan HoraReserva { get; set; }

        [DisplayName("Cantidad de Personas")]
        public int CantidadPersonas { get; set; }

        [DisplayName("Id Mesa")]
        public int IdMesa { get; set; }

        public virtual Mesa? IdMesaNavigation { get; set; } = null!;
        public virtual AspNetUser? IdNavigation { get; set; } = null!;
    }
}
