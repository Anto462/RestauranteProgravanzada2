using System;
using System.Collections.Generic;

namespace ProyectoRestaurante.Models2
{
    public partial class Menu
    {
        public Menu()
        {
            DetalleOrdens = new HashSet<DetalleOrden>();
            Recomendacions = new HashSet<Recomendacion>();
        }

        public int IdPlato { get; set; }
        public string NombrePlato { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal Precio { get; set; }
        public int IdCategoria { get; set; }

        public virtual Categorium IdCategoriaNavigation { get; set; } = null!;
        public virtual ICollection<DetalleOrden> DetalleOrdens { get; set; }
        public virtual ICollection<Recomendacion> Recomendacions { get; set; }
    }
}
