using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoRestaurante.Migrations
{
    public partial class MIUltima2Migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Costototal",
                table: "Factura",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Costototal",
                table: "Factura");
        }
    }
}
