using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class teste4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scheduling_Customers_CustomerId",
                table: "Scheduling");

            migrationBuilder.DropForeignKey(
                name: "FK_Scheduling_EmployeesProcedures_EmployeeProcedureId",
                table: "Scheduling");

            migrationBuilder.DropTable(
                name: "EmployeesProcedures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scheduling",
                table: "Scheduling");

            migrationBuilder.DropIndex(
                name: "IX_Scheduling_EmployeeProcedureId",
                table: "Scheduling");

            migrationBuilder.RenameTable(
                name: "Scheduling",
                newName: "Schedulings");

            migrationBuilder.RenameColumn(
                name: "EmployeeProcedureId",
                table: "Schedulings",
                newName: "ProcedureId");

            migrationBuilder.RenameIndex(
                name: "IX_Scheduling_CustomerId",
                table: "Schedulings",
                newName: "IX_Schedulings_CustomerId");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Schedulings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedulings",
                table: "Schedulings",
                column: "SchedulingId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedulings_EmployeeId",
                table: "Schedulings",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedulings_ProcedureId",
                table: "Schedulings",
                column: "ProcedureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedulings_Customers_CustomerId",
                table: "Schedulings",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedulings_Employees_EmployeeId",
                table: "Schedulings",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedulings_Procedures_ProcedureId",
                table: "Schedulings",
                column: "ProcedureId",
                principalTable: "Procedures",
                principalColumn: "ProcedureId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedulings_Customers_CustomerId",
                table: "Schedulings");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedulings_Employees_EmployeeId",
                table: "Schedulings");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedulings_Procedures_ProcedureId",
                table: "Schedulings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedulings",
                table: "Schedulings");

            migrationBuilder.DropIndex(
                name: "IX_Schedulings_EmployeeId",
                table: "Schedulings");

            migrationBuilder.DropIndex(
                name: "IX_Schedulings_ProcedureId",
                table: "Schedulings");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Schedulings");

            migrationBuilder.RenameTable(
                name: "Schedulings",
                newName: "Scheduling");

            migrationBuilder.RenameColumn(
                name: "ProcedureId",
                table: "Scheduling",
                newName: "EmployeeProcedureId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedulings_CustomerId",
                table: "Scheduling",
                newName: "IX_Scheduling_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scheduling",
                table: "Scheduling",
                column: "SchedulingId");

            migrationBuilder.CreateTable(
                name: "EmployeesProcedures",
                columns: table => new
                {
                    EmployeeProcedureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProcedureId = table.Column<int>(type: "int", nullable: false),
                    InsertedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesProcedures", x => x.EmployeeProcedureId);
                    table.ForeignKey(
                        name: "FK_EmployeesProcedures_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeesProcedures_Procedures_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedures",
                        principalColumn: "ProcedureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scheduling_EmployeeProcedureId",
                table: "Scheduling",
                column: "EmployeeProcedureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesProcedures_EmployeeId",
                table: "EmployeesProcedures",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesProcedures_ProcedureId",
                table: "EmployeesProcedures",
                column: "ProcedureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scheduling_Customers_CustomerId",
                table: "Scheduling",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scheduling_EmployeesProcedures_EmployeeProcedureId",
                table: "Scheduling",
                column: "EmployeeProcedureId",
                principalTable: "EmployeesProcedures",
                principalColumn: "EmployeeProcedureId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
