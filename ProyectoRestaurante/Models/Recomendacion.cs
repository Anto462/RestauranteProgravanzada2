using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ProyectoRestaurante.Models
{
    public class Recomendacion
    {
        [Key]
        public int IdRecomendacion {get; set;}
        public int IdUsuario { get; set;}
        public int IdPlato { get; set;}
        public string Comentario { get; set;}
    }
}
