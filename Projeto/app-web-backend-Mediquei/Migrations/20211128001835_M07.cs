using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace app_web_backend_Mediquei.Migrations
{
    public partial class M07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_DesafiosSaude_DesafioSaudeId",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_DesafioSaudeId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "DesafioSaudeId",
                table: "Pacientes");

            migrationBuilder.CreateTable(
                name: "DesafioSaudePaciente",
                columns: table => new
                {
                    DesafiosSaudeId = table.Column<int>(type: "int", nullable: false),
                    PacientesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesafioSaudePaciente", x => new { x.DesafiosSaudeId, x.PacientesId });
                    table.ForeignKey(
                        name: "FK_DesafioSaudePaciente_DesafiosSaude_DesafiosSaudeId",
                        column: x => x.DesafiosSaudeId,
                        principalTable: "DesafiosSaude",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DesafioSaudePaciente_Pacientes_PacientesId",
                        column: x => x.PacientesId,
                        principalTable: "Pacientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TratSaudeDet",
                columns: table => new
                {
                    TratSaudeDetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicamentoId = table.Column<int>(type: "int", nullable: false),
                    Posologia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFinal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraInicial = table.Column<DateTime>(type: "datetime2", nullable: true),
                    intervalo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EfeitoId1 = table.Column<int>(type: "int", nullable: true),
                    EfeitoId2 = table.Column<int>(type: "int", nullable: true),
                    EfeitoId3 = table.Column<int>(type: "int", nullable: true),
                    TratSaudeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TratSaudeDet", x => x.TratSaudeDetId);
                    table.ForeignKey(
                        name: "FK_TratSaudeDet_EfeitosAdversos_EfeitoId1",
                        column: x => x.EfeitoId1,
                        principalTable: "EfeitosAdversos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TratSaudeDet_EfeitosAdversos_EfeitoId2",
                        column: x => x.EfeitoId2,
                        principalTable: "EfeitosAdversos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TratSaudeDet_EfeitosAdversos_EfeitoId3",
                        column: x => x.EfeitoId3,
                        principalTable: "EfeitosAdversos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TratSaudeDet_Medicamentos_MedicamentoId",
                        column: x => x.MedicamentoId,
                        principalTable: "Medicamentos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TratSaudeDet_TratSaude_TratSaudeId",
                        column: x => x.TratSaudeId,
                        principalTable: "TratSaude",
                        principalColumn: "TratSaudeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DesafioSaudePaciente_PacientesId",
                table: "DesafioSaudePaciente",
                column: "PacientesId");

            migrationBuilder.CreateIndex(
                name: "IX_TratSaudeDet_EfeitoId1",
                table: "TratSaudeDet",
                column: "EfeitoId1");

            migrationBuilder.CreateIndex(
                name: "IX_TratSaudeDet_EfeitoId2",
                table: "TratSaudeDet",
                column: "EfeitoId2");

            migrationBuilder.CreateIndex(
                name: "IX_TratSaudeDet_EfeitoId3",
                table: "TratSaudeDet",
                column: "EfeitoId3");

            migrationBuilder.CreateIndex(
                name: "IX_TratSaudeDet_MedicamentoId",
                table: "TratSaudeDet",
                column: "MedicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_TratSaudeDet_TratSaudeId",
                table: "TratSaudeDet",
                column: "TratSaudeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DesafioSaudePaciente");

            migrationBuilder.DropTable(
                name: "TratSaudeDet");

            migrationBuilder.AddColumn<int>(
                name: "DesafioSaudeId",
                table: "Pacientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_DesafioSaudeId",
                table: "Pacientes",
                column: "DesafioSaudeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_DesafiosSaude_DesafioSaudeId",
                table: "Pacientes",
                column: "DesafioSaudeId",
                principalTable: "DesafiosSaude",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
