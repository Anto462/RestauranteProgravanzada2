using System;
using System.Collections.Generic;

namespace ProyectoRestaurante.Models2
{
    public partial class Categorium
    {
        public Categorium()
        {
            Menus = new HashSet<Menu>();
        }

        public int IdCategoria { get; set; }
        public string NombreCat { get; set; } = null!;

        public virtual ICollection<Menu> Menus { get; set; }
    }
}
