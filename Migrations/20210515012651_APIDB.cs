using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace Commercial_Adverts_Web_API.Migrations
{
    public partial class APIDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommercialDeal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainTitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommercialDeal", x => x.Id);
                });

            var sqlFile = Path.Combine(".\\DatabaseScripts", @"data.sql");

            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommercialDeal");
        }
    }
}
