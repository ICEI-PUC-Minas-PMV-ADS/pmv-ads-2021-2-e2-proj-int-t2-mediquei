using Microsoft.EntityFrameworkCore.Migrations;

namespace app_web_backend_Mediquei.Migrations
{
    public partial class M01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Familiares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familiares", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_FamiliarId",
                table: "Pacientes",
                column: "FamiliarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Familiares_FamiliarId",
                table: "Pacientes",
                column: "FamiliarId",
                principalTable: "Familiares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Familiares_FamiliarId",
                table: "Pacientes");

            migrationBuilder.DropTable(
                name: "Familiares");

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
    }
}
