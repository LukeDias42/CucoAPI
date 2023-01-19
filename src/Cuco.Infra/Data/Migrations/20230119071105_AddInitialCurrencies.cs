using Cuco.Infra.Data.Seeds;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cuco.Infra.Data.Migrations;

/// <inheritdoc />
public partial class AddInitialCurrencies : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
        => CurrencyDataSeed.GenerateInitialCurrencies(migrationBuilder);

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
        => CurrencyDataSeed.DeleteInitialCurrencies(migrationBuilder);
}
