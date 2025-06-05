using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIS_Ticket_daw.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAsignacionTicketRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_asignacion_tickets_empleados_id_empleado",
                table: "asignacion_tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_asignacion_tickets_tickets_id_ticket",
                table: "asignacion_tickets");

            migrationBuilder.AddColumn<int>(
                name: "empleadosid_empleado",
                table: "asignacion_tickets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ticketsid_ticket",
                table: "asignacion_tickets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_asignacion_tickets_empleadosid_empleado",
                table: "asignacion_tickets",
                column: "empleadosid_empleado");

            migrationBuilder.CreateIndex(
                name: "IX_asignacion_tickets_ticketsid_ticket",
                table: "asignacion_tickets",
                column: "ticketsid_ticket");

            migrationBuilder.AddForeignKey(
                name: "FK_asignacion_tickets_empleados_empleadosid_empleado",
                table: "asignacion_tickets",
                column: "empleadosid_empleado",
                principalTable: "empleados",
                principalColumn: "id_empleado");

            migrationBuilder.AddForeignKey(
                name: "FK_asignacion_tickets_empleados_id_empleado",
                table: "asignacion_tickets",
                column: "id_empleado",
                principalTable: "empleados",
                principalColumn: "id_empleado",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_asignacion_tickets_tickets_id_ticket",
                table: "asignacion_tickets",
                column: "id_ticket",
                principalTable: "tickets",
                principalColumn: "id_ticket",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_asignacion_tickets_tickets_ticketsid_ticket",
                table: "asignacion_tickets",
                column: "ticketsid_ticket",
                principalTable: "tickets",
                principalColumn: "id_ticket");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_asignacion_tickets_empleados_empleadosid_empleado",
                table: "asignacion_tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_asignacion_tickets_empleados_id_empleado",
                table: "asignacion_tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_asignacion_tickets_tickets_id_ticket",
                table: "asignacion_tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_asignacion_tickets_tickets_ticketsid_ticket",
                table: "asignacion_tickets");

            migrationBuilder.DropIndex(
                name: "IX_asignacion_tickets_empleadosid_empleado",
                table: "asignacion_tickets");

            migrationBuilder.DropIndex(
                name: "IX_asignacion_tickets_ticketsid_ticket",
                table: "asignacion_tickets");

            migrationBuilder.DropColumn(
                name: "empleadosid_empleado",
                table: "asignacion_tickets");

            migrationBuilder.DropColumn(
                name: "ticketsid_ticket",
                table: "asignacion_tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_asignacion_tickets_empleados_id_empleado",
                table: "asignacion_tickets",
                column: "id_empleado",
                principalTable: "empleados",
                principalColumn: "id_empleado",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asignacion_tickets_tickets_id_ticket",
                table: "asignacion_tickets",
                column: "id_ticket",
                principalTable: "tickets",
                principalColumn: "id_ticket",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
