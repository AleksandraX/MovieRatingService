using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieService.Entities.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilmRates",
                columns: table => new
                {
                    FilmId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<long>(nullable: false),
                    Sum = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmRates", x => x.FilmId);
                });

            migrationBuilder.InsertData(
                table: "FilmRates",
                columns: new[] { "FilmId", "Count", "Sum" },
                values: new object[,]
                {
                    { 1, 125L, 700L },
                    { 2, 35L, 300L },
                    { 3, 80L, 600L },
                    { 4, 100L, 700L },
                    { 5, 112L, 700L },
                    { 6, 100L, 200L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmRates");
        }
    }
}
