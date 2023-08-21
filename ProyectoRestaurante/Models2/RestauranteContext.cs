using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProyectoRestaurante.Models2
{
    public partial class RestauranteContext : DbContext
    {
        public RestauranteContext()
        {
        }

        public RestauranteContext(DbContextOptions<RestauranteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<DetalleOrden> DetalleOrdens { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Mesa> Mesas { get; set; } = null!;
        public virtual DbSet<Orden> Ordens { get; set; } = null!;
        public virtual DbSet<Recomendacion> Recomendacions { get; set; } = null!;
        public virtual DbSet<Resena> Resenas { get; set; } = null!;
        public virtual DbSet<Reservacion> Reservacions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source= DESKTOP-ITEJBTN\\SQLEXPRESS; Initial Catalog=Restaurante; Persist Security Info=False; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__A3C02A10F0CC1434");

                entity.Property(e => e.NombreCat)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetalleOrden>(entity =>
            {
                entity.HasKey(e => e.IdDetalleOrden)
                    .HasName("PK__DetalleO__5A7785109069848A");

                entity.ToTable("DetalleOrden");

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdOrdenNavigation)
                    .WithMany(p => p.DetalleOrdens)
                    .HasForeignKey(d => d.IdOrden)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleOrden_Orden");

                entity.HasOne(d => d.IdPlatoNavigation)
                    .WithMany(p => p.DetalleOrdens)
                    .HasForeignKey(d => d.IdPlato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleOrden_Menu");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PK__Factura__50E7BAF14D22C155");

                entity.ToTable("Factura");

                entity.Property(e => e.FechaFactura).HasColumnType("date");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.IdDorden).HasColumnName("Id_DOrden");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Factura_Usuario");

                entity.HasOne(d => d.IdDordenNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdDorden)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Factura_DetalleOrden");

                entity.Property(e => e.Costototal);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.IdPlato)
                    .HasName("PK__Menu__4C943920BDBFED4E");

                entity.ToTable("Menu");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdCategoria).HasColumnName("Id_Categoria");

                entity.Property(e => e.NombrePlato)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Menu_Categoria");

                entity.Property(e => e.Imagen);
            });

            modelBuilder.Entity<Mesa>(entity =>
            {
                entity.HasKey(e => e.IdMesa)
                    .HasName("PK__Mesa__4D7E81B1434491E6");

                entity.ToTable("Mesa");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.HasKey(e => e.IdOrden)
                    .HasName("PK__Orden__C38F300DC60788CC");

                entity.ToTable("Orden");

                entity.Property(e => e.FechaOrden).HasColumnType("date");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Ordens)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orden_Usuario");

                entity.HasOne(d => d.IdMesaNavigation)
                    .WithMany(p => p.Ordens)
                    .HasForeignKey(d => d.IdMesa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orden_Mesa");
            });

            modelBuilder.Entity<Recomendacion>(entity =>
            {
                entity.HasKey(e => e.IdRecomendacion)
                    .HasName("PK__Recomend__190283E0DD2176DB");

                entity.ToTable("Recomendacion");

                entity.Property(e => e.Comentario)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Recomendacions)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recomendacion_Usuario");

                entity.HasOne(d => d.IdPlatoNavigation)
                    .WithMany(p => p.Recomendacions)
                    .HasForeignKey(d => d.IdPlato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recomendacion_Menu");
            });

            modelBuilder.Entity<Resena>(entity =>
            {
                entity.HasKey(e => e.IdResena)
                    .HasName("PK__Resena__A53BB7F81EF1B57C");

                entity.ToTable("Resena");

                entity.Property(e => e.Comentario)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Resenas)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Resena_Usuario");
            });

            modelBuilder.Entity<Reservacion>(entity =>
            {
                entity.HasKey(e => e.IdReservacion)
                    .HasName("PK__Reservac__528246373875B3B1");

                entity.ToTable("Reservacion");

                entity.Property(e => e.FechaReserva).HasColumnType("date");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.IdMesa).HasColumnName("Id_Mesa");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Reservacions)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservacion_Usuario");

                entity.HasOne(d => d.IdMesaNavigation)
                    .WithMany(p => p.Reservacions)
                    .HasForeignKey(d => d.IdMesa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservacion_Mesa");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
