using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoRestaurante.Migrations
{
    public partial class MIsegundaMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "Menu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Menu");
        }
    }
}
