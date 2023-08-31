using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ALTERNAME_TABLE_PROCEDURES_EMPLOYEES : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesProcedure_Employee_EmployeeId",
                table: "EmployeesProcedure");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesProcedure_Procedure_ProcedureId",
                table: "EmployeesProcedure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Procedure",
                table: "Procedure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Procedure",
                newName: "Procedures");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Procedures",
                table: "Procedures",
                column: "ProcedureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesProcedure_Employees_EmployeeId",
                table: "EmployeesProcedure",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesProcedure_Procedures_ProcedureId",
                table: "EmployeesProcedure",
                column: "ProcedureId",
                principalTable: "Procedures",
                principalColumn: "ProcedureId",
                onDelete: ReferentialAction.Cascade);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesProcedure_Employees_EmployeeId",
                table: "EmployeesProcedure");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesProcedure_Procedures_ProcedureId",
                table: "EmployeesProcedure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Procedures",
                table: "Procedures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Procedures",
                newName: "Procedure");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Procedure",
                table: "Procedure",
                column: "ProcedureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesProcedure_Employee_EmployeeId",
                table: "EmployeesProcedure",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesProcedure_Procedure_ProcedureId",
                table: "EmployeesProcedure",
                column: "ProcedureId",
                principalTable: "Procedure",
                principalColumn: "ProcedureId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
