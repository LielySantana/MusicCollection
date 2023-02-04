using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicCollection.Migrations
{
    public partial class AgregarIcono : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icono",
                table: "Generos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icono",
                table: "Generos");
        }
    }
}
