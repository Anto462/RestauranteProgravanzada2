using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProyectoRestaurante.Models2
{
    public partial class Recomendacion
    {
        [Key]
        [DisplayName("Id Recomendación")]
        public int IdRecomendacion { get; set; }
        public string Id { get; set; } = null!;

        [DisplayName("Id Plato")]
        public int IdPlato { get; set; }

        [DisplayName("Comentario")]
        public string Comentario { get; set; } = null!;

        public virtual AspNetUser IdNavigation { get; set; } = null!;
        public virtual Menu IdPlatoNavigation { get; set; } = null!;
    }
}
