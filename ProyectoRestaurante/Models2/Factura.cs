using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProyectoRestaurante.Models2
{
    public partial class Factura
    {
        [Key]
        [DisplayName("Id Factura")]
        public int IdFactura { get; set; }
        public string Id { get; set; } = null!;
        [DisplayName("Fecha Factura")]
        public DateTime FechaFactura { get; set; }
        [DisplayName("Hora Factura")]
        public TimeSpan HoraFactura { get; set; }
        [DisplayName("Id Orden")]
        public int IdDorden { get; set; }
        [DisplayName("Total")]
        public int Costototal { get; set; }

        public virtual DetalleOrden IdDordenNavigation { get; set; } = null!;
        public virtual AspNetUser IdNavigation { get; set; } = null!;
    }
}
