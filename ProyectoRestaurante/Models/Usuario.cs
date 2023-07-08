using System.ComponentModel.DataAnnotations;

namespace ProyectoRestaurante.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set;}
        public int UsuarioID { get; set; }
        public int IdRol { get; set;}

    }
}
