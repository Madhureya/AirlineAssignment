using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineDBLayer.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManageAirlines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirlineName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FromCity = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ToCity = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Fare = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManageAirlines", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManageAirlines");
        }
    }
}
