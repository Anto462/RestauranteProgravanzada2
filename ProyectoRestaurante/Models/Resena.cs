using System.ComponentModel.DataAnnotations;

namespace ProyectoRestaurante.Models
{
    public class Resena
    {
        [Key]
        public int IdResena { get; set; }
        public int IdUsuario { get; set; }
        public string Comentario { get; set; }
        public int Calificacion { get; set; }

    }
}
