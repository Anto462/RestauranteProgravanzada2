using System;
using System.Collections.Generic;

namespace ProyectoRestaurante.Models2
{
    public partial class Orden
    {
        public Orden()
        {
            DetalleOrdens = new HashSet<DetalleOrden>();
        }

        public int IdOrden { get; set; }
        public string Id { get; set; } = null!;
        public int IdMesa { get; set; }
        public DateTime FechaOrden { get; set; }

        public virtual Mesa IdMesaNavigation { get; set; } = null!;
        public virtual AspNetUser IdNavigation { get; set; } = null!;
        public virtual ICollection<DetalleOrden> DetalleOrdens { get; set; }
    }
}
