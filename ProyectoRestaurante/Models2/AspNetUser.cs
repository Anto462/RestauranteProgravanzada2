using System;
using System.Collections.Generic;

namespace ProyectoRestaurante.Models2
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserTokens = new HashSet<AspNetUserToken>();
            Facturas = new HashSet<Factura>();
            Ordens = new HashSet<Orden>();
            Recomendacions = new HashSet<Recomendacion>();
            Resenas = new HashSet<Resena>();
            Reservacions = new HashSet<Reservacion>();
            Roles = new HashSet<AspNetRole>();
        }

        public string Id { get; set; } = null!;
        public string? UserName { get; set; }
        public string? NormalizedUserName { get; set; }
        public string? Email { get; set; }
        public string? NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public string? ConcurrencyStamp { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<Orden> Ordens { get; set; }
        public virtual ICollection<Recomendacion> Recomendacions { get; set; }
        public virtual ICollection<Resena> Resenas { get; set; }
        public virtual ICollection<Reservacion> Reservacions { get; set; }

        public virtual ICollection<AspNetRole> Roles { get; set; }
    }
}
