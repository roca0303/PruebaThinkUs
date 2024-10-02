using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaThinkUs.Migrations
{
    /// <inheritdoc />
    public partial class DatosParaEmpleado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Empleado");

            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Empleado",
                newName: "Posicion");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Empleado",
                newName: "Descripcion");

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Empleado",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Empleado");

            migrationBuilder.RenameColumn(
                name: "Posicion",
                table: "Empleado",
                newName: "Telefono");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Empleado",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Empleado",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
