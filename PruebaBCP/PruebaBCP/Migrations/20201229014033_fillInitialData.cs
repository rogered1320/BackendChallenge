using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaBCP.Migrations
{
    public partial class fillInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var currencyColumns = new[] { "Code", "Name" };
            migrationBuilder.InsertData("Currencies", currencyColumns, new object[] { "PEN", "Sol Peruano" });
            migrationBuilder.InsertData("Currencies", currencyColumns, new object[] { "USD", "Dólar Americano" });
            migrationBuilder.InsertData("Currencies", currencyColumns, new object[] { "MXN", "Peso Mexicano" });

            var currencyExchangeColumns = new[] { "FromCurrencyCode", "ToCurrencyCode", "Rate" };
            migrationBuilder.InsertData("CurrencyExchanges", currencyExchangeColumns, new object[] { "PEN", "USD", 0.28 });
            migrationBuilder.InsertData("CurrencyExchanges", currencyExchangeColumns, new object[] { "USD", "PEN", 3.62 });

            migrationBuilder.InsertData("CurrencyExchanges", currencyExchangeColumns, new object[] { "PEN", "MXN", 5.52 });
            migrationBuilder.InsertData("CurrencyExchanges", currencyExchangeColumns, new object[] { "MXN", "PEN", 0.18 });

            migrationBuilder.InsertData("CurrencyExchanges", currencyExchangeColumns, new object[] { "USD", "MXN", 19.97 });
            migrationBuilder.InsertData("CurrencyExchanges", currencyExchangeColumns, new object[] { "MXN", "USD", 0.050 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
