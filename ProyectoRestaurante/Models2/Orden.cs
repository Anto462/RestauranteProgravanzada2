using MessagePack;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ProyectoRestaurante.Models2
{
    public partial class Orden
    {
        public Orden()
        {
            DetalleOrdens = new HashSet<DetalleOrden>();
        }

        [DisplayName("Id Orden")]
        public int IdOrden { get; set; }

        [DisplayName("Id")]
        public string Id { get; set; } = null!;

        [DisplayName("Mesa")]
        public int IdMesa { get; set; }

        [DisplayName("Fecha")]
        public DateTime FechaOrden { get; set; }

        [DisplayName("# Mesa")]
        public virtual Mesa IdMesaNavigation { get; set; } = null!;

        [DisplayName("Id Usuario")]
        public virtual AspNetUser IdNavigation { get; set; } = null!;
        public virtual ICollection<DetalleOrden> DetalleOrdens { get; set; }
    }
}
