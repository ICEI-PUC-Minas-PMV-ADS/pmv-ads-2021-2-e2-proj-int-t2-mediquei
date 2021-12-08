using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace app_web_backend_Mediquei.Migrations
{
    public partial class M09 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TratamentosSaudeDet_EfeitosAdversos_EfeitoId1",
                table: "TratamentosSaudeDet");

            migrationBuilder.DropForeignKey(
                name: "FK_TratamentosSaudeDet_EfeitosAdversos_EfeitoId2",
                table: "TratamentosSaudeDet");

            migrationBuilder.DropForeignKey(
                name: "FK_TratamentosSaudeDet_EfeitosAdversos_EfeitoId3",
                table: "TratamentosSaudeDet");

            migrationBuilder.DropForeignKey(
                name: "FK_TratamentosSaudeDet_Medicamentos_MedicamentoId",
                table: "TratamentosSaudeDet");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HoraSaida2",
                table: "ContratosCuidador",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HoraEntrada2",
                table: "ContratosCuidador",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFinal",
                table: "ContratosCuidador",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DesafioSaudePaciente_Pacientes_PacientesId",
                        column: x => x.PacientesId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TratSaude",
                columns: table => new
                {
                    TratSaudeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesafioSaudeId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Checked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TratSaude", x => x.TratSaudeId);
                    table.ForeignKey(
                        name: "FK_TratSaude_DesafiosSaude_DesafioSaudeId",
                        column: x => x.DesafioSaudeId,
                        principalTable: "DesafiosSaude",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TratSaude_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_TratSaude_DesafioSaudeId",
                table: "TratSaude",
                column: "DesafioSaudeId");

            migrationBuilder.CreateIndex(
                name: "IX_TratSaude_PacienteId",
                table: "TratSaude",
                column: "PacienteId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TratamentosSaudeDet_EfeitosAdversos_EfeitoId1",
                table: "TratamentosSaudeDet",
                column: "EfeitoId1",
                principalTable: "EfeitosAdversos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TratamentosSaudeDet_EfeitosAdversos_EfeitoId2",
                table: "TratamentosSaudeDet",
                column: "EfeitoId2",
                principalTable: "EfeitosAdversos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TratamentosSaudeDet_EfeitosAdversos_EfeitoId3",
                table: "TratamentosSaudeDet",
                column: "EfeitoId3",
                principalTable: "EfeitosAdversos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TratamentosSaudeDet_Medicamentos_MedicamentoId",
                table: "TratamentosSaudeDet",
                column: "MedicamentoId",
                principalTable: "Medicamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TratamentosSaudeDet_EfeitosAdversos_EfeitoId1",
                table: "TratamentosSaudeDet");

            migrationBuilder.DropForeignKey(
                name: "FK_TratamentosSaudeDet_EfeitosAdversos_EfeitoId2",
                table: "TratamentosSaudeDet");

            migrationBuilder.DropForeignKey(
                name: "FK_TratamentosSaudeDet_EfeitosAdversos_EfeitoId3",
                table: "TratamentosSaudeDet");

            migrationBuilder.DropForeignKey(
                name: "FK_TratamentosSaudeDet_Medicamentos_MedicamentoId",
                table: "TratamentosSaudeDet");

            migrationBuilder.DropTable(
                name: "DesafioSaudePaciente");

            migrationBuilder.DropTable(
                name: "TratSaudeDet");

            migrationBuilder.DropTable(
                name: "TratSaude");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HoraSaida2",
                table: "ContratosCuidador",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "HoraEntrada2",
                table: "ContratosCuidador",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFinal",
                table: "ContratosCuidador",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TratamentosSaudeDet_EfeitosAdversos_EfeitoId1",
                table: "TratamentosSaudeDet",
                column: "EfeitoId1",
                principalTable: "EfeitosAdversos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TratamentosSaudeDet_EfeitosAdversos_EfeitoId2",
                table: "TratamentosSaudeDet",
                column: "EfeitoId2",
                principalTable: "EfeitosAdversos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TratamentosSaudeDet_EfeitosAdversos_EfeitoId3",
                table: "TratamentosSaudeDet",
                column: "EfeitoId3",
                principalTable: "EfeitosAdversos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TratamentosSaudeDet_Medicamentos_MedicamentoId",
                table: "TratamentosSaudeDet",
                column: "MedicamentoId",
                principalTable: "Medicamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
