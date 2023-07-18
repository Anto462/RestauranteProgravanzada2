using System.ComponentModel.DataAnnotations;

namespace ProyectoRestaurante.Models
{
    public class Menu
    {
        [Key]
        public int IdPlato { get; set; }
        public string NombrePlato { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public int Id_Categoria { get; set; }
    }
}
