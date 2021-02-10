using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneyExchangeAppForBrainence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExchangeRequests",
                columns: table => new
                {
                    ExchangeRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromAmount = table.Column<double>(type: "float", nullable: false),
                    ToCorrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToAmount = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRequests", x => x.ExchangeRequestId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangeRequests");
        }
    }
}
