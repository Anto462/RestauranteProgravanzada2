using System;
using System.Collections.Generic;

namespace ProyectoRestaurante.Models2
{
    public partial class DetalleOrden
    {
        public DetalleOrden()
        {
            Facturas = new HashSet<Factura>();
        }

        public int IdDetalleOrden { get; set; }
        public int IdOrden { get; set; }
        public int IdPlato { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public virtual Orden IdOrdenNavigation { get; set; } = null!;
        public virtual Menu IdPlatoNavigation { get; set; } = null!;
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
