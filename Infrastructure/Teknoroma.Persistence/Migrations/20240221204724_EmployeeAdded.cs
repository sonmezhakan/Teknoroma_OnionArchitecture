using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teknoroma.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDepartments");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Employees");

            migrationBuilder.AddColumn<Guid>(
                name: "BranchID",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentID",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BranchID",
                table: "Employees",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentID",
                table: "Employees",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Branches_BranchID",
                table: "Employees",
                column: "BranchID",
                principalTable: "Branches",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentID",
                table: "Employees",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Branches_BranchID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_BranchID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmentID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BranchID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Employees",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Employees",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Employees",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Employees",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Employees",
                type: "char(11)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "EmployeeDepartments",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDepartments", x => new { x.EmployeeId, x.DepartmentId });
                    table.ForeignKey(
                        name: "FK_EmployeeDepartments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDepartments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartments_DepartmentId",
                table: "EmployeeDepartments",
                column: "DepartmentId");
        }
    }
}
