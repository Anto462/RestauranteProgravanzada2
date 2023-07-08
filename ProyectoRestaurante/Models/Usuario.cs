using System.ComponentModel.DataAnnotations;

namespace ProyectoRestaurante.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set;}
        public string Nombre { get; set;}
        public string Apellido { get; set;}
        public string CorreoElectronico { get; set;}
        public string Contrasena { get; set;}
        public int IdRol { get; set;}

    }
}
