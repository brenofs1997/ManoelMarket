using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GM.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatePedidoCaixa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caixas_Pedidos_PedidoId",
                table: "Caixas");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "Caixas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Caixas_Pedidos_PedidoId",
                table: "Caixas",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Pedido_Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caixas_Pedidos_PedidoId",
                table: "Caixas");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "Caixas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Caixas_Pedidos_PedidoId",
                table: "Caixas",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Pedido_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
