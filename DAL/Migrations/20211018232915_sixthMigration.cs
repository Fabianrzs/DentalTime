using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class sixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Complicaciones",
                table: "ConsultasClinicas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Complicaciones",
                table: "ConsultasClinicas");
        }
    }
}
