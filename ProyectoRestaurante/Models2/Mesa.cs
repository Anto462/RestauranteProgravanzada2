using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProyectoRestaurante.Models2
{
    public partial class Mesa
    {
        public Mesa()
        {
            Ordens = new HashSet<Orden>();
            Reservacions = new HashSet<Reservacion>();
        }
        [Key]
        [DisplayName("Id Mesa")]
        public int IdMesa { get; set; }

        [DisplayName("Capacidad")]
        public int Capacidad { get; set; }

        [DisplayName("Estado")]
        public string Estado { get; set; } = null!;

        public virtual ICollection<Orden> Ordens { get; set; }
        public virtual ICollection<Reservacion> Reservacions { get; set; }
    }
}
