using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProyectoRestaurante.Models2
{
    public partial class Resena
    {
        [Key]
        [DisplayName("Id Reseña")]
        public int IdResena { get; set; }
        public string Id { get; set; } = null!;

        [DisplayName("Comentario")]
        public string Comentario { get; set; } = null!;

        [DisplayName("Calificación")]
        public int Calificacion { get; set; }

        public virtual AspNetUser IdNavigation { get; set; } = null!;
    }
}
