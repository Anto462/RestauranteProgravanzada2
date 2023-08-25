using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProyectoRestaurante.Models2
{
    public partial class DetalleOrden
    {
        public DetalleOrden()
        {
            Facturas = new HashSet<Factura>();
        }

        [Key]
        [DisplayName("Id Detalle Orden")]
        public int IdDetalleOrden { get; set; }
        [DisplayName("Id Orden")]
        public int IdOrden { get; set; }
        [DisplayName("Id Plato")]
        public int IdPlato { get; set; }
        [DisplayName("Cantidad")]
        public int Cantidad { get; set; }
        [DisplayName("Precio Unitario")]
        public decimal PrecioUnitario { get; set; }

        public virtual Orden IdOrdenNavigation { get; set; } = null!;
        public virtual Menu IdPlatoNavigation { get; set; } = null!;
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
