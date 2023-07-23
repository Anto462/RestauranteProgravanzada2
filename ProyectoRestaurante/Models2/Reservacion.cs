using System;
using System.Collections.Generic;

namespace ProyectoRestaurante.Models2
{
    public partial class Reservacion
    {
        public int IdReservacion { get; set; }
        public string Id { get; set; } = null!;
        public DateTime FechaReserva { get; set; }
        public TimeSpan HoraReserva { get; set; }
        public int CantidadPersonas { get; set; }
        public int IdMesa { get; set; }

        public virtual Mesa? IdMesaNavigation { get; set; } = null!;
        public virtual AspNetUser? IdNavigation { get; set; } = null!;
    }
}
