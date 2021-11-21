using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace app_web_backend_Mediquei.Migrations
{
    public partial class M03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContratosCuidador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuidadorId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    DataInicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraEntrada1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraSaida1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraEntrada2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraSaida2 = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratosCuidador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContratosCuidador_Cuidadores_CuidadorId",
                        column: x => x.CuidadorId,
                        principalTable: "Cuidadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratosCuidador_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContratosCuidador_CuidadorId",
                table: "ContratosCuidador",
                column: "CuidadorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosCuidador_PacienteId",
                table: "ContratosCuidador",
                column: "PacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContratosCuidador");
        }
    }
}
