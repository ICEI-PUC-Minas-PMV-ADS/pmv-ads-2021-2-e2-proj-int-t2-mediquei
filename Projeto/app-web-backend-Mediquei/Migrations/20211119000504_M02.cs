using Microsoft.EntityFrameworkCore.Migrations;

namespace app_web_backend_Mediquei.Migrations
{
    public partial class M02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FamiliarId = table.Column<int>(type: "int", nullable: false),
                    grauParentesco = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Familiares_FamiliarId",
                        column: x => x.FamiliarId,
                        principalTable: "Familiares",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pacientes_Usuarios_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_FamiliarId",
                table: "Pacientes",
                column: "FamiliarId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_UserId",
                table: "Pacientes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
