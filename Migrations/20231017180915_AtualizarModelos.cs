using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarModelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "HistoricoEscolarId",
                table: "Usuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EscolaridadeId",
                table: "Usuarios",
                column: "EscolaridadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_HistoricoEscolarId",
                table: "Usuarios",
                column: "HistoricoEscolarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Escolaridades_EscolaridadeId",
                table: "Usuarios",
                column: "EscolaridadeId",
                principalTable: "Escolaridades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_HistoricosEscolares_HistoricoEscolarId",
                table: "Usuarios",
                column: "HistoricoEscolarId",
                principalTable: "HistoricosEscolares",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Escolaridades_EscolaridadeId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_HistoricosEscolares_HistoricoEscolarId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_EscolaridadeId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_HistoricoEscolarId",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "HistoricoEscolarId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
