using Microsoft.EntityFrameworkCore.Migrations;

namespace app_web_backend_Mediquei.Migrations
{
    public partial class M06 : Migration
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

            migrationBuilder.DropForeignKey(
                name: "FK_TratamentosSaudeDet_TratamentosSaude_TratamentoId",
                table: "TratamentosSaudeDet");

            migrationBuilder.AddColumn<int>(
                name: "DesafioSaudeId",
                table: "Pacientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TratSaude",
                columns: table => new
                {
                    TratSaudeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesafioSaudeId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TratSaude", x => x.TratSaudeId);
                    table.ForeignKey(
                        name: "FK_TratSaude_DesafiosSaude_DesafioSaudeId",
                        column: x => x.DesafioSaudeId,
                        principalTable: "DesafiosSaude",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TratSaude_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_DesafioSaudeId",
                table: "Pacientes",
                column: "DesafioSaudeId");

            migrationBuilder.CreateIndex(
                name: "IX_TratSaude_DesafioSaudeId",
                table: "TratSaude",
                column: "DesafioSaudeId");

            migrationBuilder.CreateIndex(
                name: "IX_TratSaude_PacienteId",
                table: "TratSaude",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_DesafiosSaude_DesafioSaudeId",
                table: "Pacientes",
                column: "DesafioSaudeId",
                principalTable: "DesafiosSaude",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TratamentosSaudeDet_EfeitosAdversos_EfeitoId1",
                table: "TratamentosSaudeDet",
                column: "EfeitoId1",
                principalTable: "EfeitosAdversos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TratamentosSaudeDet_EfeitosAdversos_EfeitoId2",
                table: "TratamentosSaudeDet",
                column: "EfeitoId2",
                principalTable: "EfeitosAdversos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TratamentosSaudeDet_EfeitosAdversos_EfeitoId3",
                table: "TratamentosSaudeDet",
                column: "EfeitoId3",
                principalTable: "EfeitosAdversos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TratamentosSaudeDet_Medicamentos_MedicamentoId",
                table: "TratamentosSaudeDet",
                column: "MedicamentoId",
                principalTable: "Medicamentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TratamentosSaudeDet_TratamentosSaude_TratamentoId",
                table: "TratamentosSaudeDet",
                column: "TratamentoId",
                principalTable: "TratamentosSaude",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_DesafiosSaude_DesafioSaudeId",
                table: "Pacientes");

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

            migrationBuilder.DropForeignKey(
                name: "FK_TratamentosSaudeDet_TratamentosSaude_TratamentoId",
                table: "TratamentosSaudeDet");

            migrationBuilder.DropTable(
                name: "TratSaude");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_DesafioSaudeId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "DesafioSaudeId",
                table: "Pacientes");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TratamentosSaudeDet_TratamentosSaude_TratamentoId",
                table: "TratamentosSaudeDet",
                column: "TratamentoId",
                principalTable: "TratamentosSaude",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
