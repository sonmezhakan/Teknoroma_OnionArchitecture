using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teknoroma.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TechnicalProblemUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProblemDetail",
                table: "TechnicalProblems");

            migrationBuilder.AddColumn<string>(
                name: "ProblemSolution",
                table: "TechnicalProblems",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProblemSolution",
                table: "TechnicalProblems");

            migrationBuilder.AddColumn<string>(
                name: "ProblemDetail",
                table: "TechnicalProblems",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }
    }
}
