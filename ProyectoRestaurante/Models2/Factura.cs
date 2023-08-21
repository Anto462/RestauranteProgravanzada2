using System;
using System.Collections.Generic;

namespace ProyectoRestaurante.Models2
{
    public partial class Factura
    {
        public int IdFactura { get; set; }
        public string Id { get; set; } = null!;
        public DateTime FechaFactura { get; set; }
        public TimeSpan HoraFactura { get; set; }
        public int IdDorden { get; set; }
        public int Costototal { get; set; }

        public virtual DetalleOrden IdDordenNavigation { get; set; } = null!;
        public virtual AspNetUser IdNavigation { get; set; } = null!;
    }
}
