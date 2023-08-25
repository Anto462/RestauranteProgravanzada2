using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProyectoRestaurante.Models2
{
    public partial class Categorium
    {
        public Categorium()
        {
            Menus = new HashSet<Menu>();
        }
        [Key]
        [DisplayName("Id Categoria")]
        public int IdCategoria { get; set; }
        [DisplayName("Categoria")]
        public string NombreCat { get; set; } = null!;

        public virtual ICollection<Menu> Menus { get; set; }
    }
}
