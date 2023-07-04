using System.ComponentModel.DataAnnotations;

namespace ProyectoRestaurante.Models
{
    public class DetalleOrden
    {
        [Key]
        public int IdDetalle { get; set; }
        public int IdOrden { get; set; }
        public int IdPlato { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

    }
}
