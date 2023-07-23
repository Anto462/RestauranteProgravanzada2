using System;
using System.Collections.Generic;

namespace ProyectoRestaurante.Models2
{
    public partial class Resena
    {
        public int IdResena { get; set; }
        public string Id { get; set; } = null!;
        public string Comentario { get; set; } = null!;
        public int Calificacion { get; set; }

        public virtual AspNetUser IdNavigation { get; set; } = null!;
    }
}
