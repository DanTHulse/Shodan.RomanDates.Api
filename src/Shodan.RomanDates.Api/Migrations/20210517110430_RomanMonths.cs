using Microsoft.EntityFrameworkCore.Migrations;

namespace Shodan.RomanDates.Api.Migrations
{
    public partial class RomanMonths : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "romanus");

            migrationBuilder.CreateTable(
                name: "month",
                schema: "romanus",
                columns: table => new
                {
                    month_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    month_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    latin_month_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    month_length_days = table.Column<int>(type: "int", nullable: false),
                    average__daytime_hour_length = table.Column<decimal>(type: "decimal(3,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_month_month_id", x => x.month_id);
                });

            migrationBuilder.InsertData(
                schema: "romanus",
                table: "month",
                columns: new[] { "month_id", "average__daytime_hour_length", "latin_month_name", "month_length_days", "month_name" },
                values: new object[,]
                {
                    { 1, 0.82m, "Ianuarias", 29, "January" },
                    { 2, 0.91m, "Februarias", 28, "February" },
                    { 3, 1m, "Martias", 31, "March" },
                    { 4, 1.09m, "Apriles", 29, "April" },
                    { 5, 1.18m, "Maias", 31, "May" },
                    { 6, 1.27m, "Iunias", 29, "June" },
                    { 7, 1.18m, "Quintilis", 31, "July" },
                    { 8, 1.09m, "Sextilis", 29, "August" },
                    { 9, 1m, "Septembres", 29, "September" },
                    { 10, 0.91m, "Octobres", 31, "October" },
                    { 11, 0.82m, "Novembres", 29, "November" },
                    { 12, 0.73m, "Decembres", 29, "December" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "month",
                schema: "romanus");
        }
    }
}
