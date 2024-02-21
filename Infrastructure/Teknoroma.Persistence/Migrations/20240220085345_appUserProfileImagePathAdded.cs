using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teknoroma.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class appUserProfileImagePathAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ImagePath",
                table: "AppUserProfiles",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "AppUserProfiles");
        }
    }
}
