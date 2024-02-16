using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teknoroma.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Revize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CriticalStock",
                table: "BranchProducts");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "BranchProducts");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "BranchProducts");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Branches",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CriticalStock",
                table: "BranchProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Discount",
                table: "BranchProducts",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "BranchProducts",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Branches",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);
        }
    }
}
