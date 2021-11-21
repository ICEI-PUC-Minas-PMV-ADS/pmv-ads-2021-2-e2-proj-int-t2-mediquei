using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace app_web_backend_Mediquei.Migrations
{
    public partial class M05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EfeitosAdversos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EfeitosAdversos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TratamentosSaudeDet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TratamentoId = table.Column<int>(type: "int", nullable: false),
                    MedicamentoId = table.Column<int>(type: "int", nullable: false),
                    Posologia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFinal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraInicial = table.Column<DateTime>(type: "datetime2", nullable: true),
                    intervalo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EfeitoId1 = table.Column<int>(type: "int", nullable: true),
                    EfeitoId2 = table.Column<int>(type: "int", nullable: true),
                    EfeitoId3 = table.Column<int>(type: "int", nullable: true)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TratamentosSaudeDet");

            migrationBuilder.DropTable(
                name: "EfeitosAdversos");
        }
    }
}
