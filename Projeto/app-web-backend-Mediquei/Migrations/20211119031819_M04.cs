using Microsoft.EntityFrameworkCore.Migrations;

namespace app_web_backend_Mediquei.Migrations
{
    public partial class M04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TratamentosSaude",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    DesafioId = table.Column<int>(type: "int", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TratamentosSaude", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TratamentosSaude_DesafiosSaude_DesafioId",
                        column: x => x.DesafioId,
                        principalTable: "DesafiosSaude",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TratamentosSaude_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TratamentosSaude_DesafioId",
                table: "TratamentosSaude",
                column: "DesafioId");

            migrationBuilder.CreateIndex(
                name: "IX_TratamentosSaude_PacienteId",
                table: "TratamentosSaude",
                column: "PacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TratamentosSaude");
        }
    }
}
