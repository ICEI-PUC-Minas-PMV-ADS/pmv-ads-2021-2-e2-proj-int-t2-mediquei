using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace app_web_backend_Mediquei.Migrations
{
    public partial class M11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TratamentosSaudeDet");

            migrationBuilder.DropTable(
                name: "TratamentosSaude");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TratamentosSaude",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesafioId = table.Column<int>(type: "int", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TratamentosSaude", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TratamentosSaude_DesafiosSaude_DesafioId",
                        column: x => x.DesafioId,
                        principalTable: "DesafiosSaude",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TratamentosSaude_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TratamentosSaudeDet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EfeitoId1 = table.Column<int>(type: "int", nullable: false),
                    EfeitoId2 = table.Column<int>(type: "int", nullable: false),
                    EfeitoId3 = table.Column<int>(type: "int", nullable: false),
                    HoraInicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedicamentoId = table.Column<int>(type: "int", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Posologia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TratamentoId = table.Column<int>(type: "int", nullable: false),
                    intervalo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TratamentosSaudeDet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TratamentosSaudeDet_EfeitosAdversos_EfeitoId1",
                        column: x => x.EfeitoId1,
                        principalTable: "EfeitosAdversos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TratamentosSaudeDet_EfeitosAdversos_EfeitoId2",
                        column: x => x.EfeitoId2,
                        principalTable: "EfeitosAdversos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TratamentosSaudeDet_EfeitosAdversos_EfeitoId3",
                        column: x => x.EfeitoId3,
                        principalTable: "EfeitosAdversos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TratamentosSaudeDet_Medicamentos_MedicamentoId",
                        column: x => x.MedicamentoId,
                        principalTable: "Medicamentos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TratamentosSaudeDet_TratamentosSaude_TratamentoId",
                        column: x => x.TratamentoId,
                        principalTable: "TratamentosSaude",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TratamentosSaude_DesafioId",
                table: "TratamentosSaude",
                column: "DesafioId");

            migrationBuilder.CreateIndex(
                name: "IX_TratamentosSaude_PacienteId",
                table: "TratamentosSaude",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TratamentosSaudeDet_EfeitoId1",
                table: "TratamentosSaudeDet",
                column: "EfeitoId1");

            migrationBuilder.CreateIndex(
                name: "IX_TratamentosSaudeDet_EfeitoId2",
                table: "TratamentosSaudeDet",
                column: "EfeitoId2");

            migrationBuilder.CreateIndex(
                name: "IX_TratamentosSaudeDet_EfeitoId3",
                table: "TratamentosSaudeDet",
                column: "EfeitoId3");

            migrationBuilder.CreateIndex(
                name: "IX_TratamentosSaudeDet_MedicamentoId",
                table: "TratamentosSaudeDet",
                column: "MedicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_TratamentosSaudeDet_TratamentoId",
                table: "TratamentosSaudeDet",
                column: "TratamentoId");
        }
    }
}
