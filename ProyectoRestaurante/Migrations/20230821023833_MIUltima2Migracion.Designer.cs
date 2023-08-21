﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoRestaurante.Models2;

#nullable disable

namespace ProyectoRestaurante.Migrations
{
    [DbContext(typeof(RestauranteContext))]
    [Migration("20230821023833_MIUltima2Migracion")]
    partial class MIUltima2Migracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AspNetUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.AspNetRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NormalizedName" }, "RoleNameIndex")
                        .IsUnique()
                        .HasFilter("([NormalizedName] IS NOT NULL)");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.AspNetRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "RoleId" }, "IX_AspNetRoleClaims_RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.AspNetUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NormalizedEmail" }, "EmailIndex");

                    b.HasIndex(new[] { "NormalizedUserName" }, "UserNameIndex")
                        .IsUnique()
                        .HasFilter("([NormalizedUserName] IS NOT NULL)");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.AspNetUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UserId" }, "IX_AspNetUserClaims_UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.AspNetUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex(new[] { "UserId" }, "IX_AspNetUserLogins_UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.AspNetUserToken", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.Categorium", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"), 1L, 1);

                    b.Property<string>("NombreCat")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdCategoria")
                        .HasName("PK__Categori__A3C02A10F0CC1434");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.DetalleOrden", b =>
                {
                    b.Property<int>("IdDetalleOrden")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetalleOrden"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("IdOrden")
                        .HasColumnType("int");

                    b.Property<int>("IdPlato")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("IdDetalleOrden")
                        .HasName("PK__DetalleO__5A7785109069848A");

                    b.HasIndex("IdOrden");

                    b.HasIndex("IdPlato");

                    b.ToTable("DetalleOrden", (string)null);
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.Factura", b =>
                {
                    b.Property<int>("IdFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFactura"), 1L, 1);

                    b.Property<int>("Costototal")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFactura")
                        .HasColumnType("date");

                    b.Property<TimeSpan>("HoraFactura")
                        .HasColumnType("time");

                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IdDorden")
                        .HasColumnType("int")
                        .HasColumnName("Id_DOrden");

                    b.HasKey("IdFactura")
                        .HasName("PK__Factura__50E7BAF14D22C155");

                    b.HasIndex("Id");

                    b.HasIndex("IdDorden");

                    b.ToTable("Factura", (string)null);
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.Menu", b =>
                {
                    b.Property<int>("IdPlato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPlato"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int")
                        .HasColumnName("Id_Categoria");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombrePlato")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("IdPlato")
                        .HasName("PK__Menu__4C943920BDBFED4E");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Menu", (string)null);
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.Mesa", b =>
                {
                    b.Property<int>("IdMesa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMesa"), 1L, 1);

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdMesa")
                        .HasName("PK__Mesa__4D7E81B1434491E6");

                    b.ToTable("Mesa", (string)null);
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.Orden", b =>
                {
                    b.Property<int>("IdOrden")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOrden"), 1L, 1);

                    b.Property<DateTime>("FechaOrden")
                        .HasColumnType("date");

                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IdMesa")
                        .HasColumnType("int");

                    b.HasKey("IdOrden")
                        .HasName("PK__Orden__C38F300DC60788CC");

                    b.HasIndex("Id");

                    b.HasIndex("IdMesa");

                    b.ToTable("Orden", (string)null);
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.Recomendacion", b =>
                {
                    b.Property<int>("IdRecomendacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRecomendacion"), 1L, 1);

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IdPlato")
                        .HasColumnType("int");

                    b.HasKey("IdRecomendacion")
                        .HasName("PK__Recomend__190283E0DD2176DB");

                    b.HasIndex("Id");

                    b.HasIndex("IdPlato");

                    b.ToTable("Recomendacion", (string)null);
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.Resena", b =>
                {
                    b.Property<int>("IdResena")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdResena"), 1L, 1);

                    b.Property<int>("Calificacion")
                        .HasColumnType("int");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdResena")
                        .HasName("PK__Resena__A53BB7F81EF1B57C");

                    b.HasIndex("Id");

                    b.ToTable("Resena", (string)null);
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.Reservacion", b =>
                {
                    b.Property<int>("IdReservacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReservacion"), 1L, 1);

                    b.Property<int>("CantidadPersonas")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaReserva")
                        .HasColumnType("date");

                    b.Property<TimeSpan>("HoraReserva")
                        .HasColumnType("time");

                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IdMesa")
                        .HasColumnType("int")
                        .HasColumnName("Id_Mesa");

                    b.HasKey("IdReservacion")
                        .HasName("PK__Reservac__528246373875B3B1");

                    b.HasIndex("Id");

                    b.HasIndex("IdMesa");

                    b.ToTable("Reservacion", (string)null);
                });

            modelBuilder.Entity("AspNetUserRole", b =>
                {
                    b.HasOne("ProyectoRestaurante.Models2.AspNetRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoRestaurante.Models2.AspNetUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.AspNetRoleClaim", b =>
                {
                    b.HasOne("ProyectoRestaurante.Models2.AspNetRole", "Role")
                        .WithMany("AspNetRoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.AspNetUserClaim", b =>
                {
                    b.HasOne("ProyectoRestaurante.Models2.AspNetUser", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.AspNetUserLogin", b =>
                {
                    b.HasOne("ProyectoRestaurante.Models2.AspNetUser", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.AspNetUserToken", b =>
                {
                    b.HasOne("ProyectoRestaurante.Models2.AspNetUser", "User")
                        .WithMany("AspNetUserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.DetalleOrden", b =>
                {
                    b.HasOne("ProyectoRestaurante.Models2.Orden", "IdOrdenNavigation")
                        .WithMany("DetalleOrdens")
                        .HasForeignKey("IdOrden")
                        .IsRequired()
                        .HasConstraintName("FK_DetalleOrden_Orden");

                    b.HasOne("ProyectoRestaurante.Models2.Menu", "IdPlatoNavigation")
                        .WithMany("DetalleOrdens")
                        .HasForeignKey("IdPlato")
                        .IsRequired()
                        .HasConstraintName("FK_DetalleOrden_Menu");

                    b.Navigation("IdOrdenNavigation");

                    b.Navigation("IdPlatoNavigation");
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.Factura", b =>
                {
                    b.HasOne("ProyectoRestaurante.Models2.AspNetUser", "IdNavigation")
                        .WithMany("Facturas")
                        .HasForeignKey("Id")
                        .HasConstraintName("FK_Factura_Usuario");

                    b.HasOne("ProyectoRestaurante.Models2.DetalleOrden", "IdDordenNavigation")
                        .WithMany("Facturas")
                        .HasForeignKey("IdDorden")
                        .IsRequired()
                        .HasConstraintName("FK_Factura_DetalleOrden");

                    b.Navigation("IdDordenNavigation");

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.Menu", b =>
                {
                    b.HasOne("ProyectoRestaurante.Models2.Categorium", "IdCategoriaNavigation")
                        .WithMany("Menus")
                        .HasForeignKey("IdCategoria")
                        .IsRequired()
                        .HasConstraintName("FK_Menu_Categoria");

                    b.Navigation("IdCategoriaNavigation");
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.Orden", b =>
                {
                    b.HasOne("ProyectoRestaurante.Models2.AspNetUser", "IdNavigation")
                        .WithMany("Ordens")
                        .HasForeignKey("Id")
                        .HasConstraintName("FK_Orden_Usuario");

                    b.HasOne("ProyectoRestaurante.Models2.Mesa", "IdMesaNavigation")
                        .WithMany("Ordens")
                        .HasForeignKey("IdMesa")
                        .IsRequired()
                        .HasConstraintName("FK_Orden_Mesa");

                    b.Navigation("IdMesaNavigation");

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.Recomendacion", b =>
                {
                    b.HasOne("ProyectoRestaurante.Models2.AspNetUser", "IdNavigation")
                        .WithMany("Recomendacions")
                        .HasForeignKey("Id")
                        .HasConstraintName("FK_Recomendacion_Usuario");

                    b.HasOne("ProyectoRestaurante.Models2.Menu", "IdPlatoNavigation")
                        .WithMany("Recomendacions")
                        .HasForeignKey("IdPlato")
                        .IsRequired()
                        .HasConstraintName("FK_Recomendacion_Menu");

                    b.Navigation("IdNavigation");

                    b.Navigation("IdPlatoNavigation");
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.Resena", b =>
                {
                    b.HasOne("ProyectoRestaurante.Models2.AspNetUser", "IdNavigation")
                        .WithMany("Resenas")
                        .HasForeignKey("Id")
                        .HasConstraintName("FK_Resena_Usuario");

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.Reservacion", b =>
                {
                    b.HasOne("ProyectoRestaurante.Models2.AspNetUser", "IdNavigation")
                        .WithMany("Reservacions")
                        .HasForeignKey("Id")
                        .HasConstraintName("FK_Reservacion_Usuario");

                    b.HasOne("ProyectoRestaurante.Models2.Mesa", "IdMesaNavigation")
                        .WithMany("Reservacions")
                        .HasForeignKey("IdMesa")
                        .IsRequired()
                        .HasConstraintName("FK_Reservacion_Mesa");

                    b.Navigation("IdMesaNavigation");

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.AspNetRole", b =>
                {
                    b.Navigation("AspNetRoleClaims");
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.AspNetUser", b =>
                {
                    b.Navigation("AspNetUserClaims");

                    b.Navigation("AspNetUserLogins");

                    b.Navigation("AspNetUserTokens");

                    b.Navigation("Facturas");

                    b.Navigation("Ordens");

                    b.Navigation("Recomendacions");

                    b.Navigation("Resenas");

                    b.Navigation("Reservacions");
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.Categorium", b =>
                {
                    b.Navigation("Menus");
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.DetalleOrden", b =>
                {
                    b.Navigation("Facturas");
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.Menu", b =>
                {
                    b.Navigation("DetalleOrdens");

                    b.Navigation("Recomendacions");
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.Mesa", b =>
                {
                    b.Navigation("Ordens");

                    b.Navigation("Reservacions");
                });

            modelBuilder.Entity("ProyectoRestaurante.Models2.Orden", b =>
                {
                    b.Navigation("DetalleOrdens");
                });
#pragma warning restore 612, 618
        }
    }
}
