using System;
using System.Collections.Generic;

namespace ProyectoRestaurante.Models2
{
    public partial class Recomendacion
    {
        public int IdRecomendacion { get; set; }
        public string Id { get; set; } = null!;
        public int IdPlato { get; set; }
        public string Comentario { get; set; } = null!;

        public virtual AspNetUser IdNavigation { get; set; } = null!;
        public virtual Menu IdPlatoNavigation { get; set; } = null!;
    }
}
