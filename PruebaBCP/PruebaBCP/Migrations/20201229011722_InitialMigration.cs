using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaBCP.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyExchanges",
                columns: table => new
                {
                    FromCurrencyCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ToCurrencyCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(8,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyExchanges", x => new { x.FromCurrencyCode, x.ToCurrencyCode });
                    table.ForeignKey(
                        name: "FK_CurrencyExchanges_Currencies_FromCurrencyCode",
                        column: x => x.FromCurrencyCode,
                        principalTable: "Currencies",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_CurrencyExchanges_Currencies_ToCurrencyCode",
                        column: x => x.ToCurrencyCode,
                        principalTable: "Currencies",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyExchanges_ToCurrencyCode",
                table: "CurrencyExchanges",
                column: "ToCurrencyCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyExchanges");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
