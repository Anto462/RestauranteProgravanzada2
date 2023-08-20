using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoRestaurante.Migrations
{
    public partial class MIPrimeraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCat = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__A3C02A10F0CC1434", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Mesa",
                columns: table => new
                {
                    IdMesa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Mesa__4D7E81B1434491E6", x => x.IdMesa);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resena",
                columns: table => new
                {
                    IdResena = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Comentario = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Calificacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Resena__A53BB7F81EF1B57C", x => x.IdResena);
                    table.ForeignKey(
                        name: "FK_Resena_Usuario",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    IdPlato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePlato = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Id_Categoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Menu__4C943920BDBFED4E", x => x.IdPlato);
                    table.ForeignKey(
                        name: "FK_Menu_Categoria",
                        column: x => x.Id_Categoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria");
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    IdOrden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    IdMesa = table.Column<int>(type: "int", nullable: false),
                    FechaOrden = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orden__C38F300DC60788CC", x => x.IdOrden);
                    table.ForeignKey(
                        name: "FK_Orden_Mesa",
                        column: x => x.IdMesa,
                        principalTable: "Mesa",
                        principalColumn: "IdMesa");
                    table.ForeignKey(
                        name: "FK_Orden_Usuario",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservacion",
                columns: table => new
                {
                    IdReservacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    FechaReserva = table.Column<DateTime>(type: "date", nullable: false),
                    HoraReserva = table.Column<TimeSpan>(type: "time", nullable: false),
                    CantidadPersonas = table.Column<int>(type: "int", nullable: false),
                    Id_Mesa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reservac__528246373875B3B1", x => x.IdReservacion);
                    table.ForeignKey(
                        name: "FK_Reservacion_Mesa",
                        column: x => x.Id_Mesa,
                        principalTable: "Mesa",
                        principalColumn: "IdMesa");
                    table.ForeignKey(
                        name: "FK_Reservacion_Usuario",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Recomendacion",
                columns: table => new
                {
                    IdRecomendacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    IdPlato = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Recomend__190283E0DD2176DB", x => x.IdRecomendacion);
                    table.ForeignKey(
                        name: "FK_Recomendacion_Menu",
                        column: x => x.IdPlato,
                        principalTable: "Menu",
                        principalColumn: "IdPlato");
                    table.ForeignKey(
                        name: "FK_Recomendacion_Usuario",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DetalleOrden",
                columns: table => new
                {
                    IdDetalleOrden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrden = table.Column<int>(type: "int", nullable: false),
                    IdPlato = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DetalleO__5A7785109069848A", x => x.IdDetalleOrden);
                    table.ForeignKey(
                        name: "FK_DetalleOrden_Menu",
                        column: x => x.IdPlato,
                        principalTable: "Menu",
                        principalColumn: "IdPlato");
                    table.ForeignKey(
                        name: "FK_DetalleOrden_Orden",
                        column: x => x.IdOrden,
                        principalTable: "Orden",
                        principalColumn: "IdOrden");
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    IdFactura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    FechaFactura = table.Column<DateTime>(type: "date", nullable: false),
                    HoraFactura = table.Column<TimeSpan>(type: "time", nullable: false),
                    Id_DOrden = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Factura__50E7BAF14D22C155", x => x.IdFactura);
                    table.ForeignKey(
                        name: "FK_Factura_DetalleOrden",
                        column: x => x.Id_DOrden,
                        principalTable: "DetalleOrden",
                        principalColumn: "IdDetalleOrden");
                    table.ForeignKey(
                        name: "FK_Factura_Usuario",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "([NormalizedName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "([NormalizedUserName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrden_IdOrden",
                table: "DetalleOrden",
                column: "IdOrden");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrden_IdPlato",
                table: "DetalleOrden",
                column: "IdPlato");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_Id",
                table: "Factura",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_Id_DOrden",
                table: "Factura",
                column: "Id_DOrden");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Id_Categoria",
                table: "Menu",
                column: "Id_Categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_Id",
                table: "Orden",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_IdMesa",
                table: "Orden",
                column: "IdMesa");

            migrationBuilder.CreateIndex(
                name: "IX_Recomendacion_Id",
                table: "Recomendacion",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Recomendacion_IdPlato",
                table: "Recomendacion",
                column: "IdPlato");

            migrationBuilder.CreateIndex(
                name: "IX_Resena_Id",
                table: "Resena",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservacion_Id",
                table: "Reservacion",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservacion_Id_Mesa",
                table: "Reservacion",
                column: "Id_Mesa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Recomendacion");

            migrationBuilder.DropTable(
                name: "Resena");

            migrationBuilder.DropTable(
                name: "Reservacion");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DetalleOrden");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Mesa");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
