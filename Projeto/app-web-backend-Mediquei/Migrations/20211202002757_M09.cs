using Microsoft.EntityFrameworkCore.Migrations;

namespace app_web_backend_Mediquei.Migrations
{
    public partial class M09 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "TratSaude");

            migrationBuilder.AddColumn<bool>(
                name: "Checked",
                table: "TratSaude",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Checked",
                table: "TratSaude");

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "TratSaude",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
