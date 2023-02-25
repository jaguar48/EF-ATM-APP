using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_PLL.Migrations
{
    /// <inheritdoc />
    public partial class AddedComputedColumnsChinenye : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AccountName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "[FirstName] + ' ' + [LastName] + ' '",
                stored: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComputedColumnSql: "[FirstName] + ' (' + [LastName] + ')'",
                oldStored: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AccountName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "[FirstName] + ' (' + [LastName] + ')'",
                stored: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComputedColumnSql: "[FirstName] + ' ' + [LastName] + ' '",
                oldStored: true);
        }
    }
}
