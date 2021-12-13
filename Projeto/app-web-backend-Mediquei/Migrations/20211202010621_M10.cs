using Microsoft.EntityFrameworkCore.Migrations;

namespace app_web_backend_Mediquei.Migrations
{
    public partial class M10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Familiares_FamiliarId",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_FamiliarId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "FamiliarId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "grauParentesco",
                table: "Pacientes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FamiliarId",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "grauParentesco",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_FamiliarId",
                table: "Pacientes",
                column: "FamiliarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Familiares_FamiliarId",
                table: "Pacientes",
                column: "FamiliarId",
                principalTable: "Familiares",
                principalColumn: "Id");
        }
    }
}
