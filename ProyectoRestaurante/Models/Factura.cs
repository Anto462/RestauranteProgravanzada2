using System.ComponentModel.DataAnnotations;

namespace ProyectoRestaurante.Models
{
    public class Factura
    {
        [Key]
        public int IdFactura { get; set; }
        public int Id { get; set; }
        public DateTime FechaFactura { get; set; }
        public TimeOnly HoraFactura { get; set; }
        public int Id_DOrden { get; set; }

    }
}
