using System;
using System.Collections.Generic;

namespace ProyectoRestaurante.Models2
{
    public partial class Mesa
    {
        public Mesa()
        {
            Ordens = new HashSet<Orden>();
            Reservacions = new HashSet<Reservacion>();
        }

        public int IdMesa { get; set; }
        public int Capacidad { get; set; }
        public string Estado { get; set; } = null!;

        public virtual ICollection<Orden> Ordens { get; set; }
        public virtual ICollection<Reservacion> Reservacions { get; set; }
    }
}
