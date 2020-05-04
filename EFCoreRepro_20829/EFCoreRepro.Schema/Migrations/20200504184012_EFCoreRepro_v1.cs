using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreRepro.Schema.Migrations
{
    public partial class EFCoreRepro_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    StringValue1 = table.Column<string>(nullable: true),
                    StringValue2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entities");
        }
    }
}
