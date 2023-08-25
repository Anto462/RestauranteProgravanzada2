using MessagePack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace ProyectoRestaurante.Models2
{
    public partial class Menu
    {
        public Menu()
        {
            DetalleOrdens = new HashSet<DetalleOrden>();
            Recomendacions = new HashSet<Recomendacion>();
        }
        [Key]
        [DisplayName("Id Plato")]
        public int IdPlato { get; set; }

        [DisplayName("Nombre Plato")]
        public string NombrePlato { get; set; } = null!;

        [DisplayName("Descripción")]
        public string Descripcion { get; set; } = null!;

        [DisplayName("Imagen")]
        public string Imagen { get; set; } = null!;

        [DisplayName("Precio")]
        public decimal Precio { get; set; }

        [DisplayName("Id Categoria")]
        public int IdCategoria { get; set; }

        public virtual Categorium IdCategoriaNavigation { get; set; } = null!;
        public virtual ICollection<DetalleOrden> DetalleOrdens { get; set; }
        public virtual ICollection<Recomendacion> Recomendacions { get; set; }
    }
}
